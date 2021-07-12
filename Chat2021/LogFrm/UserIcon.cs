/************************************************************************************
*源码来自(C#源码世界)  www.HelloCsharp.com
*如果对该源码有问题可以直接点击下方的提问按钮进行提问哦
*站长将亲自帮你解决问题
*C#源码世界-找到你需要的C#源码，交流和学习
************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Chat2021.win32api;
using Chat2021.pool;

namespace Chat2021.LogFrm
{
    public partial class UserIcon : Form
    {
        #region Init
        public UserIcon()
        {
            InitializeComponent();
            this.TopMost = true;

            CheckForIllegalCrossThreadCalls = false;
            ThreadPoolWork.Start(1, 3000);
            InvalidateImage();

        }

        #endregion
        #region value
        enum MouseModel
        {
            Hover,
            leave,
        }

        MouseModel mouseModel = MouseModel.leave;
        private ThreadPoolWork ThreadPoolWork = new ThreadPoolWork();
        int posX = 153;

        #endregion


        #region 调用UpdateLayeredWindow函数

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
                blendFunc.BlendFlags = 0;

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

        #endregion


        #region 图片绘制
        private void InvalidateImage()
        {
            Bitmap newImage = new Bitmap(this.Width, this.Height);
            Graphics g1 = Graphics.FromImage(newImage);
            g1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g1.DrawImage(Resource1.hh, new Point(posX, 27));
            g1.DrawImage(Resource1.ff, new Point(130, 15));
            g1.FillEllipse(new SolidBrush(Color.FromArgb(242, 167, 40)), new Rectangle(195, 75, 15, 15));
            g1.DrawLine(new Pen(Color.FromArgb(255, 243, 176)), new Point(198, 81), new Point(207, 81));
            g1.DrawLine(new Pen(Color.FromArgb(255, 243, 176)), new Point(198, 84), new Point(207, 84));
            SetBits(newImage);
            newImage.Dispose();
            GC.Collect();
        }
        #endregion


        #region Event
        /// <summary>
        /// 当鼠标悬停在用户图标上，添加用户的图标从用户图标下面水平滑出
        /// </summary>
        /// <param name="item"></param>
        private void Close(object item)
        {
            DateTime tiggerTime = DateTime.UtcNow;
            DateTime now = DateTime.UtcNow;
            TimeSpan ts = now.Subtract(tiggerTime);
            int sec = (int)ts.TotalSeconds;
            for (; posX < 253; posX++)
            {
                posX = posX + 2;
                InvalidateImage();
            }
        }

        /// <summary>
        /// 当鼠标离开用户图标后，添加用户的图标滑向用户图标下面
        /// </summary>
        /// <param name="item"></param>
        private void Away(object item)
        {
            for (; posX >= 153; posX--)
            {
                posX = posX - 2;
                InvalidateImage();
            }
        }


        private void Icon_MouseLeave(object sender, EventArgs e)
        {
            if (mouseModel.Equals(MouseModel.Hover))
            {
                mouseModel = MouseModel.leave;
                PoolItem poolItem = new PoolItem();
                poolItem.PoolWork = Away;
                ThreadPoolWork.ADD(poolItem);
            }
        }

        private void Icon_MouseHover(object sender, EventArgs e)
        {
            if (mouseModel.Equals(MouseModel.leave))
            {
                mouseModel = MouseModel.Hover;
                PoolItem poolItem = new PoolItem();
                poolItem.PoolWork = Close;
                ThreadPoolWork.ADD(poolItem);
            }
        }

        #endregion

    }
}
