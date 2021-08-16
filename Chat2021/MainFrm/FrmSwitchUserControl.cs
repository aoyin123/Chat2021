using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections;

namespace Chat2021.MainFrm
{
    public partial class FrmSwitchUserControl : UserControl
    {
        #region 变量
        private Hashtable nameToSize = new Hashtable();
        private Font font = new Font("思源宋体", 10);
        private String mouseMoveBtnName;
        private string mouseDownBtnName = "消息";
        private Button lastDrawBtn = null;
        public delegate void Func(string str);
        public event Func onActivity;
        #endregion

        #region 初始化
        public FrmSwitchUserControl()
        {
            InitializeComponent();

            nameToSize.Add("消息", new SizeF());
            nameToSize.Add("联系人", new SizeF());
            nameToSize.Add("空间", new SizeF());
        }
        #endregion

        #region 按钮响应鼠标事件
        private void mouseDown(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;  
            mouseDownBtnName = (string)btn.Tag;
            lastDrawBtn.Invalidate();
            onActivity(mouseDownBtnName);
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            mouseMoveBtnName = (string)btn.Tag;
        }

        
        private void mouseLeave(object sender, EventArgs e)
        {
            mouseMoveBtnName = "";
        }

        #endregion

        #region 按钮上绘图
        /// <summary>
        /// 在按钮上绘制标识以及下划线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawTagAndUnderline(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;
            SizeF strSize = (SizeF)nameToSize[btn.Tag];
            int x = (btn.Width - (int)strSize.Width) / 2;
            int y = (btn.Height - (int)strSize.Height) / 2;
            Point strPos = new Point(x, y);
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(103, 120, 138));
            Pen pen = new Pen(solidBrush, 2);
            Point underLineStartPos = new Point(btn.Width / 14, btn.Height - 2);
            Point underLineEndPos = new Point(btn.Width - btn.Width / 14, btn.Height - 2);
            string tag = (string)btn.Tag;

            //绘画下划线
            g.SmoothingMode = SmoothingMode.HighQuality;
            if (tag == mouseDownBtnName)
            {
                lastDrawBtn = btn;
                g.DrawLine(pen, underLineStartPos, underLineEndPos);
            }
            else if (tag == mouseMoveBtnName)
            {
                solidBrush = new SolidBrush(Color.Black);
            }
            else
            {
                solidBrush = new SolidBrush(Color.FromArgb(86, 105, 125));
            }

            //绘画标识
            g.DrawString(tag, font, solidBrush, strPos);

            solidBrush.Dispose();
            pen.Dispose();
        }

        /// <summary>
        /// 尺寸变化后改变绘图
        /// </summary>
        /// <param name="e">事件拥有者</param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Graphics g = msgswtBtn.CreateGraphics();
            StringFormat sf = new StringFormat();

            msgswtBtn.Width = contactsBtn.Width = spaceBtn.Width = this.Width / 3;
            msgswtBtn.Height = contactsBtn.Height = spaceBtn.Height = this.Height;

            
            
            g.PageUnit = GraphicsUnit.Pixel;
            g.SmoothingMode = SmoothingMode.HighQuality;
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            ArrayList akeys = new ArrayList(nameToSize.Keys);
            foreach(string name in akeys)
            {
                nameToSize[name] = g.MeasureString(name, font, 500, sf);
            }
        }
        #endregion
    }
}
