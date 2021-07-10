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
        Rectangle minBtnRect = new Rectangle(new Point(1653, 0), new Size(132, 300));
        Rectangle closeBtnRect = new Rectangle(new Point(1785, 0), new Size(135, 300));
        Rectangle setBtnRect = new Rectangle(new Point(1518, 0), new Size(135, 300));
        //Rectangle minBtnRect , setBtnRect;
        private Rectangle minRect = new Rectangle(new Point(0, 0), new Size(20, 20));
        private Rectangle closeRect = new Rectangle();
        private Rectangle setRect = new Rectangle();
        delegate void HandlePicture(Bitmap bitmap);
        HandlePicture handlePicture;
        ControlBtn controlBtn;
        #endregion

        #region Init
        public LogFrm()
        {
            InitializeComponent();
            FrmInit();
            ControlInit();
            InitVar();
            InitEventHandler();
            this.Show();
            controlBtn = new ControlBtn(this.Location, this.Size);
            controlBtn.Show();
            PlayVedioPic.BackColor = Color.Black;
            this.roundButtonCopy1.FlatStyle = FlatStyle.Flat;
            this.roundButtonCopy1.FlatAppearance.BorderSize = 0; 
            this.roundButtonCopy1.BackColor = Color.Transparent;
        }

        private void FrmInit()
        {
            this.Size = new Size(554, 458);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.BackColor = Color.White;
            //System.IntPtr iconHandle = Resource1.Chat2021.GetHicon();
            //System.Drawing.Icon icon = Icon.FromHandle(iconHandle);
            //this.notifyIcon1.Icon = icon;
            this.notifyIcon1.Text = "Chat2021";
            this.notifyIcon1.Visible = true;
            
        }

        private void InitEventHandler()
        {
            //绘制关闭按钮,设置按钮，最小化按钮
            handlePicture += DrawMinBtn;
            handlePicture += DrawCloseBtn;
            handlePicture += DrawSetBtn;

            //设置最小化按钮事件
            PlayVedioPic.MouseMove += MouseMoveMinBtn;
            PlayVedioPic.MouseDown += MouseDonwMinBtn;

            //设置关闭按钮事件
            PlayVedioPic.MouseDown += MouseDownCloseBtn;
            PlayVedioPic.MouseMove += MouseMoveCloseBtn;
            

            //设置关闭按钮事件
            //PlayVedioPic.MouseMove += MouseMoveCloseBtn;
            //PlayVedioPic.MouseDown += MouseDownCloseBtn;


            //设置设置按钮事件
            PlayVedioPic.MouseMove += MouseMoveSetBtn;
            //PlayVedioPic.MouseDown += MouseDownSetBtn;
        }

        bool IsDrawSetBtnShaodw = false;
        private void MouseMoveSetBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(SetBtnRectGraphics.Contains(p))
            {
                if (IsDrawCloseBtnShadow == true) return;
                handlePicture += DrawSetBtnShadow;
                IsDrawCloseBtnShadow = true;
            }
            else
            {
                if (IsDrawCloseBtnShadow == false) return;
                handlePicture -= DrawSetBtnShadow;
                IsDrawCloseBtnShadow = false;
            }
        }

        private void DrawSetBtnShadow(Bitmap bitmap)
        {
            for(int i = setBtnRect.X; i < setBtnRect.X + Width; i++)
            {
                for(int j = setBtnRect.Y; j < setBtnRect.Y + Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int R = color.R + 70;
                    if (R > 255) R = 255;

                    int G = color.G + 70;
                    if (G > 255) G = 255;

                    int B = color.B + 70;
                    if (B > 255) B = 255;

                }
            }
        }

        private void MouseDownCloseBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(CloseBtnRectGraphics.Contains(p))
            {
                this.Close();
            }
        }

        bool IsDrawCloseBtnShadow = false;
        
        private void DrawCloseBtnShadow(Bitmap bitmap)
        {
            for(int i = closeBtnRect.X; i < closeBtnRect.X + closeBtnRect.Width;i++)
            {
                for(int j = closeBtnRect.Y; j < closeBtnRect.Y + closeBtnRect.Height;j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int R = color.R + 70;
                    if (R > 255) R = 255;

                    int G = color.G + 70;
                    if (G > 255) G = 255;

                    int B = color.B + 70;
                    if (B > 255) B = 255;

                    bitmap.SetPixel(i, j, Color.FromArgb(R, G, B));
                }    
            }   

        }


        private void MouseMoveCloseBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(CloseBtnRectGraphics.Contains(p))
            {
                if (IsDrawCloseBtnShadow == true) return;
                handlePicture += DrawCloseBtnShadow;
                IsDrawCloseBtnShadow = true;
            }
            else
            {
                if (IsDrawCloseBtnShadow == false) return;
                handlePicture -= DrawCloseBtnShadow;
                IsDrawCloseBtnShadow = false;
            }
        }

        private void DrawLine(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            Pen pen = new Pen(Color.Black, 15);
            
            //g.FillRectangle(Brushes.Black, minBtnRect);
            //g.FillRectangle(Brushes.Black, closeBtnRect);
            //g.FillRectangle(Brushes.Black, setBtnRect);
        }

        private void ControlInit()
        {
            PlayVedioPic.Width = this.Width;
            PlayVedioPic.Height = 158;
            elementHost1.Width = this.Width;
            elementHost1.Height = this.Height - PlayVedioPic.Height;
            elementHost1.Location = new Point(0, PlayVedioPic.Height);
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
            int middleY = (minBtnRect.Y + minBtnRect.Height) / 2;
            Point p1 = new Point(minBtnRect.X + 30, middleY);
            Point p2 = new Point(minBtnRect.X + minBtnRect.Width - 30, middleY);

            for (int i = p1.X; i < p2.X; i++)
            {
                for (int j = middleY; j < middleY + 20; j++)
                {
                    bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
        }



        private void DrawMinBtnShadow(Bitmap bitmap)
        {
            for (int i = minBtnRect.X; i < minBtnRect.X + minBtnRect.Width; i++)
            {
                for (int j = minBtnRect.Y; j < minBtnRect.Y + minBtnRect.Height; j++)
                {
                    Color color = bitmap.GetPixel(i, j);
                    int R = color.R + 70;
                    if (R > 255) R = 255;

                    int G = color.G + 70;
                    if (G > 255) G = 255;

                    int B = color.B + 70;
                    if (B > 255) B = 255;

                    bitmap.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }
        }

        
        #endregion

        bool IsDrawMinBtnShadow = false;
        #region 鼠标划过最小按钮的事件
        private void MouseMoveMinBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(MinBtnRectGraphics.Contains(p))
            {
                if (IsDrawMinBtnShadow == true) return;
                handlePicture += DrawMinBtnShadow;
                IsDrawMinBtnShadow = true;                
            }
            else
            {
                if (IsDrawMinBtnShadow == false) return;
                handlePicture -= DrawMinBtnShadow;
                IsDrawMinBtnShadow = false;
            }
        }
        #endregion
        Rectangle MinBtnRectGraphics = new Rectangle(new Point(462, 0), new Size(34, 34));
        Rectangle CloseBtnRectGraphics = new Rectangle(new Point(496, 0), new Size(34, 34));
        Rectangle SetBtnRectGraphics = new Rectangle(new Point(462, 0), new Size(34, 34));
        #region 鼠标点击最小按钮事件
        private void MouseDonwMinBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(MinBtnRectGraphics.Contains(p))
            {
                this.Hide();
            }
        }
        #endregion

        #region 画关闭按钮 
        private void DrawCloseBtn(Bitmap bitmap)
        {
            Graphics g = Graphics.FromImage(bitmap);
            Point p1 = new Point(closeBtnRect.X + 20, closeBtnRect.Y +  75);
            Point p2 = new Point(closeBtnRect.X + closeBtnRect.Width - 20,
                                 closeBtnRect.Y + closeBtnRect.Height - 75);
            Point p3 = new Point(closeBtnRect.X + closeBtnRect.Width -20 , 75);
            Point p4 = new Point(closeBtnRect.X + 20, closeBtnRect.Height - 75);
            g.DrawLine(new Pen(Brushes.White, 7), p1, p2);
            g.DrawLine(new Pen(Brushes.White, 7), p3, p4);
        }
        #endregion

        #region 画设置按钮
        private void DrawSetBtn(Bitmap bitmap)
        {
            //for (int i = setBtnRect.X; i < setBtnRect.X + closeBtnRect.Width; i++)
            //{
            //    for (int j = setBtnRect.Y; j < setBtnRect.Y + closeBtnRect.Height; j++)
            //    {
            //        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
            //    }
            //}
        }
        #endregion

        KeyboardFrm keyboardFrm;
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
