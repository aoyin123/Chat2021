using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chat2021.Mysql;
namespace WindowsFormsApp3
{
    class ChatHistory
    {
        private List<LayoutItem> chatInfos;
        private int count;
        public int Count
        {
            get
            {
                return chatInfos.Count;
            }
        }

        public ChatHistory(Mysql mysql)
        {
            TextBox textBox = new TextBox();
            chatInfos = mysql.GetChatRecord();
            chatInfos[0].headPos = new Point(5, 10);
            for(int i = 0; i < chatInfos.Count; i++)
            {
                textBox.Text = chatInfos[i].msg;
                chatInfos[i].msgSize = AutoSizeTextBox(textBox);

                textBox.Text = chatInfos[i].tag;
                chatInfos[i].headSize = AutoSizeTextBox(textBox);

                if (0 == i)
                {
                    chatInfos[0].headPos = new Point(5, 10);
                    chatInfos[0].msgPos = new Point(5, 10 + chatInfos[0].headSize.Height + 5);
                }
                else
                {
                    chatInfos[i].headPos = new Point(5, chatInfos[i - 1].msgPos.Y + 20);
                    chatInfos[i].msgPos = new Point(5, chatInfos[i].headPos.Y + 20);
                }      
            }
        }
        

        public LayoutItem this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                return chatInfos[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                chatInfos[index] = value;
            }
        }

        public void DrawTag(Graphics g)
        {
            for(int i = 0; i < count; i++)
            {
                g.DrawString(chatInfos[i].msg, LayoutItem.msgFont, LayoutItem.solidBrush, chatInfos[i].headPos);
            }
        }

        public List<LayoutItem> GetChatLayoutCollByVerticalRange(int top, int end)
        {
            List<LayoutItem> result = new List<LayoutItem>();
            for(int i = 0; i < 20; i++)
            {
                if((chatInfos[i].top > top) &&(chatInfos[i].top < end))
                {
                    result.Add(chatInfos[i]);
                }
            }
            return result;
        }

        public void Add(LayoutItem layoutItem)
        {
            if (null == layoutItem)
            {
                return;
            }

            TextBox textBox = new TextBox();
            textBox.Text = layoutItem.msg;
            layoutItem.msgSize = AutoSizeTextBox(textBox);

            textBox.Text = layoutItem.tag;
            layoutItem.headSize = AutoSizeTextBox(textBox);

            if (0 == Count)
            {
                layoutItem.headPos = new Point(5, 10);
                layoutItem.msgPos = new Point(5, 10 + layoutItem.headSize.Height + 5);
            }
            else
            {
                layoutItem.headPos = new Point(5, chatInfos[Count - 1].msgPos.Y + 20);
                layoutItem.msgPos = new Point(5, layoutItem.headPos.Y + 20);
            }
            chatInfos.Add(layoutItem);
            count++;

        }
        

        //计算字符串所占的控件
        private Size AutoSizeTextBox(TextBox txt)
        {
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font);
            return size;
        }
    }
}
