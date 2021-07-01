using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat2021.win32api;

namespace Chat2021.LogFrm
{
    public partial class ControlBtn : Form
    {
        Button button;
        #region 初始化
        public ControlBtn(Point point,Size size)
        {
            InitializeComponent();
            SetFromStyle(point, size);
            this.Paint += DrawLine;
            button = new Button();
            button.BackColor = Color.White;
            //this.Controls.Add(button);

            uint ExdStyle = win32.GetWindowLong(this.Handle, win32.GWL_EXSTYLE);
            win32.SetWindowLong(this.Handle, win32.GWL_EXSTYLE, win32.WS_EX_TRANSPARENT | win32.WS_EX_LAYERED);
            win32.SetLayeredWindowAttributes(this.Handle, 0X000000, 125, 3);
        }

        private void SetFromStyle(Point point, Size size)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = point;
            this.Size = size;
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.TopMost = true;
            this.ShowInTaskbar = false;
            
        }

        private void DrawLine(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Brushes.White), this.Location, new Point(200, 200));
        }
        #endregion
    }
}
