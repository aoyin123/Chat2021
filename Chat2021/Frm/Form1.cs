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
        private Rectangle iconRect = new Rectangle(14, 43, 70, 70);

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            this.splitContainer1.Panel1.Controls.Add(this.chatListBox1);
            this.splitContainer1.Panel2Collapsed = true;
            this.chatListBox1.Width = this.Width;
            this.chatListBox1.Location = new Point(0, 0);
            this.MouseDown += MoveFrm;
            this.MouseMove += ChangeMouseStyle;
            this.label1.Location = new Point(102, 85);
            this.label1.BackColor = Color.Transparent;
            this.textBox1.Location = this.label1.Location;
            this.miniFrmBtn = new MiniFrmBtn();
            this.LocationChanged += MoveMiniFrmBtn;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void DrawAperture()
        {
            Graphics g = this.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(new Pen(Color.FromArgb(124, 139, 160), 2), new Rectangle(14, 43, 70, 70));
        }

        bool isCursorsStyleIsHand = false;
        private void ChangeMouseStyle(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            bool isRecover = false;
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

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFrm(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage((IntPtr)this.Handle, VM_NCLBUTTONDOWN, HTCAPTION, 0);
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
            //this.miniFrmBtn.Show(this);//不加this,miniFrmBtn所呈现的图像会频闪
            
            SetWindowPos(this.Handle, this.miniFrmBtn.Handle, 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0010 | 0x0080); 
            Thread t = new Thread(SetWindowTopMost);
            t.IsBackground = true;
            t.Start();

            this.Invalidate();
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

            g.DrawImage(Resource1.mm, iconRect);

            g.DrawString("IIIIIIIIIIII", new Font("宋体", 12), Brushes.White, new Point(102, 58));
            g.DrawString("Lv57", new Font("宋体", 8, FontStyle.Bold), new SolidBrush(Color.Red), new Point(234, 65));
            
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
