using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat2021.win32api;
using HookSpace;
namespace Chat2021.MainFrm
{
    public partial class CloseBtn : Form
    {
        #region value
        private Rectangle validRegion;
        private MouseHook mouseHook = MouseHook.GetInstance();
        private Bitmap mouseLeaveBackGround;
        private Bitmap mouseHoverBackGround;
        /// <summary>
        /// 获取MiniFrm的有效区域
        /// </summary>
        public Rectangle ValidRegion
        {
            get => validRegion;
            set => validRegion = value;
        }

        private Bitmap image;
        /// <summary>
        /// 设置MiniFrmBtn显示的图片
        /// </summary>
        public Bitmap Image
        {
            set
            {
                image = value;
                SetBits(Resource1.halfOpcaty);
            }
        }
        #endregion
        public CloseBtn(Bitmap mouseLeaveBackGround, Bitmap mouseHoverBackGround, MouseClickHandler mouseClickHandler)
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            SetBits(mouseLeaveBackGround);

            this.mouseLeaveBackGround = mouseLeaveBackGround;
            this.mouseHoverBackGround = mouseHoverBackGround;
             
            mouseHook.mouseMoveEvent += new MouseMoveHandler(ChangeBackGround);
            mouseHook.mouseClickEvent += mouseClickHandler;
        }

        private Bitmap nowBackGround;

        private void ChangeBackGround(MousePosEventArgs e)
        {
            if(null == validRegion)
            {
                return;
            }

            Point p = e.mousePos;
            if(validRegion.Contains(p))
            {
                if(nowBackGround == mouseHoverBackGround)
                {
                    return;
                }

                SetBits(mouseHoverBackGround);
                nowBackGround = mouseHoverBackGround;
            }
            else
            {
                if(nowBackGround == mouseLeaveBackGround)
                {
                    return;
                }

                SetBits(mouseLeaveBackGround);
                nowBackGround = mouseLeaveBackGround;
            }
            
        }

        private new void Click(MousePosEventArgs e)
        {
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int width = Resource1.CloseBtn.Width;
            int height = Resource1.CloseBtn.Height;
            validRegion = new Rectangle (Location.X, Location.Y, width, height);
        }

        protected override CreateParams CreateParams
        {//重载窗体的CreateParams方法
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h中定义   
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 允许最小化操作
                cp.ExStyle |= 0x00080000;
                return cp;
            }
        }

        public void SetBits(Bitmap bitmap)//调用UpdateLayeredWindow（）方法。this.BackgroundImage为你事先准备的带透明图片。
        {

            if (!Bitmap.IsCanonicalPixelFormat(bitmap.PixelFormat) || !Bitmap.IsAlphaPixelFormat(bitmap.PixelFormat))
                throw new ApplicationException("图片必须是32位带Alhpa通道的图片。");

            IntPtr oldBits = IntPtr.Zero;
            IntPtr screenDC = Win32.GetDC(IntPtr.Zero);
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr memDc = Win32.CreateCompatibleDC(screenDC);

            try
            {
                Win32.Point topLoc = new Win32.Point(Left, Top);
                Win32.Size bitMapSize = new Win32.Size(bitmap.Width, bitmap.Height);
                Win32.BLENDFUNCTION blendFunc = new Win32.BLENDFUNCTION();
                Win32.Point srcLoc = new Win32.Point(0, 0);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBits = Win32.SelectObject(memDc, hBitmap);

                blendFunc.BlendOp = Win32.AC_SRC_OVER;//将源图片覆盖在目标之上，也就是说被替代了
                blendFunc.SourceConstantAlpha = 255; //设定bitmap的透明度
                blendFunc.AlphaFormat = Win32.AC_SRC_ALPHA;
                blendFunc.BlendFlags = 1;
                if(Handle == null)
                {
                    return;
                }

                Win32.UpdateLayeredWindow(Handle, screenDC, ref topLoc, ref bitMapSize, memDc, ref srcLoc, 0, ref blendFunc, Win32.ULW_ALPHA);
            }
            finally
            {
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBits);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.ReleaseDC(IntPtr.Zero, screenDC);
                Win32.DeleteDC(memDc);
            }
        }
    }
}
