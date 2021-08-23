using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using Chat2021.Mysql;
using udp_ns;

namespace Chat2021.ChatFrm
{
    public partial class ChatFrm : Form
    {
        #region value

        //关闭按钮，最大化按钮，最小化按钮，窗口设置按钮
        private Point mousePos = new Point(-1, -1);
        private Bitmap maxBtnBackGround;
        private Bitmap minBtnBackGround;
        private Bitmap SetBtnBackGround;
        private Chat2021.Mysql.Mysql mySql = Chat2021.Mysql.Mysql.getInstance();
        private Udp udp = Udp.GetInstance();

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
            InitVar();
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
            Rectangle rect;
            StringFormat sf = new StringFormat();

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            rect = new Rectangle(new Point(0, 0),
                                           new Size(this.Width, 50));

            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            SizeF sizeF = g.MeasureString(userName, new Font("宋体", 10));
            Size size = new Size((int)sizeF.Width, (int)sizeF.Height);
            Point point = new Point();
            point.X = (rect.X + rect.Size.Width) / 2 - (int)(sizeF.Width / 2);
            point.Y = (rect.Y + rect.Size.Height) / 2 - (int)(sizeF.Height / 2);
            Rectangle iconRect = new Rectangle(new Point(0, 0),
                                               new Size(50, 50));

            g.DrawImage(backGround, rect);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msg, time, head;

            msg = inputTextBox.Text;

            if (null == msg)
            {
                return;
            }

            time = DateTime.Now.ToUniversalTime().ToString();
            head = "刘奇" + " " + time;

            bool result = mySql.addMsg(msg, head);

            if(true == result)
            {
                inputTextBox.Text = "";
                msgBox1.SetSliderBottom();
            }
        }
    }
}
