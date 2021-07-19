using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    class ChatListBox : Control
    {
        #region 变量
        private ChatIemCollection chatIemCollection = null;
        private int sliderVal = 0;
        private Slider slider;
        private TextBox textBox;
        #endregion

        #region 初始化
        public ChatListBox(TextBox textBox)
        {
            chatIemCollection = new ChatIemCollection();
            this.BackColor = Color.White;
            this.textBox = textBox;
            ChatItem.Width = this.Width;
            ChatItem.Height = 50;
            ChatItem.UserNamePos = new Point(30, 0);
            ChatItem.ExtraMsgPos = new Point(30, 15);
            ChatItem chatItem = new ChatItem("niao",Resource1._11,"hello", "ff");
            ChatItem.UserNameFont = new Font("宋体", 10);
            chatIemCollection[0] = chatItem;

            ChatItem chatItem_1 = new ChatItem("niao", Resource1._11, "hello", "ff");
            chatIemCollection[1] = chatItem_1;

            ChatItem chatItem_2 = new ChatItem("niao", Resource1._11, "hello", "ff");
            chatIemCollection[2] = chatItem_2;

            for(int i = 3; i < 40; i++)
            {
                chatIemCollection[i] = new ChatItem("niao", Resource1._11, "hello", "ff");
            }

            ChatItem.Height = 30;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormMouseWheel);
            this.MouseDown += SliderMouseDown;
            this.MouseMove += SliderMouseMove;
            this.MouseUp += SliderMouseUp;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲



        }

        bool isMouseDownOnSlider = false;
        Point mousePos;
        private void SliderMouseDown(object sender, MouseEventArgs e)
        {
            Point sliderToChatListBox = new Point(slider.Pos.X, slider.Pos.Y - sliderVal);
            Rectangle rect = new Rectangle(sliderToChatListBox, new Size(slider.Width, slider.Height));
            if(rect.Contains(e.Location))
            {
                isMouseDownOnSlider = true;
                mousePos = e.Location;
            }
        }

        private void SliderMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDownOnSlider == true)
            {
                double diffY = mousePos.Y - e.Location.Y;
                mousePos = e.Location;

                double slideSpace = this.Height - slider.Height;
                double distance = (1200 - this.Height) / slideSpace * diffY;
                
                sliderVal -= (int)distance;
                if(sliderVal < 0)
                {
                    sliderVal = 0; 
                }
                else if(sliderVal > 1200)
                {
                    sliderVal = 1200;
                }
                slider.Pos = new Point(slider.Pos.X, (int)(slider.Pos.Y - diffY - distance));//sliderPos决定了滑块的位置，sliderValue决定了ITem以及滑块的位置
                textBox.Text = distance.ToString();
                if(slider.Pos.Y - diffY < sliderVal)
                {
                    slider.Pos = new Point(slider.Pos.X, sliderVal);
                }
                else if((slider.Pos.Y - diffY) > (sliderVal + this.Height - slider.Height))
                {
                    slider.Pos = new Point(slider.Pos.X, sliderVal + this.Height - slider.Height);
                }

                this.Invalidate(slider.SliderWay);
                this.Invalidate();
                
            }
            else
            {

            }

        }

        private void SliderMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnSlider = false;
        }


        protected override void InitLayout()
        {
            base.InitLayout();
            slider = new Slider(new Point(this.Width - 10,  0), new Size(10, 50));
            slider.OwnerChatListBox = this;
        }
        #endregion

        #region 绘图
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(0, -sliderVal);
            int baseY;
            for(int i = 0; i < 40;i++)
            {
                if(i == 39)
                {

                }
                baseY = i * ChatItem.Height;
                g.DrawImage(chatIemCollection[i].Icon, GetPointByModifyHeight(ChatItem.IconPos, baseY));
                g.DrawString(chatIemCollection[i].UserName, ChatItem.UserNameFont,Brushes.Black, GetPointByModifyHeight(ChatItem.UserNamePos, baseY));
                g.DrawString(chatIemCollection[i].ExtraMsg, ChatItem.UserNameFont, Brushes.Black, GetPointByModifyHeight(ChatItem.ExtraMsgPos, baseY));
                g.DrawString(i.ToString(), ChatItem.UserNameFont, Brushes.Black, GetPointByModifyHeight(ChatItem.ExtraMsgPos, baseY));
                g.DrawString(sliderVal.ToString(), new Font("宋体", 10), Brushes.Black, new Point(0, 0));
                //g.DrawPath(new Pen(Brushes.Black), slider.Path);
                
                g.FillPath(new SolidBrush(slider.BackColor), slider.Path);
            }
            //g.DrawString("a", new Font("宋体", 10), Brushes.Black, new Point(0, 1200));
        }

        

        private void FormMouseWheel(object sender, MouseEventArgs e)
        {
            double sumLength = 1200 - this.Height;
            int sliderY = 0;
            if (e.Delta > 0)
            {
                sliderVal = sliderVal - 15;
                if (sliderVal < 0) //向上滑动
                {
                    sliderVal = 0;
                }
                sliderY = (int)((sliderVal / sumLength) * (this.Height - slider.Height));
                slider.Pos = new Point(this.Width - 10, sliderY + sliderVal);
            }
            else if(e.Delta < 0) // 向下滑动
            {
                sliderVal = sliderVal + 15;
                if(sliderVal > sumLength)
                {
                    sliderVal = (int)sumLength;
                }
                sliderY = (int)((sliderVal / sumLength) * (this.Height - slider.Height));
                slider.Pos = new Point(this.Width - 10, sliderY + sliderVal);
            }
            this.Invalidate();

        }



        private Point GetPointByModifyHeight(Point p, int height)
        {
            return new Point(p.X, p.Y + height);
        }
        #endregion
    }
}
