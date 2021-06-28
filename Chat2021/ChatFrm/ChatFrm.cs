using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.ChatFrm
{
    public partial class ChatFrm : Form
    {
        #region value

        Button shadow;
        private Image[] images = new Image[8] { Resource.表情,
                                                Resource.动图,
                                                Resource.截屏,
                                                Resource.上传文件,
                                                Resource.发送腾讯文档,
                                                Resource.发送图片,
                                                Resource.消息接收设置,
                                                Resource.更多
                                              };

        #endregion
        public ChatFrm()
        {
            InitializeComponent();
            shadow = new Button();
            InitStyle();
            
        }

        private void InitStyle()
        {
            SetFormStyle();
            SetControlStyle();
        }

        private void SetFormStyle()
        {
            this.Size = new Size(717, 617);
            this.BackColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
        }

        private void SetControlStyle()
        {
            //关闭按钮，最大化按钮，最小化按钮，窗口设置按钮
            shadow.Size = new Size(50, 50);
            shadow.BackColor = Color.Red;
            shadow.Visible = false;
            this.Controls.Add(shadow);
            SetMenuStripStyle();
        }

        private void SetMenuStripStyle()
        {
            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                menuStrip1.Items[i].BackColor = Color.White;
                menuStrip1.Items[i].ImageScaling = 0;
                menuStrip1.Items[i].Text = "";
                menuStrip1.Items[i].AutoSize = false;
                menuStrip1.Items[i].Size = new Size(32, 32);
                menuStrip1.Items[i].Image = images[i];
            }
            this.menuStrip1.Location = new Point(0, 460);
            this.menuStrip1.Renderer = new MenuItemRenderer();
            
        }
    }
}
