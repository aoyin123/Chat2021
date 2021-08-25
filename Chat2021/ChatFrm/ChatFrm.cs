using System;
using System.Drawing;
using System.Windows.Forms;
using Chat2021.win32api;

namespace Chat2021.ChatFrm
{
    public partial class ChatFrm : Form
    {
        #region property

        //关闭按钮，最大化按钮，最小化按钮，窗口设置按钮
        private Chat2021.Mysql.Mysql mySql = Chat2021.Mysql.Mysql.getInstance();

        
        private enum MouseFlag
        {
            onMenuItem1,
            onMenuItem2,
            onMenuItem3,
            onMenuItem4,
            onMenuItem5,
            onMenuItem6,
            onMenuItem7,
            onMenuItem8,
            none
        }
        private bool isMousePresed = false;
        #endregion

        #region Construct
        public ChatFrm()
        {
            InitializeComponent();

            this.pictureBox1.Paint += displayUserName;
        }


        #endregion

        #region Event

        private void displayUserName(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString("刘奇", new Font("宋体", 15), Brushes.Black, new Point(300, 10));
        }

        private void ChatFrm_SizeChanged(object sender, EventArgs e)
        {
            this.pictureBox1.Size = new Size(this.Width, 50);
            this.pictureBox1.BackColor = Color.Red;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendMsg_Click(object sender, EventArgs e)
        {
            string msg, time, head;

            msg = inputTextBox.Text;

            if (null == msg)
            {
                return;
            }

            time = DateTime.Now.ToUniversalTime().ToString();
            head = "刘奇" + " " + time;

            bool result = mySql.addMsg(msg, head);

            if (true == result)
            {
                inputTextBox.Text = "";
                msgBox1.SetSliderBottom();
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage((IntPtr)this.Handle, Win32.VM_NCLBUTTONDOWN, Win32.HTCAPTION, 0);
        }

        #endregion


    }
}
