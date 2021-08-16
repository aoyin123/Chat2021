using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat2021.win32api;

namespace Chat2021.MainFrm
{
    public partial class contactFrm : Form
    {
        #region value
        private Rectangle iconRect = new Rectangle(14, 43, 70, 70);
        private MouseHook mouseHook;
        private bool isCursorsStyleIsHand = false;
        private string userName = "IIIIIIIIIIII";
        private string level = "Lv57";
        private Font userNameFont = new Font("宋体", 12);
        private Brush userNameBrush = Brushes.White;
        private Point userNameDisPos = new Point(102, 58);
        private Font levelFont = new Font("宋体", 8, FontStyle.Bold);
        private SolidBrush levelBrush = new SolidBrush(Color.Red);
        private Point levelDisPlay = new Point(234, 65);
        #endregion

        #region 初始化
        public contactFrm()
        {
            //初始化布局
            InitializeComponent();

            //允许线程操作窗体句柄
            CheckForIllegalCrossThreadCalls = false;

            //设置双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
            SetStyle(ControlStyles.DoubleBuffer, true);

            //启动钩子程序，禁止minFrmBtn接收鼠标消息
            mouseHook = new MouseHook(this);
            mouseHook.Start();
            mouseHook.closeEvent += CloseFrm;
            mouseHook.miniEvent += HideFrm;
            

            frmSwitchUserControl1.onActivity += ChangeFrm;
        }

        private void CloseFrm()
        {
            this.Close();
        }

        private void HideFrm()
        {
            this.Hide();
            closeBtn.Hide();
            miniFrmBtn.Hide();
        }

        private void DisplayContactPersonFrm()
        {
            FrmChanged.Panel1Collapsed = false;
            FrmChanged.Panel2Collapsed = true;
        }

        private void DisplayMsgFrm()
        {
            FrmChanged.Panel1Collapsed = true;
            FrmChanged.Panel2Collapsed = false;
        }

        public void ChangeFrm(string str)
        {
            if ("联系人" == str)
            {
                DisplayMsgFrm();
            }
            else if("消息" == str)
            {
                DisplayContactPersonFrm();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //保持miniFrmBtn永远在this的上层            
            Win32.SetWindowPos(this.Handle, this.miniFrmBtn.Handle, 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0080);
            Win32.SetClassLong(this.Handle, Win32.GCL_STYLE, Win32.GetClassLong(this.Handle, Win32.GCL_STYLE) | Win32.CS_DropSHADOW);

            //保持closeBtn永远在contactFrm上层
            Win32.SetWindowPos(this.Handle, this.miniFrmBtn.Handle, 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0080);
            Win32.SetClassLong(this.Handle, Win32.GCL_STYLE, Win32.GetClassLong(this.Handle, Win32.GCL_STYLE) | Win32.CS_DropSHADOW);


            //保持窗体在最上层
            Thread t = new Thread(SetWindowTopMost);
            t.IsBackground = true;
            t.Start();

            //显示miniFrmBtn
            this.miniFrmBtn.Show(this);//不加this,miniFrmBtn所呈现的图像会频闪
            this.closeBtn.Show(this);
        }
        #endregion

        #region 鼠标触碰用户图标
        /// <summary>
        /// 画userIcon周围的光圈
        /// </summary>
        private void DrawAperture()
        {
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(new Pen(Color.FromArgb(124, 139, 160), 2), new Rectangle(14, 43, 70, 70));
        }

        
        /// <summary>
        /// 鼠标触碰到userIcon后改变鼠标样式
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">发送者附带的消息</param>
        private void ChangeMouseStyle(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Point center = new Point(iconRect.Location.X + iconRect.Width / 2,
                                     iconRect.Location.Y + iconRect.Height / 2);
            int r = iconRect.Width;
            double distance = Math.Sqrt(Math.Pow(p.X - center.X, 2) + Math.Pow(p.Y - center.Y, 2));
            if(distance < r)
            {
                Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);
                t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Hand);
                DrawAperture();
                isCursorsStyleIsHand = true;
            }
            else
            {
                if (isCursorsStyleIsHand == true)
                {
                    Type t = Type.GetType(sender.GetType().AssemblyQualifiedName);
                    t.GetProperty("Cursor").SetValue(sender, System.Windows.Forms.Cursors.Default);
                    Invalidate(new Rectangle(14, 43, 80, 80));
                    isCursorsStyleIsHand = false;
                }
            }

        }
        #endregion

