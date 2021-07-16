using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using keyboard;
namespace Chat2021.LogFrm
{
    public partial class KeyboardFrm : Form
    {
        KeyboardUserControl keyboard;

        public KeyboardFrm(System.Windows.Controls.TextBox textBox)
        {
            InitializeComponent();
            keyboard = new KeyboardUserControl(textBox);
            textBox.Text = "123";
            this.FormBorderStyle = FormBorderStyle.None;
            keyboard.Location = new Point(0, 0);
            keyboard.BackColor = Color.FromArgb(27, 147, 217);
            keyboard.Size = new Size(448, 138);
            this.Size = keyboard.Size;
            this.StartPosition = FormStartPosition.Manual;
            this.Controls.Add(keyboard);
        }
    }
}
