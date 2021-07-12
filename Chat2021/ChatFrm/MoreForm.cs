using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Chat2021.win32api;

namespace Chat2021
{
    public partial class MoreForm : Form
    {
        #region value

        MoreContentForm MoreContentForm;

        #endregion

        #region 初始化
        public MoreForm(Form pFrom)
        {
            InitializeComponent();
            InitFormParameter(pFrom);
            InitSonFormParameter(pFrom);
            SetFormHandler();
            
        }

        private void SetFormHandler()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayTextForm_Paint);
        }


        private void DisplayTextForm_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void InitFormParameter(Form pForm)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new Size(130, 250);
            this.BackColor = Color.FromArgb(119, 136, 153);
            this.ShowInTaskbar = false;
            uint ExdStyle = Win32.GetWindowLong(this.Handle, Win32.GWL_EXSTYLE);
            Win32.SetWindowLong(this.Handle, Win32.GWL_EXSTYLE, Win32.WS_EX_TRANSPARENT | Win32.WS_EX_LAYERED);
            Win32.SetLayeredWindowAttributes(this.Handle, 0x000000, 120, 3);

            
            this.Location = new Point(1137, 259);
            this.TopMost = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            MoreContentForm.Close();
        }

        private void InitSonFormParameter(Form pForm)
        {
            MoreContentForm = new MoreContentForm(this);
            MoreContentForm.Location = new Point(1137, 259); 
            MoreContentForm.Size = this.Size;
        }

        public void SetFormVisble()
        {
            if(this == null)
            {
                return;
            }

            this.Show();
            MoreContentForm.SetVisible() ;
        }

        
        #endregion

    }
}