        #region 窗体移动
        private void MoveMiniFrmBtn(object sender, EventArgs e)
        {
            Point p = this.Location;

            miniFrmBtn.Location = new Point(this.Location.X + 275, this.Location.Y + 20);
            MiniFrmBtn.ValidRegion = new Rectangle(new Point(this.miniFrmBtn.Location.X, this.miniFrmBtn.Location.Y - 20),
                                                   new Size(35, 38));

            closeBtn.Location = new Point(Location.X + 305, Location.Y );
            CloseBtn.ValidRegion = new Rectangle(closeBtn.Location, new Size(38, 39));
        }

        /// <summary>
        /// 鼠标移动窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFrm(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage((IntPtr)this.Handle, Win32.VM_NCLBUTTONDOWN, Win32.HTCAPTION, 0);
        }
        #endregion

        #region 调整窗体在Z轴的序数
        /// <summary>
        /// 保持窗体永远动态显示在最顶层
        /// </summary>
        private void SetWindowTopMost()
        {
            while (true)
            {
                int order1 = GetWindowZOrder(this.Handle);
                int order2 = GetWindowZOrder(this.miniFrmBtn.Handle);

                while ((order1 == GetWindowZOrder(this.Handle)) && (order2 == GetWindowZOrder(this.miniFrmBtn.Handle))) ;
                this.TopMost = true;
                this.miniFrmBtn.TopMost = true;
            }
        }

        /// <summary>
        /// 得到窗口在Z轴的序数
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <returns></returns>
        public static int GetWindowZOrder(IntPtr hwnd)
        {
            const uint GW_HWNDPREV = 3;
            const uint GW_HWNDLAST = 1;

            var lowestHwnd = Win32.GetWindow(hwnd, GW_HWNDLAST);

            var z = 0;
            var hwndTmp = lowestHwnd;
            while (hwndTmp != IntPtr.Zero)
            {
                if (hwnd == hwndTmp)
                {
                    
                    return z;
                }

                hwndTmp = Win32.GetWindow(hwndTmp, GW_HWNDPREV);
                z++;
            }
            return -1;
        }
        #endregion

        #region 绘制ChageFrm的上半区域和下半区域
        private void DrawToolBox(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(Resource1.MainFrmUnderly, new Rectangle(0, 5, ToolBox.Width, Resource1.MainFrmUnderly.Height)); ;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (mouseHook.MouseStatus == 2)
            {
                closeBtn.SetBits(Resource1.CloseBtnShadow);
                miniFrmBtn.SetBits(Resource1.MiniBtn);
                miniFrmBtn.Location = new Point(this.Location.X + 275, this.Location.Y + 20);
            }
            else if (mouseHook.MouseStatus == 3)
            {
                miniFrmBtn.Location = new Point(this.Location.X + 267, this.Location.Y);
                closeBtn.SetBits(Resource1.CloseBtn);
                miniFrmBtn.SetBits(Resource1._963);
            }
            else
            {
                miniFrmBtn.Location = new Point(this.Location.X + 275, this.Location.Y + 20);
                closeBtn.SetBits(Resource1.CloseBtn);
                miniFrmBtn.SetBits(Resource1.MiniBtn);
            }
            Graphics g = e.Graphics;
            int resultBitmapWidth = this.Width;
            int resultBitmapHeight = this.searchBoxUserControl11.Location.Y;
            Bitmap bitmap = Resource1.background;
            Bitmap upRegionBackGround = new Bitmap(resultBitmapWidth, resultBitmapHeight);
            Rectangle cropRegion = new Rectangle(0, 0, resultBitmapWidth, resultBitmapHeight);

            //裁剪图片
            Graphics graphics = Graphics.FromImage(upRegionBackGround);
            graphics.DrawImage(bitmap, cropRegion, cropRegion, GraphicsUnit.Pixel);

            //在界面上绘画用户图标，签名，用户名
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(upRegionBackGround, new Point(0, 0));
            g.DrawImage(Resource1.userIcon, iconRect);
            g.DrawString(userName, userNameFont, userNameBrush, userNameDisPos);
            g.DrawString(level, levelFont, levelBrush, levelDisPlay);
        }

        #endregion

        #region 点击签名框
        //点击签名框后可以编辑签名
        private void userNameLabeClick(object sender, EventArgs e)
        {
            this.signTextBox.Focus();
            this.signTextBox.Visible = true;
            this.userNameLabe.Visible = false;
        }

        //隐藏编辑签名框，重新显示签名
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            this.signTextBox.Visible = false;
            this.userNameLabe.Visible = true;
        }
        #endregion

    }
}
