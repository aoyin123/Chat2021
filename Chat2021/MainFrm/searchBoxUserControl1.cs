using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    public partial class searchBoxUserControl1 : UserControl
    {
        public searchBoxUserControl1()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(82, 157, 212);
            this.Size = new Size(341, 41);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Size = new Size(341, 41);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);
            Rectangle rect = new Rectangle(15, 11, 15, 15);
            Point startPos = new Point(32, 28);
            Point endPos = new Point(28, 23);
            string hint = "搜索";
            Font font = new Font("宋体", 9);
            Point hintPos = new Point(42, 13);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawEllipse(pen, rect);
            g.DrawLine(pen, startPos, endPos);
            g.DrawString(hint, font, Brushes.Black, hintPos);
        }
    }
}
