using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    class Slider
    {
        #region 属性
        private Point pos;
        private double unitHeight;
        private int radius;
        public GraphicsPath Path
        {
            get
            {
                return path;
            }
        }
        public GraphicsPath path;
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
                if (pos.Y < SliderVal)
                {
                    Pos = new Point(Pos.X, SliderVal);
                }
                else if ((Pos.Y) > (SliderVal + this.owner.Height - Height))
                {
                    Pos = new Point(Pos.X, SliderVal + this.owner.Height - Height);
                }

                GetPath();
            }
        }
        
        private int displayContentLength;
        /// <summary>
        /// 设置滑块对应的显示内容长度
        /// </summary>
        public int DisplayContentLength
        {
            get
            {
                return displayContentLength;
            }
            set
            {
                displayContentLength = value;
                unitHeight = (double)(this.owner.Height - height) / (double)displayContentLength; 
            }
        }

        private bool isMouseDownOnSlider = false;
        /// <summary>
        /// 鼠标是否点击在滑块上
        /// </summary>
        public bool IsMouseDownOnSlider
        {
            get
            {
                return isMouseDownOnSlider;
            }
            set
            {
                isMouseDownOnSlider = value;
            }
        }


        private int sliderVal = 0;
        public int SliderVal
        {
            get
            {
                return sliderVal;
            }
            set
            {
                sliderVal = value;
                if (sliderVal < 0) //向上滑动
                {
                    sliderVal = 0;
                }
                //else if (sliderVal > 75 * 40 - this.owner.Height)
                //{
                //    sliderVal = (int)75 * 40 - this.owner.Height;
                //}
                else if(sliderVal > displayContentLength)
                {
                    sliderVal = displayContentLength;
                }
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
        /// <summary>
        /// 设置或获取滑轮的高度
        /// </summary>
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

        private Color backColor = Color.FromArgb(204, 204, 204);
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

        private bool isVisble = false;
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
                this.owner.Invalidate();
            }
        }

        private Color mouseHoverBackColor = Color.FromArgb(179, 179, 179);
        /// <summary>
        /// 设置或获取滑轮的背景颜色
        /// </summary>
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

        private bool isMouseHover = false;
        /// <summary>
        /// 鼠标是否在滑块上停留
        /// </summary>
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

        
        

        

        

        private Control owner;
        /// <summary>
        /// 设置或获取slider所属的ChatListBox
        /// </summary>
        public Control Owner
        {
            set
            {
                owner = value;
            }
        }

        
        #endregion

        /// <summary>
        /// 画滑块
        /// </summary>
        /// <param name="g">绘画句柄</param>
        public void Draw(Graphics g)
        {
            g.FillPath(new SolidBrush(BackColor), path);
        }

        #region 构造函数
        public Slider(Point pos, Size size, Control owner)
        {
            this.pos = pos;
            this.height = size.Height;
            this.width = size.Width;
            this.radius = 10;
            this.owner = owner;
            GetSliderPath();
        }

        /// <summary>
        /// 得到初始状态下滑块的轮廓
        /// </summary>
        private void GetSliderPath()
        {
            path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(pos.X, pos.Y, Width, radius), 180, 180);
            path.AddArc(new Rectangle(pos.X, height - radius, Width, radius), 0, 180);
            path.CloseFigure();
        }

        /// <summary>
        /// 得到运动状态下滑块的轮廓
        /// </summary>
        public void GetPath()
        {
            path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(pos.X, pos.Y, this.Width, radius), 180, 180);
            path.AddArc(new Rectangle(pos.X, pos.Y + this.height - radius, this.Width, radius), 0, 180);
            path.CloseFigure();
        }

        /// <summary>
        /// 是否点击了滑块
        /// </summary>
        /// <param name="mousePos"></param>
        /// <returns></returns>
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

        

        /// <summary>
        /// 滑轮向下滑动
        /// </summary>
        public void Down()
        {
            SliderVal += 15;
            int sliderY = (int)(sliderVal * unitHeight);
            Pos = new Point(owner.Width - width, sliderY + sliderVal);
            owner.Invalidate();
        }

        /// <summary>
        /// 向上移动滑块
        /// </summary>
        public void Up()
        {
            SliderVal -= 15;
            int sliderY = (int)(sliderVal * unitHeight);
            Pos = new Point(owner.Width - width, sliderY + sliderVal);
            owner.Invalidate();
        }

        /// <summary>
        /// 向上或向下移动滑块
        /// </summary>
        /// <param name="val">向上或向下移动滑块的距离</param>
        public void MoveSlider(double val)
        {
            double changeVal = 1 / unitHeight * val;
            SliderVal -= (int)changeVal;
            Pos = new Point(Pos.X, (int)(Pos.Y - val - changeVal));
            this.owner.Invalidate();
        }
    }
}
