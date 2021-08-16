using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    class ChatItem : Control
    {
        #region value
        private Groups groups;
        private Slider slider;
        private Size sliderSize = new Size(10, 50);
        private Point mousePos;
        #endregion

        #region init
        public ChatItem()
        {   
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(SliderMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(SliderMouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.SliderMouseWheel);

            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            slider = new Slider(new Point(this.Width - 10, 0), sliderSize, this);
            groups = new Groups(this);
        }


        #endregion init

        #region MouseUpEvent
        private void SliderMouseUp(object sender, MouseEventArgs e)
        {
            slider.IsMouseDownOnSlider = false;
        }

        #endregion

        #region MouseWheelEvent
        private double GetMouseMoveDistance(Point nowMousePos)
        {
            double distance = mousePos.Y - nowMousePos.Y;
            mousePos = nowMousePos;
            return distance;
        }

        /// <summary>
        /// 用鼠标移动滑轮移动时带来画面变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseMove(object sender, MouseEventArgs e)
        {
            if (slider.IsMouseDownOnSlider == true)
            {
                double distance = GetMouseMoveDistance(e.Location);
                slider.MoveSlider(distance);
            }
        }

        /// <summary>
        /// 鼠标滑轮移动时带动滑轮移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderMouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                slider.Down();
            }
            else
            {
                slider.Up();
            }
        }
        #endregion

        #region PaintEvent
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TranslateTransform(0, -slider.SliderVal);

            //显示组的全部信息
            groups.Draw(g);

            //画滑块
            if (true == groups.IsDisplayGroupNumber())
            {
                slider.Draw(g);
            }
        }
        #endregion

        #region MouseDown
        /// <summary>
        /// 鼠标点击事件 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            base.OnMouseDown(e);
            int width = this.Width;
            Point mouseOnGroupPos = new Point(e.Location.X, e.Location.Y + slider.SliderVal);

            SliderMouseDown(e.Location);
            MouseMoveOnGroupNumber(mouseOnGroupPos);
            MouseClickedGroupName(mouseOnGroupPos);
        }

        private void SliderMouseDown(Point p)
        {
            Point sliderToChatListBox = new Point(slider.Pos.X, slider.Pos.Y - slider.SliderVal);
            Rectangle rect = new Rectangle(sliderToChatListBox, new Size(slider.Width, slider.Height));
            if (rect.Contains(p))
            {
                slider.IsMouseDownOnSlider = true;
                mousePos = p;
            }
        }
        private void MouseClickedGroupName(Point mouseOnGroupPos)
        {
            Group group = groups.GetSelectGroupByClickedGroupName(mouseOnGroupPos);

            if(null == group)
            {
                return;
            }

            if (slider.IsMouseDownOnSlider == true)
            {
                return;
            }

            
            group.stopDrawBackColor = true;

            if (false == group.IsDrawGroupName)
            {
                groups.DisplayGroup(group);
                slider.DisplayContentLength = groups.len - this.Height;
            }
            else
            {
                groups.HideGrop(group);
                slider.DisplayContentLength = groups.len - this.Height;
            }

            groups.lastStopDrawBackGround = group;
            group.isDrawGroupNameMouseMoveBackGround = false;
            slider.DisplayContentLength = groups.len - this.Height;

            this.Invalidate();
        }

        private void MouseMoveOnGroupNumber(Point mouseOnGroupPos)
        {
            groups.DisPlayMouseDownEffect(mouseOnGroupPos);
        }
        #endregion

        #region MouseMoveEventHandler
        /// <summary>
        /// 鼠标移动事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point mouseOnGroupPos = new Point(e.Location.X, e.Location.Y + slider.SliderVal);

            MouseMoveGroupNumber(mouseOnGroupPos);
            MouseMoveOnGroupName(mouseOnGroupPos);
        }

        private void MouseMoveGroupNumber(Point mouseOnGroupPos)
        {
            if (slider.IsMouseDownOnSlider == false)
            {
                groups.DisplayMouseMoveEffect(mouseOnGroupPos);
            }
        }

        private void MouseMoveOnGroupName(Point mouseOnGroupPos)
        {
            Group group = groups.GetSelectGroupByClickedGroupName(mouseOnGroupPos);
            if (group != null)
            {
                if ((groups.lastStopDrawBackGround != group) &&
                    (groups.lastStopDrawBackGround != null))
                {
                    groups.lastStopDrawBackGround.stopDrawBackColor = false;
                }
                groups.DisPlayOneGroupNameBackGround(group);
            }
        }

        #endregion

        #region MouseLeaveEventHandler
        /// <summary>
        /// 鼠标离开事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            groups.NoDisPlayGroupNameBackGround();
            this.Invalidate();
        }
        #endregion
    }

}
