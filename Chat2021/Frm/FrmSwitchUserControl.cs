using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace Chat2021.Frm
{
    public partial class FrmSwitchUserControl : UserControl
    {
        private Hashtable nameToSize = new Hashtable();
        private Font font = new Font("思源宋体", 10);
        private String mouseMoveBtnName;
        private string mouseDownBtnName;

        public FrmSwitchUserControl()
        {
            InitializeComponent();
            this.msgswtBtn.MouseDown += mouseDown;
            this.contactsBtn.MouseDown += mouseDown;
            this.spaceBtn.MouseDown += mouseDown;

            this.msgswtBtn.MouseMove += mouseMove;
            this.contactsBtn.MouseMove += mouseMove;
            this.spaceBtn.MouseMove += mouseMove;
            this.msgswtBtn.MouseLeave += mouseLeave;
            this.contactsBtn.MouseLeave += mouseLeave;
            this.spaceBtn.MouseLeave += mouseLeave;

            this.spaceBtn.Paint += DrawString;
            this.msgswtBtn.Paint += DrawString;
            this.contactsBtn.Paint += DrawString;
            this.spaceBtn.FlatStyle = this.contactsBtn.FlatStyle = this.msgswtBtn.FlatStyle = FlatStyle.Flat;
            this.msgswtBtn.FlatAppearance.MouseOverBackColor = Color.White;
            this.contactsBtn.FlatAppearance.MouseOverBackColor = Color.White;
            this.spaceBtn.FlatAppearance.MouseOverBackColor = Color.White;
            this.msgswtBtn.FlatAppearance.MouseDownBackColor = Color.White;
            this.contactsBtn.FlatAppearance.MouseDownBackColor = Color.White;
            this.spaceBtn.FlatAppearance.MouseDownBackColor = Color.White;
            this.spaceBtn.FlatAppearance.BorderSize = this.contactsBtn.FlatAppearance.BorderSize =
                                                        this.msgswtBtn.FlatAppearance.BorderSize = 0;

            nameToSize.Add("消息", new SizeF());
            nameToSize.Add("联系人", new SizeF());
            nameToSize.Add("空间", new SizeF());
        }

        private  void mouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            //btn.Paint += DrawUnderLine;   
            mouseDownBtnName = (string)btn.Tag;
            
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            mouseMoveBtnName = (string)btn.Tag;
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            mouseMoveBtnName = "";
        }

        private void DrawUnderLine(object sender,  PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(103, 120, 138));
            Pen pen = new Pen(solidBrush);
            Point startPos = new Point(btn.Width / 14, btn.Height);
            Point endPos = new Point(btn.Width - btn.Width / 14, btn.Height);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawLine(pen, new Point(0, 0), new Point(btn.Width , btn.Height));

            btn.Paint -= DrawUnderLine;
        }

        private void DrawString(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            Point strPos = new Point();
            SizeF strSize = (SizeF)nameToSize[btn.Tag];
            SolidBrush solidBrush;

            if ((string)btn.Tag == mouseDownBtnName)
            {
                SolidBrush sBru = new SolidBrush(Color.FromArgb(103, 120, 138));
                Pen pen = new Pen(sBru, 2);
                Point startPos = new Point(btn.Width / 14, btn.Height - 2);
                Point endPos = new Point(btn.Width - btn.Width / 14, btn.Height - 2);
                g.DrawLine(pen, startPos, endPos);
                solidBrush = sBru;
            }
            else if ((string)btn.Tag == mouseMoveBtnName)
            {
                solidBrush = new SolidBrush(Color.Black);
            }
            else
            {
                solidBrush = new SolidBrush(Color.FromArgb(86, 105, 125));
            }

            strPos.X = (btn.Width - (int)strSize.Width) / 2;
            strPos.Y = (btn.Height - (int)strSize.Height) / 2;

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawString((string)btn.Tag, font, solidBrush, strPos);

            
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Graphics g = msgswtBtn.CreateGraphics();
            StringFormat sf = new StringFormat();

            msgswtBtn.Width = contactsBtn.Width = spaceBtn.Width = this.Width / 3;
            msgswtBtn.Height = contactsBtn.Height = spaceBtn.Height = this.Height;

            
            
            g.PageUnit = GraphicsUnit.Pixel;
            g.SmoothingMode = SmoothingMode.HighQuality;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            //foreach(var name in nameToSize.ToArray())
            //{
            //    nameToSize[name] = g.MeasureString(name, font, 500, sf);
            //}
            ArrayList akeys = new ArrayList(nameToSize.Keys);
            foreach(string name in akeys)
            {
                nameToSize[name] = g.MeasureString(name, font, 500, sf);
            }
        }
    }
}
