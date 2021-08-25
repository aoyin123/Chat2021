using System;
using System.Drawing;
using System.Windows.Forms;
using Chat2021.ss;
using Chat2021.Mysql;
using Chat2021.ChatFrm;
using Chat2021.Network;

namespace WindowsFormsApp3
{
    class MsgBox : Control
    {
        #region field
        private ChatHistory chatHistory;
        private Slider slider;
        private Mysql mysql = Mysql.getInstance();
        private DisplayTextBox[,] textBoxes;
        private Receiver receiver = Receiver.GetInstance();
        #endregion

        #region construct
        public MsgBox()
        {
            mysql.Connect();

            chatHistory = new ChatHistory(mysql);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.BackColor = Color.White;

            Control.CheckForIllegalCrossThreadCalls = false;

            receiver.DataArrive += new ModifyStructEventHandler(AddMsg);
        }
        #endregion

        #region event
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            slider.Draw(e.Graphics);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta > 0)
            {
                slider.Up();

            }
            else
            {
                slider.Down();
            }

            DisplayMsg();
        }
        #endregion

        #region method

        private void AddMsg(ModifyStructEventArgs e)
        {
            string head = e.modifyStruct.head;
            string msg = e.modifyStruct.msg;
            LayoutItem layoutItem = new LayoutItem(head, msg);
            chatHistory.Add(layoutItem);

            slider.DisplayContentLength = GetStretchLength();
            slider.SetSliderOnBottom();
            DisplayMsg();
        }

        private int CalculateMaxContainsTextBoxNum()
        {
            double height = 15;
            double row = this.Height / height;

            return (int)Math.Ceiling(row);
        }

        private int GetStretchLength()
        {
            int lastItemIndex = chatHistory.Count - 1;
            int len = chatHistory[lastItemIndex].msgPos.Y + chatHistory[lastItemIndex].msgSize.Height - this.Height;
            return len;
        }

        protected override void InitLayout()
        {
            base.InitLayout();

            Size sliderSize = new Size(10, 50);
            Point sliderPos = new Point(this.Width - sliderSize.Width, 0);
            slider = new Slider(sliderPos, sliderSize, this);
            slider.DisplayContentLength = GetStretchLength();

            textBoxes = new DisplayTextBox[14, 2];
            InitTextBox();

            SetSliderBottom();
            DisplayMsg();
        }

        private void InitTextBox()
        {
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    textBoxes[i, j] = new DisplayTextBox();
                    this.Controls.Add(textBoxes[i, j]);
                }
                textBoxes[i, 0].ForeColor = Color.FromArgb(36, 129, 110);
                textBoxes[i, 1].ForeColor = Color.FromArgb(130, 86, 113);
            }
        }


        public void SetSliderBottom()
        {
            slider.SetSliderOnBottom();
        }

        private void SetAllTextBoxInvisble()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    textBoxes[i, j].Visible = false;
                }
            }
        }




        private void DisplayMsg()
        {
            int sumTbxVisbleCount = 0;
            int end, top;

            SetAllTextBoxInvisble();

            for (int i = 0; i < chatHistory.Count; i++)
            {
                end = chatHistory[i].headPos.Y + chatHistory[i].headSize.Height;
                top = chatHistory[i].headPos.Y;

                if (IsDispalyTbx(end, top) == true)
                {
                    //显示消息标签
                    textBoxes[sumTbxVisbleCount, 0].Location = new Point(chatHistory[i].headPos.X, chatHistory[i].headPos.Y - slider.SliderVal);
                    textBoxes[sumTbxVisbleCount, 0].Text = chatHistory[i].tag;
                    textBoxes[sumTbxVisbleCount, 0].Visible = true;

                    //显示消息
                    textBoxes[sumTbxVisbleCount, 1].Location = new Point(chatHistory[i].msgPos.X, chatHistory[i].msgPos.Y - slider.SliderVal);
                    textBoxes[sumTbxVisbleCount, 1].Text = chatHistory[i].msg;
                    textBoxes[sumTbxVisbleCount, 1].Visible = true;

                    sumTbxVisbleCount++;
                }
            }

        }

        private bool IsDispalyTbx(int tbxBottom, int tbxTop)
        {
            if ((tbxBottom > slider.SliderVal) && (tbxBottom < slider.SliderVal + Height))
            {
                return true;
            }
            else if ((tbxTop > slider.SliderVal) && (tbxTop < slider.SliderVal + Height))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
