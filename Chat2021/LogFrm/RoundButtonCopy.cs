using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PulseButtonTest
{
    public partial class RoundButtonCopy : Button
    {
        #region -- Members --

        public enum Shape
        {
            Round,
            Rectangle
        }

        #endregion
        public RoundButtonCopy()
        {
            this.BackColor = Color.Blue;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent); 
            Graphics g = pevent.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                RectangleF rect = new Rectangle(new Point(0, 0), this.Size);
                path.AddEllipse(rect);
                path.CloseFigure();
                pevent.Graphics.FillPath(Brushes.Black, path);
            }
            
            //base.OnPaint(pevent);
            this.Text = "123";
            
        }
    }
}
;