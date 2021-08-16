using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    class Group
    {
        #region val
        private string groupName;
        private ChatIemCollection chatIemCollection = new ChatIemCollection();
        private bool isDrawGroupNameMouseDownBackGround = false;
        private SolidBrush drawGroupNameSbru = new SolidBrush(Color.FromArgb(240, 240, 240));
        private int ChatItemTop;
        private Control owner;

        public bool stopDrawBackColor;
        public int end;
        public int sumLength = 45;
        public Rectangle groupNameRegion, ItemRegion;
        public bool isDrawGroupNameMouseMoveBackGround = false;
        #endregion

        #region Properties
        /// <summary>
        /// 获取或设置组名
        /// </summary>
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
            }
        }


        private bool isDrawGroupName;
        /// <summary>
        /// 是否显示组员
        /// </summary>
        public bool IsDrawGroupName
        {
            get
            {
                return isDrawGroupName;
            }
            set
            {
                isDrawGroupName = value;
                if(isDrawGroupName == true)
                {
                    sumLength = 45 + 75 * 40;
                    ItemRegion = new Rectangle(0, top + 45, owner.Width, sumLength - 45);
                }
                else
                {
                    sumLength = 45;
                    ItemRegion = new Rectangle(0, 0, 0, 0);
                }
                end = Top + sumLength;
            }
        }

        public ChatSubItem this[int index]
        {
            get
            {
                if (index < 0 || index >= 40)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return chatIemCollection[index];
            }
            set
            {
                if (index < 0 || index >= 40)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                chatIemCollection[index] = value;
            }
        }

        private int top;
        /// <summary>
        /// 设置上边界
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
                groupNameRegion = new Rectangle(0, top, owner.Width, 45);
                ItemRegion.Y = top + 45;
                end = top + sumLength;
                ChatItemTop = top + 45;
                if (chatIemCollection != null)
                {
                    for (int i = 0; i < 40; i++)
                    {
                        if(chatIemCollection[i] == null)
                        {
                            return;
                        }
                        chatIemCollection[i].Top = top + 45 + 75 * i;
                    }
                }
            }
        }


        #endregion

        #region Init
        public Group(String groupName, bool isDrawGroupName, Control owner, int top)
        {
            this.owner = owner;
            this.groupName = groupName;
            this.isDrawGroupName = isDrawGroupName;
            this.Top = top;
            for (int f = 0; f < 40; f++)
            {
                chatIemCollection[f] = new ChatSubItem("糖糖", Resource1.userIcon, "糖糖", "ff", new Size(50, 78), owner, ChatItemTop + f * 75);
            }
        }
        #endregion

        #region Paint
        /// <summary>
        /// 显示组
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawGroupNameBackGround(g);
            DrawArrow(g);
            DrawGroupNumber(g);
            DrawGroupName(g);
        }

        /// <summary>
        /// 显示箭头
        /// </summary>
        /// <param name="g"></param>
        private void DrawArrow(Graphics g)
        {
            if (IsDrawGroupName == false)
            {
                g.DrawLine(new Pen(Brushes.Black), new Point(18, Top + 6 + 15), new Point(28, Top + 10 + 15));
                g.DrawLine(new Pen(Brushes.Black), new Point(28, Top + 10 + 15), new Point(18, Top + 14 + 15));
            }
            else
            {
                g.DrawLine(new Pen(Brushes.Black), new Point(18, Top + 6 + 15), new Point(25, Top + 12 + 15));
                g.DrawLine(new Pen(Brushes.Black), new Point(25, Top + 12 + 15), new Point(32, Top + 6 + 15));
            }
        }

        /// <summary>
        /// 显示组的名字
        /// </summary>
        /// <param name="g"></param>
        private void DrawGroupName(Graphics g)
        {
            g.DrawString(groupName, new Font("宋体", 11), Brushes.Black, new Point(30, Top + 15));
        }

        /// <summary>
        /// 显示组员
        /// </summary>
        /// <param name="g"></param>
        private void DrawGroupNumber(Graphics g)
        {
            if (false == IsDrawGroupName) return;

            for (int j = 0; j < 40; j++)
            {
                chatIemCollection[j].DrawChatSubItem(g);
            }
        }

        
        
        /// <summary>
        /// 设置显示组名区域的背景颜色
        /// </summary>
        /// <param name="g"></param>
        public void DrawGroupNameBackGround(Graphics g)
        {
            if (isDrawGroupNameMouseDownBackGround == true)
            {
                return;
            }

            if(stopDrawBackColor == true)
            {
                return;
            }

            if (isDrawGroupNameMouseMoveBackGround == true)
            {
                g.FillRectangle(drawGroupNameSbru, groupNameRegion);
            }
        }
        #endregion 
    }
}
