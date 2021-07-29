using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    class Slider
    {
        #region 属性
        private Point pos;
        /// <summary>
        /// 设置或获取滑轮的位置
        /// </summary>
        public Point Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
                GetPath();
                slideWay = new Rectangle(pos.X, sliderVal, this.width, ownerChatListBox.Height);
            }
        }

        private int sliderVal;
        public int SliderVal
        {
            get
            {
                return sliderVal;
            }
            set
            {
                sliderVal = value;
            }
        }

        private int width;
        /// <summary>
        /// 设置或获取滑轮的宽度
        /// </summary>
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                GetPath();
            }
        }

        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                GetPath();
            }
        }

        private Color backColor;
        /// <summary>
        /// 设置或获取滑轮背景颜色
        /// </summary>
        public Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
            }
        }

        private bool isVisble;
        /// <summary>
        /// 设置或获取按钮的显示状态
        /// </summary>
        public bool IsVisble
        {
            get
            {
                return isVisble;
            }
            set
            {
                isVisble = value;
            }
        }

        private Color mouseHoverBackColor;
        public Color MouseHoverBackColor
        {
            get
            {
                return mouseHoverBackColor;
            }
            set
            {
                mouseHoverBackColor = value;
            }
        }

        private bool isMouseHover;
        public bool IsMouseHover
        {
            get
            {
                return isMouseHover;
            }
            set
            {
                isMouseHover = value;
            }
        }

        private GraphicsPath path;
        /// <summary>
        /// 获取或设置滑块的形状
        /// </summary>
        public GraphicsPath Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        private int radius;
        /// <summary>
        /// 设置或获取滑块两个弧形边的弧度
        /// </summary>
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
                GetPath();
            }
        }

        private Rectangle slideWay;
        /// <summary>
        /// 设置或获取slider滑动的区域
        /// </summary>
        public Rectangle SliderWay
        {
            get
            {
                return slideWay;
            }
            set
            {
                slideWay = value;
            }
        }

        private Control ownerChatListBox;
        /// <summary>
        /// 设置或获取slider所属的ChatListBox
        /// </summary>
        public Control OwnerChatListBox
        {
            get
            {
                return ownerChatListBox;
            }
            set
            {
                ownerChatListBox = value;
            }
        }
        #endregion

        #region 构造函数
        public Slider(Point pos, Size size)
        {
            this.mouseHoverBackColor = Color.FromArgb(179, 179, 179);
            this.backColor = Color.FromArgb(204, 204, 204);
            this.isVisble = false;
            this.isMouseHover = false;
            this.pos = pos;
            this.height = size.Height;
            this.width = size.Width;
            this.radius = 10;
            path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(pos.X, pos.Y, size.Width, radius), 180, 180);
            path.AddArc(new Rectangle(pos.X, this.height - radius, size.Width, radius), 0, 180);
            path.CloseFigure();
        }

        public void GetPath()
        {
            path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(pos.X, pos.Y, this.Width, radius), 180, 180);
            path.AddArc(new Rectangle(pos.X, pos.Y + this.height - radius, this.Width, radius), 0, 180);
            path.CloseFigure();
        }

        public bool IsClicked(Point mousePos)
        {
            Rectangle rect = new Rectangle(pos, new Size(this.width, this.height));
            if(rect.Contains(mousePos))
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
