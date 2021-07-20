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
        private ChatIemCollection chatItemCollection = null;
        private int sliderVal = 0;
        private Slider slider;
        private TextBox textBox;
        #endregion

        #region 初始化
        public ChatListBox(TextBox textBox)
        {
            chatItemCollection = new ChatIemCollection();
            this.BackColor = Color.White;
            this.textBox = textBox;
            ChatItem.Width = this.Width;
            ChatItem.Height = 50;
            ChatItem.UserNamePos = new Point(30, 0);
            ChatItem.ExtraMsgPos = new Point(30, 15);
            ChatItem chatItem = new ChatItem("niao",Resource1._11,"hello", "ff");
            ChatItem.UserNameFont = new Font("宋体", 10);
            chatItemCollection[0] = chatItem;

            ChatItem chatItem_1 = new ChatItem("niao", Resource1._11, "hello", "ff");
            chatItemCollection[1] = chatItem_1;

            ChatItem chatItem_2 = new ChatItem("niao", Resource1._11, "hello", "ff");
            chatItemCollection[2] = chatItem_2;

            for(int i = 3; i < 40; i++)
            {
                chatItemCollection[i] = new ChatItem("niao", Resource1._11, "hello", "ff");
            }

            ChatItem.Height = 30;

            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormMouseWheel);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(SliderMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(SliderMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(SliderMouseUp);

            this.MouseMove += new System.Windows.Forms.MouseEventHandler(ItemMouseMove);
            this.MouseLeave += new EventHandler(ItemMouseLeave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(ItemMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(ItemMouseUp);

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private int mouseMoveItemIndex = 0;
        private int mouseDownItemIndex = 0;

        private void ItemMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            int index = (mousePos.Y + sliderVal) / ChatItem.Height;
            chatItemCollection[mouseMoveItemIndex].IsMouseHover = false;
            chatItemCollection[index].IsMouseHover = true;
            mouseMoveItemIndex = index;
            this.Invalidate();
        }

        private void ItemMouseLeave(object sender, EventArgs e)
        {

        }

        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            int index = (mousePos.Y + sliderVal) / ChatItem.Height;
            chatItemCollection[index].IsPressed = true;
            chatItemCollection[mouseDownItemIndex].IsPressed = false;
            mouseDownItemIndex = index;
            this.Invalidate();
        }

        private void ItemMouseUp(object sender, MouseEventArgs e)
        {
            //chatItemCollection[mouseDownItemIndex].IsPressed = false;
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
            double diffY, slideSpace, distance;
            if (isMouseDownOnSlider == true)
            {
                diffY = mousePos.Y - e.Location.Y;
                mousePos = e.Location;

                slideSpace = this.Height - slider.Height;
                distance = (1200 - this.Height) / slideSpace * diffY;
                
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
                baseY = i * ChatItem.Height;
                if(true == chatItemCollection[i].IsMouseHover)
                {
                    SolidBrush solidBrush = new SolidBrush(chatItemCollection[i].MouseHoverBackColor);
                    g.FillRectangle(solidBrush, new Rectangle(0, baseY, this.Width, ChatItem.Height));
                }
                if(true == chatItemCollection[i].IsPressed)
                {
                    SolidBrush solidBrush = new SolidBrush(chatItemCollection[i].MousePressedColor);
                    g.FillRectangle(solidBrush, new Rectangle(0, baseY, this.Width, ChatItem.Height));
                }

                g.DrawImage(chatItemCollection[i].Icon, GetPointByModifyHeight(ChatItem.IconPos, baseY));
                g.DrawString(chatItemCollection[i].UserName, ChatItem.UserNameFont,Brushes.Black, GetPointByModifyHeight(ChatItem.UserNamePos, baseY));
                g.DrawString(chatItemCollection[i].ExtraMsg, ChatItem.UserNameFont, Brushes.Black, GetPointByModifyHeight(ChatItem.ExtraMsgPos, baseY));
                g.DrawString(i.ToString(), ChatItem.UserNameFont, Brushes.Black, GetPointByModifyHeight(ChatItem.ExtraMsgPos, baseY));
                g.DrawString(sliderVal.ToString(), new Font("宋体", 10), Brushes.Black, new Point(0, 0));
                g.FillPath(new SolidBrush(slider.BackColor), slider.Path);
            }
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
