using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keyboard
{
    class KeyboardBtn1 : Button
    {
        #region 变量
        enum MouseModel
        {
            mouseDown,
            mouseLeave,
            mouseHover,
        }
        private MouseModel mouseModel = MouseModel.mouseLeave;
        private SolidBrush upRegionSolidBrush = new SolidBrush(Color.FromArgb(57, 187, 239));
        private SolidBrush downRegionSolidBrush = new SolidBrush(Color.FromArgb(39, 163, 231));
        private Rectangle upRegion;
        private Rectangle downRegion;
        private Point p1 = new Point(1, 28);
        private Point p2 = new Point(29, 28);
        #endregion

        #region 界面属性
        private Color _upRegionColor;
        /// <summary>
        /// 按钮上半区域的颜色
        /// </summary>
        [Browsable(true)]
        public Color UpRegionColor
        {
            get { return _upRegionColor; }
            set 
            { 
                _upRegionColor = value;
                upRegionSolidBrush = new SolidBrush(_upRegionColor);
            }
        }

        public Hashtable strToPos = new Hashtable();
        /// <summary>
        /// 添加在按钮上显示的字符及其位置
        /// </summary>
        

        private Color lineColor = Color.FromArgb(212, 232, 250);
        /// <summary>
        /// 设置按钮下方线的颜色
        /// </summary>
        public Color LineColor
        {
            set { lineColor = value; }
        }

        private Color _downRegionColor;
        /// <summary>
        /// 设置或获取按钮下半区域的颜色
        /// </summary>
        [Browsable(true)]
        public Color DownRegionColor
        { 
            get { return _downRegionColor; }
            set 
            { 
                _downRegionColor = value;
                downRegionSolidBrush = new SolidBrush(_downRegionColor);
            }
        }

        private Point strPos = new Point(10,9);
        /// <summary>
        /// 设置或获取字体的位置
        /// </summary>
        [Browsable(true)]
        public Point StrPos
        {
            get { return strPos; }
            set
            {
                strPos = value;
                this.Invalidate();
            }
        }

        private Font strFont = new Font("宋体", 10);
        /// <summary>
        /// 设置字体的样式
        /// </summary>
        [Browsable(true)]
        public Font StrFont
        {
            set { strFont = value; }
        }

        private string text1;
        /// <summary>
        /// 设置按钮上显示的文本
        /// </summary>
        public string Text1
        {
            set { text1 = value; }
            get { return text1; }
        }

        private string text2;

        public string Text2
        {
            set { text2 = value; }
            get { return text2; }
        }

        private bool isUpper = false;
        public bool IsUpper
        {
            set { 
                isUpper = value;
                this.Invalidate();
            }
            get { return isUpper; }
        }

        
        #endregion

        #region 初始化
        public KeyboardBtn1()
        {
            SetDefaultColor();
            SetEventHandler();
        }

        private void SetDefaultColor()
        {
            _upRegionColor = Color.FromArgb(57, 187, 239);
            _downRegionColor = Color.FromArgb(39, 163, 231);
        }

        private void SetEventHandler()
        {
            this.Paint += DrawCustomerEventHandler;
            this.Paint += DrawMousePressEventHandler;
            this.Paint += DrawMouseHoverEventHandler;
            this.Paint += DrawStr;
            
            
            this.MouseMove += BtnMouseMove;
            this.MouseLeave += BtnMouseLeave;
            this.MouseDown += BtnMouseDown;
            this.MouseUp += BtnMouseUp;
        }
        #endregion

        #region 消息句柄

        private void DrawCustomerEventHandler(object sender, PaintEventArgs e)
        {
            if (mouseModel.Equals(MouseModel.mouseLeave))
            {
                Graphics g = e.Graphics;
                g.FillRectangle(Brushes.White, this.ClientRectangle);
                Pen pen = new Pen(lineColor);
                g.DrawLine(pen, p1, p2);
                Color color = Color.FromArgb(187, 207, 232);
                SolidBrush solidBrush = new SolidBrush(color);
                g.FillRectangle(solidBrush, new Rectangle(new Point(0, this.Height - 1), new Size(1, 1)));
                g.FillRectangle(solidBrush, new Rectangle(new Point(0, 0), new Size(1, 1)));
                g.FillRectangle(solidBrush, new Rectangle(new Point(this.Width - 1, 0), new Size(1, 1)));
                g.FillRectangle(solidBrush, new Rectangle(new Point(this.Height - 1, this.Width - 1), new Size(1, 1)));
            }
        }

        private void DrawStr(object sender, PaintEventArgs e)
        {
            if (null == text2)
            {
                if (isUpper == true)
                {
                    e.Graphics.DrawString(text1.ToUpper(), strFont, Brushes.Black, new Point(2, 9));
                    return;
                }
                else
                {
                    e.Graphics.DrawString(text1, strFont, Brushes.Black, new Point(2, 9));
                }
            }
            else
            {

                if (text2.Equals("箭头"))
                {
                    Pen p = new Pen(Color.Black, 1);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    e.Graphics.DrawLine(p, 36, 14, 16, 14);
                    return;
                }
                else if (text2.Equals("Caps Lock"))
                {
                    e.Graphics.DrawString("Caps Lock", new Font("宋体", 8), Brushes.Black, new Point(0, 10));
                    return;
                }
                else if(text2.Equals("Shift"))
                {
                    e.Graphics.DrawString("Shift", new Font("宋体", 8), Brushes.Black, new Point(0, 10));
                    return;
                }
                else
                {
                    e.Graphics.DrawString(text1, strFont, Brushes.Black, new Point(0, 10));
                    e.Graphics.DrawString(text2, strFont, Brushes.Black, new Point(10, 3));
                }
            }
        }

        private void DrawMousePressEventHandler(object sender, PaintEventArgs e)
        {
            if (mouseModel.Equals(MouseModel.mouseDown))
            {
                Graphics g = e.Graphics;
                g.FillRectangle(downRegionSolidBrush, upRegion);
                g.FillRectangle(upRegionSolidBrush, downRegion);
            }
        }

        private void DrawMouseHoverEventHandler(object sender, PaintEventArgs e)
        {
            if (mouseModel.Equals(MouseModel.mouseHover))
            {
                Graphics g = e.Graphics;
                g.FillRectangle(downRegionSolidBrush, downRegion);
                g.FillRectangle(upRegionSolidBrush, upRegion);
            }
        }

        private void BtnMouseMove(object sender, MouseEventArgs e)
        {
            
            mouseModel = MouseModel.mouseHover;
            this.Invalidate();
        }

        private void BtnMouseLeave(object sender, EventArgs e)
        {
            mouseModel = MouseModel.mouseLeave;
            this.Invalidate();
        }

        private void BtnMouseUp(object sender, MouseEventArgs e)
        {
            mouseModel = MouseModel.mouseHover;
            this.Invalidate();
        }

        private void BtnMouseDown(object sender, MouseEventArgs e)
        {
            mouseModel = MouseModel.mouseDown;
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            int width = this.Width - 1;
            int height = this.Height - 1;
            upRegion = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height / 2));
            downRegion = new Rectangle(new Point(0, this.Height / 2), new Size(this.Width, this.Height / 2));
            base.OnSizeChanged(e);
        }
        #endregion

    }

    
}
