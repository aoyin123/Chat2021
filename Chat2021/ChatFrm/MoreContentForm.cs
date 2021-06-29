using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Chat2021.win32api;

namespace Chat2021
{
    public partial class MoreContentForm : Form
    {
        #region 变量
        Point basePos;
        ItemShadow itemShadow;
        #endregion

        #region 初始化
        public MoreContentForm(Form pForm)
        {
            InitializeComponent();
            SetFormStyle(pForm);
            InitEventHanler();
            initChose();
            MouseHook.OnMouseActivity += ShowItemShadow;
        }

        private void SetFormStyle(Form pForm)
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲

            this.ShowInTaskbar = false;
            uint ExdStyle = win32.GetWindowLong(this.Handle, win32.GWL_EXSTYLE);
            win32.SetWindowLong(this.Handle, win32.GWL_EXSTYLE, win32.WS_EX_TRANSPARENT | win32.WS_EX_LAYERED);
            win32.SetLayeredWindowAttributes(this.Handle, 0XFFFFFF, 255, 3);
            this.Location = pForm.Location;
            this.TopMost = true;
        }

        private void InitEventHanler()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayTextForm_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayTextForm_MouseMove);
        }
        #endregion

        #region 选择项
        private struct Choose
        {
            public string text { get; set; }
            public Rectangle rect { get; set; }
        }

        Choose[] chooses = new Choose[6];

        private void initChose()
        {
            chooses[0].text = "保持窗口最前";
            chooses[0].rect = new Rectangle(new Point(0, 0),
                                            new Size(20, 20));

            chooses[1].text = "合并会话窗口";
            chooses[1].rect = new Rectangle(new Point(0, 20),
                                           new Size(20, 20));

            chooses[2].text = "启动消息同步模式";
            chooses[2].rect = new Rectangle(new Point(0, 40),
                                            new Size(20, 20));

            chooses[3].text = "启动场景秀模式";
            chooses[3].rect = new Rectangle(new Point(0, 60),
                                            new Size(20, 20));

            chooses[4].text = "音视频通话设置";
            chooses[4].rect = new Rectangle(new Point(0, 80),
                                            new Size(20, 20));

            chooses[5].text = "更多设置";
            chooses[5].rect = new Rectangle(new Point(0, 100),
                                            new Size(20, 20));

            itemShadow = new ItemShadow();
            itemShadow.Location = this.Location;
            itemShadow.TopMost = true;
            
            
        }
        #endregion

        #region 选择项随事件绘图
        private void DisplayTextForm_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        public void Draw(Graphics g)
        {
            Point textPos = new Point(15, 15);
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            int count = 0;
            for (int i = 0; i < chooses.Length; i++)
            {
                Font font = new Font("宋体", 10);
                SizeF sizeF = g.MeasureString(chooses[i].text, font, 500, sf);
                Size size = System.Drawing.Size.Ceiling(sizeF);
                g.DrawString(chooses[i].text, font, Brushes.Black, textPos);
                textPos.Y = textPos.Y + size.Height + 19;
            }
        }

        private void DisplayTextForm_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.Location;
            for (int i = 0; i < chooses.Length; i++)
            {
                if (chooses[i].rect.Contains(mousePoint))
                {
                    Invalidate(chooses[i].rect);
                }
            }
        }
        #endregion

        #region 当鼠标停留在选择项的时候显示阴影
        private void ShowItemShadow(object sender, MouseEventArgs e)
        {
            if (null == this) return;
            if (false == this.Visible) return;
            
            Point mousePos = e.Location;
            for(int i = 0; i < globalItemPos.Length; i++)
            { 
                if(globalItemPos[i].Contains(mousePos))
                {
                    itemShadow.Location = globalItemPos[i].Location;
                    itemShadow.Size = globalItemPos[i].Size;
                }
            }
        }

        private void DrawShadow(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(new Point(0, 100), new Size(50, 50));
            g.FillRectangle(new SolidBrush(Color.FromArgb(2,Color.LightGreen)), rect);
            uint ExdStyle = win32.GetWindowLong(this.Handle, win32.GWL_EXSTYLE);
            win32.SetWindowLong(this.Handle, win32.GWL_EXSTYLE, win32.WS_EX_TRANSPARENT | win32.WS_EX_LAYERED);
            win32.SetLayeredWindowAttributes(this.Handle, 0XFFFFFF, 255, 3);
        }

        public void SetVisible()
        {
            this.Show();
            itemShadow.Show();
        }

        
        Rectangle[] globalItemPos = new Rectangle[6] { new Rectangle(new Point(1138, 260), new Size(169, 40)),
                                                       new Rectangle(new Point(1138, 305), new Size(169, 40)),
                                                       new Rectangle(new Point(1138, 349), new Size(169, 40)),
                                                       new Rectangle(new Point(1138, 389), new Size(169, 40)),
                                                       new Rectangle(new Point(1138, 429), new Size(169, 40)),
                                                       new Rectangle(new Point(1138, 469), new Size(169, 40))  
                                                    };
        
        #endregion      
    }
}
