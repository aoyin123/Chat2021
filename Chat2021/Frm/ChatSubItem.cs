using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.Frm
{
    class ChatSubItem
    {
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

        

        private static Font userNameFont;
        /// <summary>
        /// 显示用户名所用到的字体
        /// </summary>
        public static Font UserNameFont
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

        private static Point userNamePos;
        /// <summary>
        /// 设置或获取用户名显示位置
        /// </summary>
        public static Point UserNamePos
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

        private static Point extraMsgPos;
        /// <summary>
        /// 设置或获取用户名显示位置
        /// </summary>
        public static Point ExtraMsgPos
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

        private static Font extraMsgFont;
        /// <summary>
        /// 设置或获取额外信息的字体
        /// </summary>
        public static Font ExtraMsgFont
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

        private static SolidBrush extraMsgSb;
        /// <summary>
        /// 获取或设置额外信息的画笔
        /// </summary>
        public static SolidBrush ExtraMsgSb
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

        private static Point iconPos;
        /// <summary>
        /// 设置用户图标的位置
        /// </summary>
        public static Point IconPos
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

        private static int width;
        /// <summary>
        /// item的宽度
        /// </summary>
        public static int Width
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

        private static int height;
        /// <summary>
        /// Item的高度
        /// </summary>
        public static int Height
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


        #endregion

        #region 初始化控件
        /// <summary>
        /// 初始化Item信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="bitmap">用户图像</param>
        public ChatSubItem(string userName, Bitmap bitmap,string lastChatString, string extraMsg)
        {
            this.userName = userName;
            this.icon = bitmap;
            this.extraMsg = extraMsg;
            this.MouseHoverBackColor = Color.FromArgb(242, 242, 242);
            this.mousePressedColor = Color.FromArgb(235, 235, 235);
        }
        #endregion

        
    }
}
