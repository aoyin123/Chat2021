using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.LogFrm
{
    public partial class KeyboardFrm : Form
    {
        public KeyboardFrm(System.Windows.Controls.TextBox textBox)
        {
            InitializeComponent();
            textBox.Text = "123";
            this.FormBorderStyle = FormBorderStyle.None;
            userControl11.Location = new Point(0, 0);
            userControl11.BackColor = Color.FromArgb(27, 147, 217);
            userControl11.Size = new Size(448, 138);
            this.Size = userControl11.Size;

        }
    }
}
