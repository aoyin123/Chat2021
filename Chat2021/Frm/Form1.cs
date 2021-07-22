using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.splitContainer1.Panel1.Controls.Add(this.chatListBox1);
            this.splitContainer1.SplitterDistance = this.Width;
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel1.BackColor = Color.Red;
            this.splitContainer1.Panel2.BackColor = Color.Black;
            this.splitContainer1.SplitterDistance = this.Width;
            this.chatListBox1.Width = this.Width;
            this.chatListBox1.Location = new Point(0, 0);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.frmSwitchUserControl1.Size = new Size(this.Width, 41);
            this.frmSwitchUserControl1.Location = new Point(0, this.splitContainer1.Location.Y - 41);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            
        }
    }
}
