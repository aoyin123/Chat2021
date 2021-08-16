using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    class Groups
    {
        #region val
        private Group[] groups = new Group[4];
        public Group lastStopDrawBackGround;
        private Control owner;
        private ChatSubItem lastDisPlayMouseDownEffectChatSubItem;
        private ChatSubItem lastDisPlayMouseMoveEffectChatSubItem;
        public int len;
        #endregion

        #region init
        public Groups(Control owner)
        {
            groups[0] = new Group("新朋友", false, owner, 0);
            groups[1] = new Group("我的设备", false, owner, 45);
            groups[2] = new Group("朋友", false, owner, 90);
            groups[3] = new Group("公众号", false, owner, 135);
            this.owner = owner;
        }

        #endregion

        #region function
        public Group GetSelectGroupByClickedGroupName(Point p)
        {
            Rectangle rect;
            for (int i = 0; i < 4; i++)
            {
                rect = groups[i].groupNameRegion;
                if (rect.Contains(p))
                {
                    return groups[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 得到鼠标停留在的组成员
        /// </summary>
        /// <param name="p">鼠标的位置</param>
        /// <returns></returns>
        public ChatSubItem GetMouseOnItem(Point p)
        {
            int index;
            for (int i = 0; i < 4; i++)
            {
                if(groups[i].ItemRegion.Contains(p))
                {
                    index = (p.Y - groups[i].ItemRegion.Y) / 75;
                    return groups[i][index];  
                }
            }
            return null;
        }
        

        

        /// <summary>
        /// 组集合中是否都显示组成员
        /// </summary>
        /// <returns></returns>
        public bool IsDisplayGroupNumber()
        {
            for(int i = 0; i < 4; i++)
            {
                if(groups[i].IsDrawGroupName == true)
                {
                    return true;
                }
            }
            return false;
        }

        

        /// <summary>
        /// 用[]操作符获得group
        /// </summary>
        /// <param name="index">索引</param>
        /// <returns></returns>
        public Group this[int index]
        {
            get
            {
                if (index < 0 || index >= 4)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return groups[index];
            }
            set
            {
                if (index < 0 || index >= 4)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                groups[index] = value;
            }
        }
#endregion

        #region PaintEvent

        /// <summary>
        /// 隐藏指定的组的组员
        /// </summary>
        /// <param name="group">要隐藏组员的组</param>
        public void DisplayGroup(Group group)
        {
            int index = GetGroupIndex(group);
            group.IsDrawGroupName = true;
            for (int i = index + 1; i < 4; i++)
            {
                groups[i].Top = groups[i - 1].end;
            }
            CalculateGroupDisplayNeedLen();
        }

        /// <summary>
        /// 找到组在对应数组中的下标
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        

        /// <summary>
        /// 隐藏一个组的成员，并调整其他组的位置
        /// </summary>
        /// <param name="group">指定隐藏的组</param>
        public void HideGrop(Group group)
        {
            int index = GetGroupIndex(group);
            //检查程序时可以分段检查，分段查看其功能
            group.IsDrawGroupName = false;
            for (int i = index + 1; i < 4; i++)
            {
                groups[i].Top = groups[i - 1].end;
            }
            CalculateGroupDisplayNeedLen();
        }



        /// <summary>
        /// 不显示所有GroupName的背景色
        /// </summary>
        public void NoDisPlayGroupNameBackGround()
        {
            for (int i = 0; i < 4; i++)
            {
                groups[i].isDrawGroupNameMouseMoveBackGround = false;
            }
        }

        /// <summary>
        /// 只显示指定的Group的组名的背景色，不显示其他Group的组名
        /// </summary>
        /// <param name="group">组</param>
        public void DisPlayOneGroupNameBackGround(Group group)
        {
            NoDisPlayGroupNameBackGround();
            group.isDrawGroupNameMouseMoveBackGround = true;
            this.owner.Invalidate();
        }

        /// <summary>
        /// 显示集合中所有的组
        /// </summary>
        /// <param name="g">绘画句柄</param>
        public void Draw(Graphics g)
        {
            for (int i = 0; i < 4; i++)
            {
                groups[i].Draw(g);
            }
        }

        /// <summary>
        /// 显示当鼠标停留在组成员上时所呈现的效果
        /// </summary>
        /// <param name="p"></param>
        public void DisplayMouseMoveEffect(Point p)
        {
            ChatSubItem chatSubItem = GetMouseOnItem(p);
            if (chatSubItem != null)
            {
                chatSubItem.IsMouseHover = true;
            }
            if ((chatSubItem != lastDisPlayMouseMoveEffectChatSubItem) &&
                    (null != lastDisPlayMouseMoveEffectChatSubItem))
            {
                lastDisPlayMouseMoveEffectChatSubItem.IsMouseHover = false;
            }
            lastDisPlayMouseMoveEffectChatSubItem = chatSubItem;
        }

        /// <summary>
        /// 显示鼠标点击在组成员上的
        /// </summary>
        /// <param name="p"></param>
        public void DisPlayMouseDownEffect(Point p)
        {
            ChatSubItem chatSubItem = GetMouseOnItem(p);
            if (chatSubItem != null)
            {
                chatSubItem.IsPressed = true;
            }
            if (null != lastDisPlayMouseDownEffectChatSubItem)
            {
                lastDisPlayMouseDownEffectChatSubItem.IsPressed = false;
            }
            lastDisPlayMouseDownEffectChatSubItem = chatSubItem;
        }

        /// <summary>
        /// 得到鼠标停留的组
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int GetGroupIndex(Group group)
        {
            for (int i = 0; i < 4; i++)
            {
                if (groups[i] == group)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 计算显示Groups所需要的长度
        /// </summary>
        public void CalculateGroupDisplayNeedLen()
        {
            len = 0;
            for (int i = 0; i < 4; i++)
            {
                len += groups[i].sumLength;
            }
        }
        #endregion
    }
}
