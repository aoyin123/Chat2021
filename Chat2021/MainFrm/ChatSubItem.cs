using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    class ChatSubItem
    {
        #region 变量
        private Point drawIconPos;
        private Point drawUserNamePos;
        private Point drawExtraMsgPos;
        private Control owner;
        #endregion

        #region 属性
        private string userName;
        /// <summary>
        /// 设置或获取用户名
        /// </summary>
        public string UserName
        { 
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        

        private Font userNameFont = new Font("宋体", 12);
        /// <summary>
        /// 显示用户名所用到的字体
        /// </summary>
        public Font UserNameFont
        {
            get
            {
                return userNameFont;
            }
            set
            {
                userNameFont = value;
            }
        }

        private Brush userNameBru = Brushes.Black;
        /// <summary>
        /// 设置或获取画userName的刷子
        /// </summary>
        public Brush UserNameBru
        {
            get
            {
                return userNameBru;
            }
            set
            {
                userNameBru = value;
            }
        }

        private Point userNamePos = new Point(80, 15);
        /// <summary>
        /// 设置或获取用户名显示位置
        /// </summary>
        public Point UserNamePos
        {
            get
            {
                return userNamePos;
            }
            set
            {
                userNamePos = value;
            }
        }

        private string extraStr = "不好意思，刚才没看到";
        public string ExtraStr
        {
            get
            {
                return extraStr;
            }
            set
            {
                extraStr = value;
            }
        }

        private Point extraMsgPos = new Point(80, 44);
        /// <summary>
        /// 设置或获取用户名显示位置
        /// </summary>
        public Point ExtraMsgPos
        {
            get
            {
                return extraMsgPos;
            }
            set
            {
                extraMsgPos = value;
            }
        }

        private Font extraMsgFont = new Font("宋体", 9);
        /// <summary>
        /// 设置或获取额外信息的字体
        /// </summary>
        public Font ExtraMsgFont
        {
            get
            {
                return extraMsgFont;
            }
            set
            {
                extraMsgFont = value;
            }
        }

        private SolidBrush extraMsgSb = new SolidBrush(Color.FromArgb(117, 117, 117));
        /// <summary>
        /// 获取或设置额外信息的画笔
        /// </summary>
        public SolidBrush ExtraMsgSb
        {
            get
            {
                return extraMsgSb;
            }
            set
            {
                extraMsgSb = value;
            }
        }

        private Bitmap icon;
        /// <summary>
        /// 设置或获取用户图标
        /// </summary>
        public Bitmap Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }

        private static  Size iconSize;
        /// <summary>
        /// 设置或获取用户图标的大小
        /// </summary>
        public static Size IconSize
        {
            get
            {
                return iconSize;
            }
            set
            {
                iconSize = value;
            }
        }

        private Point iconPos = new Point(20, 10);
        /// <summary>
        /// 设置用户图标的位置
        /// </summary>
        public Point IconPos
        {
            get
            {
                return iconPos;
            }
            set
            {
                iconPos = value;
            }
        }

        private int iconWidth = 50;
        /// <summary>
        /// 设置图标的宽度
        /// </summary>
        public int IconWidth
        {
            get
            {
                return iconWidth;
            }
            set
            {
                iconWidth = value;
            }
        }

        private int iconHeight = 50;
        /// <summary>
        /// 设置或获取图标的高度
        /// </summary>
        public int IconHeight
        {
            get
            {
                return iconHeight;
            }
            set
            {
                iconHeight = value;
            }
        }

        private string lastChatTime;
        /// <summary>
        /// 最近一次聊天的时间
        /// </summary>
        public string LastChattTime
        {
            get 
            {
                return lastChatTime;
            }
            set
            {
                lastChatTime = value;
            }
        }

        private static Font lastChatTimeFont;
        /// <summary>
        /// 设置或时间显示的字体
        /// </summary>
        public static Font LastChatTimeFont
        {
            get
            {
                return lastChatTimeFont;
            }
            set
            {
                lastChatTimeFont = value;
            }
        }

        private static Point lastChatTimePos;
        /// <summary>
        /// 最近一次聊天时间显示位置
        /// </summary>
        public static Point LastChatTimePos
        {
            get
            {
                return lastChatTimePos;
            }
            set
            {
                lastChatTimePos = value;
            }
        }

        private int width;
        /// <summary>
        /// item的宽度
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
            }
        }

        private int height;
        /// <summary>
        /// Item的高度
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
            }
        }

        private string extraMsg;
        /// <summary>
        /// 获取或设置额外信息(最后一次聊天的类容或者是用户签名)
        /// </summary>
        public string ExtraMsg
        {
            get
            {
                return extraMsg;
            }
            set
            {
                extraMsg = value;
            }
        }

        private Color customerBackColor;
        /// <summary>
        /// 子项无任何事件响应时的背景颜色
        /// </summary>
        public Color CustomerBackColor
        {
            get
            {
                return customerBackColor;
            }
            set
            {
                customerBackColor = value;
            }
        }

        private bool isPressed;
        /// <summary>
        /// 子项是否被点击
        /// </summary>
        public bool IsPressed
        {
            get
            {
                return isPressed;
            }
            set
            {
                isPressed = value;
                this.owner.Invalidate();
            }
        }

        private Color pressedBackColor;
        /// <summary>
        /// 鼠标点击在子项上子项的背景颜色
        /// </summary>
        public Color PressedBackColor
        {
            get
            {
                return pressedBackColor;
            }
            set
            {
                pressedBackColor = value;
            }
        }

        private bool isMouseHover;
        /// <summary>
        /// 鼠标是否停留在子项上
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
                this.owner.Invalidate();
            }
        }

        private Color mouseHoverBackColor;
        /// <summary>
        /// 鼠标停留在子项上子项的背景颜色1
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

        private Color mousePressedColor;
        /// <summary>
        /// 鼠标点击在子项上时子项的颜色
        /// </summary>
        public Color MousePressedColor
        {
            get
            {
                return mousePressedColor;
            }
            set
            {
                mousePressedColor = value;
            }
        }

        private Point itemPos;
        /// <summary>
        /// 获取或设置子项的位置
        /// </summary>
        public Point ItemPos
        {
            get
            {
                return itemPos;
            }
            set
            {
                itemPos = value;
            }
        }

        private int left = 0;
        /// <summary>
        /// 设置或获取ChatSubItem左边界位置
        /// </summary>
        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

        private int top;
        /// <summary>
        /// 设置或获取上边界的位置
        /// </summary>
        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
                drawIconPos = GetPointByModifyHeight(IconPos, top);
                drawUserNamePos = GetPointByModifyHeight(UserNamePos, top);
                drawExtraMsgPos = GetPointByModifyHeight(ExtraMsgPos, top);
                iconRegion = new Rectangle(drawIconPos, new Size(iconWidth, iconHeight));
            }
        }

        private Rectangle iconRegion;
        public Rectangle IconRegion
        {
            get
            {
                return IconRegion;
            }
            set
            {
                iconRegion = value;
            }
        }

        #endregion

        #region 初始化
        /// <summary>
        /// 初始化Item信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="bitmap">用户图像</param>
        public ChatSubItem(string userName, Bitmap bitmap,string lastChatString, string extraMsg,Size size,Control owner, int top)
        {
            this.userName = userName;
            this.icon = bitmap;
            this.extraMsg = extraMsg;
            this.MouseHoverBackColor = Color.FromArgb(242, 242, 242);
            this.mousePressedColor = Color.FromArgb(235, 235, 235);
            this.width = owner.Width;
            this.height = size.Height;
            this.owner = owner;
            this.Top = top;
        }
        #endregion

        #region 绘图

        private Point GetPointByModifyHeight(Point p, int top)
        {
            return new Point(p.X, p.Y + top);
        }

        private void DrawSubItemMouseHoverBackGround(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(MouseHoverBackColor);
            g.FillRectangle(solidBrush, new Rectangle(left, top, Width, Height));
            solidBrush.Dispose();
        }

        private void DrawMousePressedBackGround(Graphics g)
        {
            SolidBrush solidBrush = new SolidBrush(MousePressedColor);
            g.FillRectangle(solidBrush, new Rectangle(left, top, width, Height));
            solidBrush.Dispose();
        }

        public void DrawChatSubItem(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (true == IsMouseHover)
            {
                DrawSubItemMouseHoverBackGround(g);
            }

            if (true == IsPressed)
            {
                DrawMousePressedBackGround(g);
            }
            g.DrawImage(Icon, iconRegion);
            g.DrawString(UserName, UserNameFont, userNameBru, drawUserNamePos);
            g.DrawString(extraStr, ExtraMsgFont, ExtraMsgSb, drawExtraMsgPos);
        }
        #endregion
    }
}
