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
        #endregion

        #region Init
        public LogFrm()
        {
            InitializeComponent();
            FrmInit();
            ControlInit();
            InitVar();
        }

        private void FrmInit()
        {
            this.Size = new Size(538, 330);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
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

    }
}
