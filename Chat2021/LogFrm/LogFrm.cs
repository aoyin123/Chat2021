﻿using System;
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
        Rectangle closeBtnRect = new Rectangle(new Point(1840, 0), new Size(135,  200));
        Rectangle setBtnRect = new Rectangle(new Point(1570, 0), new Size(135, 300));
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
        }

        private void FrmInit()
        {
            this.Size = new Size(538, 330);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            this.ShowInTaskbar = false;
            System.IntPtr iconHandle = Resource1.Chat2021.GetHicon();
            System.Drawing.Icon icon = Icon.FromHandle(iconHandle);
            this.notifyIcon1.Icon = icon;
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
            //PlayVedioPic.MouseMove += MouseMoveCloseBtn;
            //PlayVedioPic.MouseDown += MouseDownCloseBtn;


            //设置设置按钮事件
            //PlayVedioPic.MouseMove += MouseMoveSetBtn;
            //PlayVedioPic.MouseDown += MouseDownSetBtn;
        }

        private void ControlInit()
        {
            PlayVedioPic.Width = this.Width;
            PlayVedioPic.Height = 125;
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
            //int middleY = (closeBtnRect.Y + closeBtnRect.Height) / 2;
            //Point p1 = new Point(closeBtnRect.X, middleY);
            //Point p2 = new Point(closeBtnRect.X + closeBtnRect.Width, middleY);

            //for(int i = p1.X; i< p2.X; i++)
            //{
            //    for (int j = middleY; j < middleY + 50; j++)
            //    {
            //        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
            //    }
            //}

            //for(int i = 0; i < 300; i++)
            //{
            //    for(int j = 0; j < 300; j++)
            //    {
            //        Color color = bitmap.GetPixel(i, j);
            //        int R = color.R + 70;
            //        if (R > 255) R = 255;

            //        int G = color.G + 70;
            //        if (G > 255) G = 255;

            //        int B = color.B + 70;
            //        if (B > 255) B = 255;

            //        bitmap.SetPixel(i, j, Color.FromArgb(R, G, B));
                //}
            //}
            
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

        

    }
}
