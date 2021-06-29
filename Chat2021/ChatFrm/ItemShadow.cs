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
    public partial class ItemShadow : Form
    {
        #region 初始化
        public ItemShadow()
        {
            InitializeComponent();
            SetFormStyle();
        }

        private void SetFormStyle()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Size = new Size(200, 200);
            this.BackColor = Color.Red;;
            this.ShowInTaskbar = false;
            uint ExdStyle = win32.GetWindowLong(this.Handle, win32.GWL_EXSTYLE);
            win32.SetWindowLong(this.Handle, win32.GWL_EXSTYLE, win32.WS_EX_TRANSPARENT | win32.WS_EX_LAYERED);
            win32.SetLayeredWindowAttributes(this.Handle, 0XFFFFFF, 120, 3);
        }
        #endregion
    }
}
