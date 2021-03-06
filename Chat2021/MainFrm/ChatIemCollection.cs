using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat2021.MainFrm
{
    class ChatIemCollection
    {
        #region 变量
        private ChatSubItem[] chatItems;
        private int count;
        public int Count
        {
            get
            {
                return count;
            }

        }
        #endregion

        #region 初始化
        public ChatIemCollection()
        {
            EnsureSpace();
        }
        #endregion

        #region 增删改查
        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="chatItem">chatItem</param>
        private void AddItem(ChatSubItem chatItem)
        {

            ChatSubItem[] chatItem_copy = new ChatSubItem[count + 1];
            chatItems.CopyTo(chatItem_copy, 0);
            chatItems = chatItem_copy;
            count++;
            chatItems[count] = chatItem;
        }

        private void EnsureSpace()
        {
            if(chatItems == null)
            {
                chatItems = new ChatSubItem[40];
                count = 40;
            }
            else
            {
                ChatSubItem[] arrTemp = new ChatSubItem[chatItems.Length * 2];
                chatItems.CopyTo(arrTemp, 0);
                chatItems = arrTemp;
            }
        }

        /// <summary>
        /// 查找Item在当前的索引
        /// </summary>
        /// <param name="chatItem"></param>
        /// <returns></returns>
        private int IndexOf(ChatSubItem chatItem)
        {
            for(int i = 0; i < count; i++)
            {
                if(chatItems.Equals(chatItem))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="chatItem"></param>
        /// <returns></returns>
        private ChatSubItem[] RemoveItem(ChatSubItem chatItem)
        {
            int index = IndexOf(chatItem);
            ChatSubItem[] chatItem_cp = new ChatSubItem[count - 1];
            if(index != -1)
            {
                for(int i = 0; i < index; i++)
                {
                    chatItem_cp[i] = chatItems[i];
                    if(i == index - 1)
                    {
                        for(int j = index + 1; j< count;i++)
                        {
                            chatItem_cp[j - 1] = chatItem_cp[j]; 
                        }
                    }
                }
                count--;
                return chatItem_cp;
                
            }
            else
            {
                return chatItems;
            }
        }

        public ChatSubItem this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return chatItems[index];
            }
            set
            {
                if (index < 0 || index >= this.count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                chatItems[index] = value;
            }
        }


        #endregion

        #region 初始化

        #endregion
        
    }
}
