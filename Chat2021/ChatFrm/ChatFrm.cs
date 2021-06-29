using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace Chat2021.ChatFrm
{
    public partial class ChatFrm : Form
    {
        #region value

        //关闭按钮，最大化按钮，最小化按钮，窗口设置按钮
        private Button closeBtn = new Button();
        private Button maxBtn = new Button();
        private Button minBtn = new Button();
        private Button setBtn = new Button();
        private Point mousePos = new Point(-1, -1);
        private Image[] images = new Image[8] { Resource.表情,
                                                Resource.动图,
                                                Resource.截屏,
                                                Resource.上传文件,
                                                Resource.发送腾讯文档,
                                                Resource.发送图片,
                                                Resource.消息接收设置,
                                                Resource.更多
                                              };
        Bitmap maxBtnBackGround;
        Bitmap minBtnBackGround;
        Bitmap SetBtnBackGround;

        private MoreForm moreForm;
        private enum MouseFlag
        {
            onMenuItem1,
            onMenuItem2,
            onMenuItem3,
            onMenuItem4,
            onMenuItem5,
            onMenuItem6,
            onMenuItem7,
            onMenuItem8,
            none
        }
        private Hashtable hashtable = new Hashtable();
        private bool isMousePresed = false;
        private Rectangle[] rects = new Rectangle[4];
        private Hashtable layout = new Hashtable();
        #endregion

        #region Init
        public ChatFrm()
        {
            InitializeComponent();
            InitInterface();
            InitVar();
            InitEventHandler();
        }

        private void InitInterface()
        {
            InitForm();
            InitControl();
        }

        private void InitForm()
        {
            this.BackColor = Color.Red;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(717, 617);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitControl()
        {
            //关闭按钮
            closeBtn.Size = new Size(40, 40);
            closeBtn.BackColor = Color.Red;
            closeBtn.Visible = false;
            closeBtn.Location = new Point(675, 1);
            closeBtn.FlatStyle = FlatStyle.Flat;
            closeBtn.FlatAppearance.BorderColor = Color.Red;

            //最大化按钮
            maxBtn.Size = new Size(40, 40);
            maxBtn.BackColor = Color.Transparent;
            maxBtn.Visible = false;
            maxBtn.Location = new Point(635, 1);
            maxBtn.FlatStyle = FlatStyle.Flat;
            maxBtn.FlatAppearance.BorderColor = Color.Red;

            //最小化按钮
            minBtn.Size = new Size(40, 40);
            minBtn.BackColor = Color.Transparent;
            minBtn.Visible = false;
            minBtn.Location = new Point(595, 1);
            minBtn.FlatStyle = FlatStyle.Flat;
            minBtn.FlatAppearance.BorderColor = Color.Red;

            //窗口设置按钮
            setBtn.Size = new Size(40, 40);
            setBtn.BackColor = Color.Transparent;
            setBtn.Visible = false;
            setBtn.Location = new Point(555, 1);
            setBtn.FlatStyle = FlatStyle.Flat;
            setBtn.FlatAppearance.BorderColor = Color.Red;

            //menuStrip背景颜色设置
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;

            //menuStripItem图片，背景颜色设置
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

            this.Controls.Add(closeBtn);
            this.Controls.Add(maxBtn);
            this.Controls.Add(minBtn);
            this.Controls.Add(setBtn);
        }



        private void InitEventHandler()
        {
            //窗体随鼠标运动事件
            this.MouseMove += MouseMoveEventHandler_MoveFrmWithMouse;
            this.MouseDown += MouseDownEventHandler_MoveFrmWithMouse; 
            this.MouseUp += MouseUpEventHandler_MoveFrmWithMouse;

            //窗帘
            this.Paint += DrawCurtain;

            //关闭窗口事件
            this.MouseMove += MouseMoveEventHandler_CloseFrm;
            this.closeBtn.MouseLeave += CloseBtnMouseLeaveEventHandler_CloseFrm;
            this.closeBtn.MouseDown += MouseDownEventHandler_CloseFrm;
            this.closeBtn.Paint += DrawCloseBtnHandler;

            //最大化窗口事件
            this.MouseMove += MouseMoveEventHandler_MaxFrm;
            this.maxBtn.MouseLeave += MaxBtnMouseLeaveEventHandler_MaxFrm;
            this.maxBtn.MouseDown += MaxBtnMouseDownEventHandler_MaxFrm;
            this.maxBtn.Paint += DrawMaxBtnHandler;

            //最小化窗口事件
            this.MouseMove += MouseMoveEventHandler_MinFrm;
            this.minBtn.MouseLeave += MaxBtnMouseLeaveEventHandler_MinFrm;
            this.minBtn.MouseDown += MaxBtnMouseDownEventHandler_MinFrm;

            //设置事件
            this.MouseMove += MouseMoveEventHandler_SetBtn;
            this.setBtn.MouseLeave += MaxBtnMouseLeaveEventHandler_SetBtn;
            this.setBtn.MouseDown += MaxBtnMouseDownEventHandler_SetBtn;
        }

        private void InitVar()
        {
            hashtable.Add(MouseFlag.onMenuItem1, "选择表情");
            hashtable.Add(MouseFlag.onMenuItem2, "选择热图");
            hashtable.Add(MouseFlag.onMenuItem3, "");
            hashtable.Add(MouseFlag.onMenuItem4, "");
            hashtable.Add(MouseFlag.onMenuItem5, "发送腾讯文档");
            hashtable.Add(MouseFlag.onMenuItem6, "");
            hashtable.Add(MouseFlag.onMenuItem7, "向好友发送窗口抖动");

            rects[0] = new Rectangle(setBtn.Location, setBtn.Size);
            rects[1] = new Rectangle(minBtn.Location, minBtn.Size);
            rects[2] = new Rectangle(maxBtn.Location, maxBtn.Size);
            rects[3] = new Rectangle(closeBtn.Location, closeBtn.Size);

            maxBtnBackGround = DealImage.GetPartOfImage(Resource.Curtain, maxBtn.Width, maxBtn.Height, maxBtn.Location.X, maxBtn.Location.Y);
            maxBtnBackGround = DealImage.MakePicDarken(maxBtnBackGround);
            

            minBtnBackGround = DealImage.GetPartOfImage(Resource.Curtain, minBtn.Width, minBtn.Height, minBtn.Location.X, minBtn.Location.Y);
            minBtnBackGround = DealImage.MakePicDarken(minBtnBackGround);
            

            SetBtnBackGround = DealImage.GetPartOfImage(Resource.Curtain, setBtn.Width, setBtn.Height, setBtn.Location.X, setBtn.Location.Y);
            SetBtnBackGround = DealImage.MakePicDarken(SetBtnBackGround);
            
        }
        #endregion

        #region 窗帘
        protected void DrawCurtain(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawChatInfoBackGround(g, Resource.Curtain, null, "敖引");
        }

        private void DrawChatInfoBackGround(Graphics g, Bitmap backGround, Bitmap icon, string userName)
        {
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            Rectangle rect = new Rectangle(new Point(0, 0),
                                           new Size(this.Width, 50));
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizeF = g.MeasureString(userName, new Font("宋体", 10));
            Size size = new Size((int)sizeF.Width, (int)sizeF.Height);
            Point point = new Point();
            point.X = (rect.X + rect.Size.Width) / 2 - (int)(sizeF.Width / 2);
            point.Y = (rect.Y + rect.Size.Height) / 2 - (int)(sizeF.Height / 2);
            Rectangle iconRect = new Rectangle(new Point(0, 0),
                                               new Size(50, 50));

            //画背景
            g.DrawImage(backGround, rect);
            //画用户名
            g.DrawString(userName, new Font("宋体", 10), Brushes.White, point);
            g.DrawRectangle(new Pen(Brushes.Red), point.X, point.Y, size.Width, size.Height);
        }

        #endregion

        #region 窗体随鼠标移动
        private void MouseDownEventHandler_MoveFrmWithMouse(object sender, MouseEventArgs e)
        {
            isMousePresed = true;
            Point p = e.Location;
        }
        private void MouseUpEventHandler_MoveFrmWithMouse(object sender, MouseEventArgs e)
        {
            isMousePresed = false;
            mousePos = new Point(-1, -1);
        }

        

        private void MouseMoveEventHandler_MoveFrmWithMouse(object sender, MouseEventArgs e)
        {
            

            if (isMousePresed == false)
            {
                return;
            }
            if (mousePos.Equals(new Point(-1, -1)))
            {
                mousePos = e.Location;
                return;
            }
            else
            {
                Point trans = new Point(e.Location.X - mousePos.X,
                                        e.Location.Y - mousePos.Y);
                this.Location = new Point(this.Location.X + trans.X,
                                          this.Location.Y + trans.Y);
            }
        }
        #endregion

        #region 关闭窗口
        private void MouseMoveEventHandler_CloseFrm(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(rects[3].Contains(p))
            {
                closeBtn.Visible = true;
            }
        }

        private void CloseBtnMouseLeaveEventHandler_CloseFrm(object sender, EventArgs e)
        {
            closeBtn.Visible = false;
        }

        private void MouseDownEventHandler_CloseFrm(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            this.Close();
        }

        private void DrawCloseBtnHandler(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, new Point(12, 16), new Point(26, 29));
            g.DrawLine(pen, new Point(27, 16), new Point(12, 29));
        }

        #endregion

        #region 最大化窗口

        public void DrawMaxBtnBackGround(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(maxBtnBackGround, new Point(0, 0));
        }
        
        private void MouseMoveEventHandler_MaxFrm(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(rects[2].Contains(p))
            {
                maxBtn.Visible = true;
                maxBtn.Paint += DrawMaxBtnBackGround;
            }
        }

        private void MaxBtnMouseLeaveEventHandler_MaxFrm(object sender, EventArgs e)
        {
            maxBtn.Visible = false;
        }

        private void MaxBtnMouseDownEventHandler_MaxFrm(object sender, MouseEventArgs e)
        {
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);
            this.Location = new Point(0, 0);
            this.Width = ScreenArea.Width;
            this.Height = ScreenArea.Height;
        }

        private void DrawMaxBtnHandler(object sender, PaintEventArgs e)
        {

        }

        #endregion

        #region 最小化窗口
        private void MouseMoveEventHandler_MinFrm(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(rects[1].Contains(p))
            {
                minBtn.Visible = true;
                minBtn.BackgroundImage = minBtnBackGround;
            }
        }

        private void MaxBtnMouseLeaveEventHandler_MinFrm(object sender, EventArgs e)
        {
            minBtn.Visible = false;
        }

        private void MaxBtnMouseDownEventHandler_MinFrm(object sender, MouseEventArgs e)
        {
            this.Visible = false;
        }
        #endregion

        #region 设置窗口
        private void MouseMoveEventHandler_SetBtn(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if(rects[0].Contains(p))
            {
                setBtn.Visible = true;
                setBtn.BackgroundImage = SetBtnBackGround;
            }
        }

        private void MaxBtnMouseLeaveEventHandler_SetBtn(object sender, EventArgs e)
        {
            setBtn.Visible = false;
        }
        private void MaxBtnMouseDownEventHandler_SetBtn(object sender, MouseEventArgs e)
        {
            moreForm = new MoreForm(this);
            moreForm.SetFormVisble();
        }



        #endregion

        Point p1 = new Point(12, 16);
        Point p2 = new Point(26, 29);
        Point p3 = new Point(25, 16);
        Point p4 = new Point(12, 29);
        #region debug
        private void ChatFrm_MouseDown(object sender, MouseEventArgs e)
        {
            Point s = closeBtn.Location;
            Point p = e.Location;
            int x = p.X - s.X;
            int y = p.Y - s.Y;
        }

        
        #endregion
    }
}
