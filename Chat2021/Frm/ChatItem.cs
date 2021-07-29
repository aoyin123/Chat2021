using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    struct TitleToItemCollection
    {
        public string title;
        public ChatIemCollection chatIemCollection;
        public bool isDrawItem;
        public Rectangle titleRegion;
        public Point point1;
        public Point point2;
        public Point titlePos;
        public Point basePos;
    }

    class ChatItem : Control
    {
        private TitleToItemCollection[] titleToItemCollection = new TitleToItemCollection[4];
        private Slider slider;
        private int sliderVal = 0;
        private Font titleFont = new Font("宋体", 10);
        private int drawBackGround = -1;
        private int noDrawBackGroundNumber = -1;

        /// <summary>
        /// 获取或设置分组栏的字体
        /// </summary>
        public Font TitleFont
        {
            get
            {
                return titleFont;
            }
            set
            {
                titleFont = value;
            }
        }

        private Brush titleBru = Brushes.Black;
        /// <summary>
        /// 设置或获取画标题的刷子
        /// </summary>
        public Brush TitleBru
        {
            get
            {
                return titleBru;
            }
            set
            {
                titleBru = value;
            }
        }

        private Size titleSize;
        /// <summary>
        /// 设置或获取item的大小
        /// </summary>
        public Size TitleSize
        {
            get
            {
                return titleSize;
            }
            set
            {
                titleSize = value;
            }
        }

        public ChatItem()
        {
            this.BackColor = Color.White;
            titleToItemCollection[0].title = "新朋友";
            titleToItemCollection[0].chatIemCollection = new ChatIemCollection();
            titleToItemCollection[0].isDrawItem = true;
            titleToItemCollection[0].basePos = new Point(0, 0);
       

            titleToItemCollection[1].title = "我的设备";
            titleToItemCollection[1].chatIemCollection = new ChatIemCollection();
            titleToItemCollection[1].isDrawItem = false;

            titleToItemCollection[2].title = "朋友";
            titleToItemCollection[2].chatIemCollection = new ChatIemCollection();
            titleToItemCollection[2].isDrawItem = false;

            titleToItemCollection[3].title = "公众号";
            titleToItemCollection[3].chatIemCollection = new ChatIemCollection();
            titleToItemCollection[3].isDrawItem = false;

            ChatIemCollection chatIemCollection = new ChatIemCollection();
            ChatSubItem.UserNamePos = new Point(30, 0);
            
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(SliderMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(SliderMouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(ItemMouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(SliderMouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormMouseWheel);

            InitItem();

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void SliderMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDownOnSlider = false;
        }

        private void SliderMouseMove(object sender, MouseEventArgs e)
        {
            double diffY, slideSpace, distance;
            if (isMouseDownOnSlider == true)
            {
                diffY = mousePos.Y - e.Location.Y;
                mousePos = e.Location;

                slideSpace = this.Height - slider.Height;
                distance = (sumLength - this.Height) / slideSpace * diffY;

                sliderVal -= (int)distance;
                if (sliderVal < 0)
                {
                    sliderVal = 0;
                }
                else if (sliderVal > sumLength - this.Height)
                {
                    sliderVal = sumLength - Height;
                }
                slider.Pos = new Point(slider.Pos.X, (int)(slider.Pos.Y - diffY - distance));//sliderPos决定了滑块的位置，sliderValue决定了ITem以及滑块的位置
                if (slider.Pos.Y - diffY < sliderVal)
                {
                    slider.Pos = new Point(slider.Pos.X, sliderVal);
                }
                else if ((slider.Pos.Y - diffY) > (sliderVal + this.Height - slider.Height))
                {
                    slider.Pos = new Point(slider.Pos.X, sliderVal + this.Height - slider.Height);
                }
                this.Invalidate();
            }
        }

        private void FormMouseWheel(object sender, MouseEventArgs e)
        {
            double sumLength = this.sumLength - this.Height;
            int sliderY = 0;
            if (e.Delta > 0)
            {
                for (int i = 0; i < 70; i++)
                {
                    sliderVal = sliderVal - 1;
                    if (sliderVal < 0) //向上滑动
                    {
                        sliderVal = 0;
                    }
                    sliderY = (int)((sliderVal / sumLength) * (this.Height - slider.Height));
                    slider.Pos = new Point(this.Width - 10, sliderY + sliderVal);
                    this.Invalidate();
                }
            }
            else if (e.Delta < 0) // 向下滑动
            {
                for (int i = 0; i < 70; i++)
                {
                    sliderVal = sliderVal + 1;
                    if (sliderVal > sumLength)
                    {
                        sliderVal = (int)sumLength;
                    }
                    sliderY = (int)((sliderVal / sumLength) * (this.Height - slider.Height));
                    slider.Pos = new Point(this.Width - 10, sliderY + sliderVal);
                    this.Invalidate();
                }
            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            slider = new Slider(new Point(this.Width - 10, 0), new Size(10, 50));
            slider.OwnerChatListBox = (Control)this;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.TranslateTransform(0, -sliderVal);
            DrawItemBackGround(g);
            DrawItem(g);
        }

        private Point GetPointByModifyHeight(Point p, int height)
        {
            return new Point(p.X, p.Y + height);
        }

        bool isMouseDownOnSlider = false;
        Point mousePos;
        private void SliderMouseDown(object sender, MouseEventArgs e)
        {
            Point sliderToChatListBox = new Point(slider.Pos.X, slider.Pos.Y - sliderVal);
            Rectangle rect = new Rectangle(sliderToChatListBox, new Size(slider.Width, slider.Height));
            if (rect.Contains(e.Location))
            {
                isMouseDownOnSlider = true;
                mousePos = e.Location;
            }
        }

        private void InitItem()
        {
            for (int i = 0; i < 4; i++)
            {
                ChatIemCollection chatItemCollection = titleToItemCollection[i].chatIemCollection;

                ChatSubItem chatItem = new ChatSubItem("糖", Resource1.mm, "糖", "糖糖");
                ChatSubItem.UserNameFont = new Font("宋体", 12);
                ChatSubItem.ExtraMsgFont = new Font("宋体", 9);
                ChatSubItem.ExtraMsgSb = new SolidBrush(Color.FromArgb(117, 117, 117));
                chatItemCollection[0] = chatItem;

                ChatSubItem chatItem_1 = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                chatItemCollection[1] = chatItem_1;

                ChatSubItem chatItem_2 = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                chatItemCollection[2] = chatItem_2;

                for (int f = 3; f < 40; f++)
                {
                    chatItemCollection[f] = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                }
            }
        }

        private int sumLength;
        private void DrawItem(Graphics g)
        {
            int baseHeight = 0;
            int blankHeight = 15;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            for(int i = 0; i < 4; i++)
            {
                titleToItemCollection[i].titleRegion = new Rectangle(0, baseHeight, this.Width, 45);
                baseHeight += blankHeight;
                string title = titleToItemCollection[i].title;
                int baseY = 0;
                ChatIemCollection chatItemCollection = titleToItemCollection[i].chatIemCollection;

                //ChatSubItem chatItem = new ChatSubItem("糖", Resource1.mm, "糖", "糖糖");
                //ChatSubItem.UserNameFont = new Font("宋体", 12);
                //ChatSubItem.ExtraMsgFont = new Font("宋体", 9);
                //ChatSubItem.ExtraMsgSb = new SolidBrush(Color.FromArgb(117, 117, 117));
                //chatItemCollection[0] = chatItem;

                //ChatSubItem chatItem_1 = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                //chatItemCollection[1] = chatItem_1;

                //ChatSubItem chatItem_2 = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                //chatItemCollection[2] = chatItem_2;

                //for (int f = 3; f < 40; f++)
                //{
                //    chatItemCollection[f] = new ChatSubItem("糖糖", Resource1.mm, "糖糖", "ff");
                //}


                Point point = new Point(30,  baseHeight);
                DrawArrows(g, titleToItemCollection[i].isDrawItem, baseHeight);
                
                g.DrawString(title, new Font("宋体", 11), Brushes.Black, point);
                
                baseHeight = baseHeight + 10 + blankHeight;
                if(titleToItemCollection[i].isDrawItem == true)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        baseY = j * 75 + baseHeight;
                        if (true == chatItemCollection[j].IsMouseHover)
                        {
                            SolidBrush solidBrush = new SolidBrush(chatItemCollection[i].MouseHoverBackColor);
                            g.FillRectangle(solidBrush, new Rectangle(0, baseY, this.Width, ChatSubItem.Height));
                        }
                        if (true == chatItemCollection[j].IsPressed)
                        {
                            SolidBrush solidBrush = new SolidBrush(chatItemCollection[i].MousePressedColor);
                            g.FillRectangle(solidBrush, new Rectangle(0, baseY, this.Width, 75));
                        }

                        Point imagePos = GetPointByModifyHeight(ChatSubItem.IconPos, baseY);
                        Point userNamePos = GetPointByModifyHeight(ChatSubItem.UserNamePos, baseY);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        g.DrawImage(chatItemCollection[i].Icon, new Rectangle(imagePos.X + 20, imagePos.Y + 10, 50, 50));//GetPointByModifyHeight(ChatItem.IconPos, baseY));
                        g.DrawString(chatItemCollection[i].UserName, ChatSubItem.UserNameFont, Brushes.Black, new Point(userNamePos.X + 50, userNamePos.Y + 15));
                        g.DrawString("不好意思，刚才没看到", ChatSubItem.ExtraMsgFont, ChatSubItem.ExtraMsgSb, new Point(userNamePos.X + 50, userNamePos.Y + 44));
                        g.FillPath(new SolidBrush(slider.BackColor), slider.Path);
                        g.DrawString(chatItemCollection[i].LastChattTime, ChatSubItem.UserNameFont, Brushes.Black, new Point(userNamePos.X + 50, userNamePos.Y + 30));
                    }
                    baseHeight = baseY + 75;   
                }
            }
            sumLength = baseHeight;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point p = e.Location;
            Rectangle rect1;
            int sliderMaxX = this.Width;
            int sliderMinX = this.Width - slider.Width;
            if (true == isDrawSlider)
            {
                if ((p.X < sliderMaxX) && (p.X > sliderMinX))
                {
                    return;
                }
            }


            for (int i = 0; i < 4; i++)
            {
                if(titleToItemCollection[i].titleRegion.Contains(p))
                {
                    titleToItemCollection[i].isDrawItem = !titleToItemCollection[i].isDrawItem;
                    //isDrawSlider = !isDrawSlider;
                    noDrawBackGroundNumber = i; 
                    this.Invalidate();
                }
            }
        }

        bool isDrawSlider = true;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point p = new Point(e.Location.X, e.Location.Y + sliderVal);

            Rectangle rect1;
            int sliderMaxX = this.Width;
            int sliderMinX = this.Width - slider.Width;
            if(true == isDrawSlider)
            {
                if((p.X < sliderMaxX)&&(p.X > sliderMinX))
                {
                    drawBackGround = -1;
                    this.Invalidate();
                    return;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                rect1 = titleToItemCollection[i].titleRegion;
                if (rect1.Contains(p) && (i != drawBackGround))
                {
                    drawBackGround = i;
                    if (i != noDrawBackGroundNumber)
                    {
                        noDrawBackGroundNumber = -1;
                    }
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            drawBackGround = -1;
            this.Invalidate();
        }

        private void DrawItemBackGround(Graphics g)
        {
            if(drawBackGround == -1)
            {
                return;
            }
            if(drawBackGround == noDrawBackGroundNumber)
            {
                return;
            }

            Color color = Color.FromArgb(240, 240, 240);
            Rectangle rect = titleToItemCollection[drawBackGround].titleRegion;
            SolidBrush solidBrush = new SolidBrush(color);
            g.FillRectangle(solidBrush, rect);
        }

        private void DrawArrows(Graphics g, bool isDrawItem, int baseHeight)
        {
            if(isDrawItem == false)
            {
                g.DrawLine(new Pen(Brushes.Black), new Point(18, baseHeight + 6), new Point(28, baseHeight + 10));
                g.DrawLine(new Pen(Brushes.Black), new Point(28, baseHeight + 10), new Point(18, baseHeight + 14));
            }
            else
            {
                g.DrawLine(new Pen(Brushes.Black), new Point(18, baseHeight + 6), new Point(25, baseHeight + 12));
                g.DrawLine(new Pen(Brushes.Black), new Point(25, baseHeight + 12), new Point(32, baseHeight + 6));
            }
        }

        private ChatSubItem subItem;

        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            int height = mousePos.Y + sliderVal;
            int titleUpY = 0, titleDownY = 0;
            int num = -1;
            for (int i = 0; i < 4; i++)
            {
                titleUpY = titleToItemCollection[i].titleRegion.Y + titleToItemCollection[i].titleRegion.Height;
                if (i < 3)
                {
                    titleDownY = titleToItemCollection[i + 1].titleRegion.Y;
                    if ((mousePos.Y > titleUpY) && (mousePos.Y < titleDownY) && (i < 3))
                    {
                        num = (mousePos.Y - titleUpY) / 75;
                    }
                }
                else
                {
                    if((mousePos.Y > titleUpY) && (mousePos.Y < this.Height))
                    {
                        num = (mousePos.Y - titleUpY) / 75;
                    }
                }
                if(num == -1)
                {
                    continue;
                }
                titleToItemCollection[i].chatIemCollection[num].IsPressed = true;
                if (subItem != null)
                {
                    subItem.IsPressed = false;
                }
                subItem = titleToItemCollection[i].chatIemCollection[num];
                this.Invalidate();
                return;
                //if ((mousePos.Y > titleUpY) && (mousePos.Y < titleDownY) && (i < 3))
                //{
                //    int num = (mousePos.Y - titleUpY) / 75;
                //    titleToItemCollection[i].chatIemCollection[num].IsPressed = true;
                //    if(subItem != null)
                //    {
                //        subItem.IsPressed = false;
                //    }
                //    subItem = titleToItemCollection[i].chatIemCollection[num];
                //    this.Invalidate();
                //    return;
                }
                
            
        }
    }
}
