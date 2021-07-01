using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FFmpegDemo;
using System.Threading;

namespace Chat2021.LogFrm
{
    public partial class LogFrm : Form
    {

        #region value
        Thread thPlayer;
        tstRtmp rtmp = new tstRtmp();
        Button closeBtn = new Button();
        PictureBox pic = new PictureBox();
        Rectangle minBtnRect = new Rectangle(new Point(1705, 0), new Size(135, 300));
        Rectangle closeBtnRect = new Rectangle(new Point(1840, 0), new Size(80,  200));
        Rectangle setBtnRect = new Rectangle(new Point(1570, 0), new Size(135, 300));
        //Rectangle minBtnRect , setBtnRect;
        private Rectangle minRect = new Rectangle(new Point(0, 0), new Size(20, 20));
        private Rectangle closeRect = new Rectangle();
        private Rectangle setRect = new Rectangle();
        delegate void HandlePicture(Bitmap bitmap);
        HandlePicture handlePicture;
        #endregion

        #region Init
        public LogFrm()
        {
            InitializeComponent();
            FrmInit();
            ControlInit();
            InitVar();
            InitEventHandler();
        }

        private void FrmInit()
        {
            this.Size = new Size(538, 330);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void InitEventHandler()
        {
            handlePicture += DrawMinBtn;
            handlePicture += DrawCloseBtn;
            handlePicture += DrawSetBtn;
            PlayVedioPic.MouseMove += MouseMoveMinBtn;
            PlayVedioPic.MouseDown += MouseDonwMinBtn;
            
        }

        private void ControlInit()
        {
            PlayVedioPic.Width = this.Width;
            PlayVedioPic.Height = 125;
            PlayVedioPic.BackColor = Color.Red;
        }

        private void InitVar()
        {
            //开启播放线程
            thPlayer = new Thread(DeCoding);
            thPlayer.IsBackground = true;
            thPlayer.Start();
        }

        #endregion

        #region PlayVedio
        private unsafe void DeCoding()
        {
            try
            {
                Console.WriteLine("DeCoding run...");
                Bitmap oldBmp = null;


                // 更新图片显示
                tstRtmp.ShowBitmap show = (bmp) =>
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        Graphics g = this.PlayVedioPic.CreateGraphics();

                        //for (int x = 0; x < 50; x++)
                        //{
                        //    for (int y = 0; y < 50; y++)
                        //    {
                        //        Color pixelColor = bmp.GetPixel(x, y);
                        //        Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                        //        bmp.SetPixel(x, y, newColor);
                        //    }
                        //}
                        handlePicture(bmp);
                        g.DrawImage(bmp, 0, 0, this.PlayVedioPic.Width, this.PlayVedioPic.Height);
                        
                        
                        
                        if (oldBmp != null)
                        {
                            oldBmp.Dispose();
                        }
                        oldBmp = bmp;
                    }));
                };
                string str = "C:/Users/14373/123.mp4";
                rtmp.Start(show, str);//txtUrl.Text.Trim());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("DeCoding exit");
                rtmp.Stop();

                thPlayer = null;
            }
        }
        #endregion

        #region 最小按钮的绘画
        private void DrawMinBtn(Bitmap bitmap)
        {
            for(int i = minBtnRect.X; i < minBtnRect.Width + minBtnRect.X; i++)
            {
                for(int j = minBtnRect.Y; j < minBtnRect.Height + minBtnRect.Y; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }
        #endregion

        #region 鼠标划过最小按钮的事件
        private void MouseMoveMinBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(minBtnRect.Contains(p))
            {

            }
        }
        #endregion

        #region 鼠标点击最小按钮事件
        private void MouseDonwMinBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(minBtnRect.Contains(p))
            {
                this.Hide();
            }
        }
        #endregion

        #region 画关闭按钮 
        private void DrawCloseBtn(Bitmap bitmap)
        {
            for(int i = closeBtnRect.X; i < closeBtnRect.X + closeBtnRect.Width; i++)
            {
                for(int j = closeBtnRect.Y; j < closeBtnRect.Y + closeBtnRect.Height; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }
        #endregion


        #region 画设置按钮
        private void DrawSetBtn(Bitmap bitmap)
        {
            for (int i = closeBtnRect.X; i < setBtnRect.X + closeBtnRect.Width; i++)
            {
                for (int j = closeBtnRect.Y; j < setBtnRect.Y + closeBtnRect.Height; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                }
            }
        }
        #endregion

    }
}
