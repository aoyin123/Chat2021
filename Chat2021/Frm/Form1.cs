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

namespace Chat2021.Frm
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
  
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
 
        private const int VM_NCLBUTTONDOWN = 0XA1;//定义鼠标左键按下
        private const int HTCAPTION = 2;
        private MiniFrmBtn miniFrmBtn;
        public delegate void myDelegate();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.splitContainer1.Panel1.Controls.Add(this.chatListBox1);
            this.splitContainer1.SplitterDistance = this.Width;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.BackColor = Color.Red;
            this.splitContainer1.Panel2.BackColor = Color.Black;
            this.splitContainer1.SplitterDistance = this.Width;
            this.chatListBox1.Width = this.Width;
            this.chatListBox1.Location = new Point(0, 0);
            this.MouseDown += panel1_MouseDown;
            //this.pictureBox1.MouseDown += panel1_MouseDown;
            this.label1.Location = new Point(102, 85);
            this.label1.BackColor = Color.Transparent;
            this.textBox1.Location = this.label1.Location;
            this.miniFrmBtn = new MiniFrmBtn();
            this.LocationChanged += MoveMiniFrmBtn;

            
            


        }

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

        private void MoveMiniFrmBtn(object sender, EventArgs e)
        {
            Point p = this.Location;
            miniFrmBtn.Location = new Point(this.Location.X, this.Location.Y + 20);
        }

        int n = 0;
        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //为当前应用程序释放鼠标捕获
            ReleaseCapture();
            //发送消息 让系统误以为在标题栏上按下鼠标
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
            this.miniFrmBtn.Location = new Point(this.miniFrmBtn.Location.X + 2, this.miniFrmBtn.Location.Y + 2);
            n = n + 1;
            label1.Text = n.ToString();
            this.miniFrmBtn.TopMost = true;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {

        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern int SetWindowPos(IntPtr hwnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        public static int GetWindowZOrder(IntPtr hwnd)
        {
            const uint GW_HWNDPREV = 3;
            const uint GW_HWNDLAST = 1;

            var lowestHwnd = GetWindow(hwnd, GW_HWNDLAST);

            var z = 0;
            var hwndTmp = lowestHwnd;
            while (hwndTmp != IntPtr.Zero)
            {
                if (hwnd == hwndTmp)
                {
                    
                    return z;
                }

                hwndTmp = GetWindow(hwndTmp, GW_HWNDPREV);
                z++;
            }

            
            return -1;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.searchBoxUserControl11.Location = new Point(0, this.frmSwitchUserControl1.Location.Y - this.searchBoxUserControl11.Size.Height);
            this.miniFrmBtn.Location = new Point(this.Location.X, this.Location.Y + 20);
            this.Show();
            this.miniFrmBtn.Show(this);
            //this.miniFrmBtn.TopMost = true;
            //this.pictureBox1.Location = new Point(0, 0);
            //this.pictureBox1.Size = new Size(this.Width, this.searchBoxUserControl11.Location.Y);
            //this.miniFrmBtn.TopLevel = false;
            
            //this.miniFrmBtn.Parent = this;
            SetWindowPos(this.Handle, this.miniFrmBtn.Handle, 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0080);
            this.Invalidate();
            Thread t = new Thread(SetWindowTopMost);
            t.IsBackground = true;
            t.Start();
            //int order1, order2;
            //GetWindowZOrder(this.Handle);
            //GetWindowZOrder(this.miniFrmBtn.Handle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.frmSwitchUserControl1.Size = new Size(this.Width, 41);
            this.frmSwitchUserControl1.Location = new Point(0, this.splitContainer1.Location.Y - 41);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Size size = new Size(this.Width, this.searchBoxUserControl11.Location.Y);
            Bitmap bitmap = Resource1.background;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            //创建矩形对象表示原图上裁剪的矩形区域，这里相当于划定原图上坐标为(10, 10)处，50x50大小的矩形区域为裁剪区域
            Rectangle cropRegion = new Rectangle(0, 0, size.Width, size.Height);
            //创建空白画布，大小为裁剪区域大小
            Bitmap result = new Bitmap(cropRegion.Width, cropRegion.Height);
            //创建Graphics对象，并指定要在result（目标图片画布）上绘制图像
            Graphics graphics = Graphics.FromImage(result);
            //使用Graphics对象把原图指定区域图像裁剪下来并填充进刚刚创建的空白画布
            graphics.DrawImage(bitmap, new Rectangle(0, 0, cropRegion.Width, cropRegion.Height), cropRegion, GraphicsUnit.Pixel);
            //Graphics g1 = pictureBox1.CreateGraphics();
            //g1.DrawImage(result, new Point(0, 0));
            //this.pictureBox1.Image = result;
            //这个时候裁剪区域图片就被填充进result对象中去了，可以对其进行保存
            g.DrawImage(result, new Point(0, 0));

            g.DrawImage(Resource1.mm, new Rectangle(14, 43, 70, 70));

            g.DrawString("IIIIIIIIIIII", new Font("宋体", 12), Brushes.White, new Point(102, 58));
            g.DrawString("Lv57", new Font("宋体", 7), new SolidBrush(Color.Red), new Point(234, 65));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.textBox1.Visible = true;
            this.textBox1.Focus();
            this.label1.Visible = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            this.textBox1.Visible = false;
            this.label1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
