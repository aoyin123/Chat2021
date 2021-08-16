using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat2021.MainFrm;

namespace Chat2021.MainFrm
{
    partial class ChatListBox1 : UserControl
    {
        #region 变量
        private ChatIemCollection chatItemCollection = null;
        private ChatSubItem nowMousePressChatSubItem = null;
        private ChatSubItem lastMousePressChatSubItem = null;
        private ChatSubItem nowMouseHoverChatSubItem = null;
        private ChatSubItem lastMouseHoverChatSubItem = null;
        private Slider slider = null;
        private int ItemHeight = 0;
        private int ItemWidth = 0;
        private Point mousePos = new Point(0, 0);
        #endregion

        #region 初始化

        /// <summary>
        /// 控件初始化，设置双缓冲
        /// </summary>
        public ChatListBox1()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); 
            SetStyle(ControlStyles.DoubleBuffer, true); 
        }

        /// <summary>
        /// 鼠标点击子项，子项改变背景颜色
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">消息</param>
        private void ItemMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            int index = (mousePos.Y + slider.SliderVal) / ItemHeight;
            if(index  == 40)
            {
                index = 39;
            }
            nowMouseHoverChatSubItem = chatItemCollection[index];

            if(null != lastMouseHoverChatSubItem)
            {
                lastMouseHoverChatSubItem.IsMouseHover = false;
            }
            nowMouseHoverChatSubItem.IsMouseHover = true;
            lastMouseHoverChatSubItem = nowMouseHoverChatSubItem;
        }

        /// <summary>
        /// 鼠标滑过子项时，子项改变背景颜色
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">消息</param>
        private void ItemMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = e.Location;
            int index = (mousePos.Y + slider.SliderVal) / ItemHeight;
            nowMousePressChatSubItem = chatItemCollection[index];
            if(null != lastMousePressChatSubItem)
            {
                lastMousePressChatSubItem.IsPressed = false;
            }
            nowMousePressChatSubItem.IsPressed = true;
            lastMousePressChatSubItem = nowMousePressChatSubItem; 
        }

        /// <summary>
        /// 滑动滑块时，改变滑块位置以及调整子项的绘画
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">消息</param>
        private void SliderMouseDown(object sender, MouseEventArgs e)
        {
            Point sliderToChatListBox = new Point(slider.Pos.X, slider.Pos.Y - slider.SliderVal);
            Rectangle rect = new Rectangle(sliderToChatListBox, new Size(slider.Width, slider.Height));
            if (rect.Contains(e.Location))
            {
                slider.IsMouseDownOnSlider = true;
                mousePos = e.Location;
            }
        }

        
        /// <summary>
        /// 改变ChatListBox的大小时改变ChatSubItem的宽度
        /// </summary>
        private void AdjustChatSubItemWidth()
        {
            for (int i = 0; i < 40; i++)
            {
                chatItemCollection[i].Width = this.Width;
            }
        }

        /// <summary>
        /// 改变ChatListBox的大小时改变滑块的位置以及调整ChatSubItem的位置
        /// </summary>
        private void AdjustSliderPos()
        {
            slider.Pos = new Point(this.Width - slider.Width, slider.Pos.Y);
            slider.DisplayContentLength = ItemHeight * chatItemCollection.Count - this.Height;
        }

        /// <summary>
        /// 调整控件大小
        /// </summary>
        /// <param name="e">发送者</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            AdjustChatSubItemWidth();
            AdjustSliderPos();
        }

        /// <summary>
        /// 得到鼠标滑动在Y轴上的距离
        /// </summary>
        /// <param name="nowMousePos"></param>
        /// <returns></returns>
        private double GetMouseMoveDistance(Point nowMousePos)
        {
            double distance = mousePos.Y - nowMousePos.Y;
            mousePos = nowMousePos;
            return distance;
        }

        /// <summary>
        /// 用鼠标滑动滑块事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseMove(object sender, MouseEventArgs e)
        {
            if (slider.IsMouseDownOnSlider == true)
            {
                double distance = GetMouseMoveDistance(e.Location);
                slider.MoveSlider(distance);
            }
        }

        /// <summary>
        /// 鼠标MouseUp事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseUp(object sender, MouseEventArgs e)
        {
            slider.IsMouseDownOnSlider = false;
        }

        /// <summary>
        /// 初始化ChatSubItem的大小以及内容
        /// </summary>
        protected override void InitLayout()
        {
            base.InitLayout();
            chatItemCollection = new ChatIemCollection();
            
            this.Show();
            slider = new Slider(new Point(this.Width - 10, 0), new Size(10, 50), this);

            ItemHeight = 75;
            ItemWidth = this.Width; 
            Size itemSize = new Size(ItemWidth, ItemHeight); 

            for (int i = 0; i < 40; i++)
            {
                chatItemCollection[i] = new ChatSubItem("糖糖", Resource1.userIcon, "糖糖", "ff", itemSize, this, i*75);
            }
        }
        #endregion

        #region 绘图
        /// <summary>
        /// ChatListBox绘图
        /// </summary>
        /// <param name="e">发送者</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TranslateTransform(0, -slider.SliderVal);

            for (int i = 0; i < 40; i++)
            {
                chatItemCollection[i].Top = i * ItemHeight;
                chatItemCollection[i].DrawChatSubItem(g);
            }

            slider.Draw(g);
        }

        /// <summary>
        /// 滑块响应鼠标滑轮滑动
        /// </summary>
        /// <param name="sender">发送者</param>
        /// <param name="e">消息</param>
        private void FormMouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta < 0)
            {
                slider.Down();
            }
            else
            {
                slider.Up();
            }
        }
        #endregion
        
    }
    
}
