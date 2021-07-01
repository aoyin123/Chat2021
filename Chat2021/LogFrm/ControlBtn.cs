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
        #region 初始化
        public ControlBtn(Point point,Size size)
        {
            InitializeComponent();
            SetFromStyle(point, size);
        }

        private void SetFromStyle(Point point, Size size)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = point;
            this.Size = size;
            
        }
        #endregion
    }
}
