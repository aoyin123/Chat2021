using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.Paint += DrawMiniButton;
        }

        private void DrawMiniButton(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen1 = new Pen(Color.FromArgb(112, 122, 124), 1);
            Pen pen2 = new Pen(Color.FromArgb(146, 159, 165), 1);

            g.DrawLine(pen1, new Point(10, 10), new Point(30, 10));
            g.DrawLine(pen2, new Point(10, 11), new Point(30, 11));
            //g.DrawLine(pen1, new Point(0, 0), new Point(13, 13));
            //g.DrawLine(pen2, new Point(1, 1), new Point(14, 14));
            //g.DrawLine(pen1, new Point(0, 13), new Point(13, 0));
            DrawRectPixel(g, new Point(0, 0), 13);
            pen1.Dispose();
            pen2.Dispose();
            
        }

        private void DrawRectPixel(Graphics g, Point startPos, int count)
        {
            int x = startPos.X;
            int y = startPos.Y;

            for (int i = 0; i < 13; i++)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(137, 145, 147)), new Rectangle(x, y, 1, 1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(146, 154, 156)), new Rectangle(x + 1, y, 1, 1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(194, 202, 204)), new Rectangle(x, y + 1, 1, 1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(118, 126, 128)), new Rectangle(x + 1, y + 1, 1, 1));
                x += 1;
                y += 1;
            }
            //g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(146, 154, 156))), new Point(1, 0), new Point(1, 0));
            //g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(118, 126, 128))), new Point(0, 1), new Point(0, 1));
            //g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(140, 148, 150))), new Point(1, 1), new Point(1, 1));
        }
        
    }
}
