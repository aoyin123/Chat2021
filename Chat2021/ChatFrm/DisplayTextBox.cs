using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.ChatFrm
{
    class DisplayTextBox : TextBox
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        //禁止焦点
        private static extern bool HideCaret(IntPtr hWnd);

        public DisplayTextBox()
        {
            this.BorderStyle = BorderStyle.None;
            this.Visible = false;
            this.ReadOnly = true;
            this.BackColor = Color.White;
            this.MouseEnter += tBox_Data2txt_MouseEnter;
            this.MouseDown += tBox_Data2txt_MouseDown;
            this.Size = new Size(684, 40);
        }

        private void tBox_Data2txt_MouseEnter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HideCaret(textBox.Handle);
        }

        private void tBox_Data2txt_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            HideCaret(textBox.Handle);
        }

    }
}
