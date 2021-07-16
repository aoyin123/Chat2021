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

namespace keyboard
{
    public partial class KeyboardUserControl : UserControl
    {

        #region 变量
        
        private System.Windows.Controls.TextBox displayTextBox;
        private KeyboardBtn1[,] row = new KeyboardBtn1[4, 13];
        private bool isEnable = true;

        #endregion

        #region 初始化鼠标按键
        private void InitBtn()
        {
            InitRow3AndRow4Btn();
            InitRow2Btn();
            InitRow1Btn();
        }

        private void InitRow3AndRow4Btn()
        {
            string[] str1 = new string[] { "uvwxyznopqrst", "hijklmabcdefg" };
            string letter = null;
            for (int i = 2; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    letter = str1[i - 2].Substring(j, 1);
                    row[i, j] = CreatButton(letter, null, i, j);
                    row[i, j].MouseDown += OperateDisplayTextBox;
                    this.Controls.Add(row[i, j]);
                }
            }
        }

        private void InitRow2Btn()
        {
            string[] str3 = new string[] { "6^", "7&", "8*", "9(", "0)", "`~", "1!", "2@", "3#", "4$", "5%" };
            for (int i = 0; i < 10; i++)
            {
                row[0, i] = CreatButton(str3[i][0].ToString(), str3[i][1].ToString(), 0, i);
                row[0, i].MouseDown += OperateDisplayTextBox;
                this.Controls.Add(row[0, i]);
            }
            row[0, 10] = CreatButton(null, "箭头", 0, 10);
            row[0, 10].MouseDown += OperateDisplayTextBox;
            row[0, 10].Size = new Size(68, 30);
            this.Controls.Add(row[0, 10]);
        }

        private void InitRow1Btn()
        {
            string[] str2 = new string[] { "=+", @"\|", "[{", "]}", ";:", @"'\", ",<", ".>", "/?", "-—" };
            for (int i = 0; i < 10; i++)
            {
                row[1, i] = CreatButton(str2[i][0].ToString(), str2[i][1].ToString(), 1, i);
                row[1, i].MouseDown += OperateDisplayTextBox;
                this.Controls.Add(row[1, i]);
            }
            row[2, 0] = new KeyboardBtn1();
            row[2, 0].Text2 = "Shift";
            row[2, 0].Location = new Point(3, 38);
            row[2, 0].Size = new Size(40, 30);
            row[2, 0].MouseDown += OperateDisplayTextBox;
            this.Controls.Add(row[2, 0]);
            row[2, 11] = new KeyboardBtn1();
            row[2, 11].Text2 = "Caps Lock";
            row[2, 11].Size = new Size(65, 31);
            row[2, 11].Location = new Point(370, 38);
            row[2, 11].MouseDown += OperateDisplayTextBox;
            this.Controls.Add(row[2, 11]);
        }



        private static KeyboardBtn1 CreatButton(string text1, string text2, int row, int col)
        {
            KeyboardBtn1 keyboardBtn = new KeyboardBtn1();
            Point posBtn = new Point();
            keyboardBtn.Text1 = text1;
            keyboardBtn.Text2 = text2;
            
            if(row == 0)
            {
                posBtn.Y = 5;
                posBtn.X = 11 + col * 4 + col * 31;
            }
            else if(row == 1)
            {
                posBtn.Y = 38;
                posBtn.X = 48 + col * 2 + 30 * col;
            }
            if (row == 2)
            {
                posBtn.Y = 71;
                posBtn.X = 7 + col * 30 + col * 4;
            }
            else if (row == 3)
            {
                posBtn.Y = 104;
                posBtn.X = 7 + col * 30 + col * 4;
            }
            keyboardBtn.Size = new Size(30, 30);
            keyboardBtn.Location = posBtn;
            return keyboardBtn;
        }
        
        private void OperateDisplayTextBox(object sender, MouseEventArgs e)
        {
            KeyboardBtn1 keyboardBtn = (KeyboardBtn1)sender;
            if(isEnable == false)
            {
                if(keyboardBtn.Text2 == "Caps Lock")
                {
                    isEnable = true;
                }
            }
            else
            {
                if(keyboardBtn.Text2 == "Caps Lock")
                {
                    isEnable = false;
                }
                else if (keyboardBtn.Text2 == "箭头")
                {
                    displayTextBox.Text = SubStr(displayTextBox.Text);
                }
                else if (keyboardBtn.Text2 == "Shift")
                {
                    UpperBtnLetter();
                }
                else
                {
                    AddLetter(keyboardBtn);
                }

            }
        }

        private string SubStr(string str)
        {
            if (str.Length == 0)
                return "";
            else
            {
                return str.Substring(0, str.Length - 1);
            }
        }

        private void UpperBtnLetter()
        {
            for(int i = 2; i < 4; i++)
            {
                for(int j = 0; j < 13; j++)
                {
                    row[i, j].IsUpper = !row[i, j].IsUpper;
                    
                }
            }
        }

        private void AddLetter(KeyboardBtn1 keyboardBtn)
        {
            string str = keyboardBtn.Text1;
            if (keyboardBtn.IsUpper == true)
            {
                displayTextBox.Text += keyboardBtn.Text1.ToUpper();
            }
            else
            {
                displayTextBox.Text += keyboardBtn.Text1;
            }
        }
        #endregion

        #region 初始化界面
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        public KeyboardUserControl(System.Windows.Controls.TextBox textBox)
        {
            InitializeComponent();
            this.displayTextBox = textBox;
            InitBtn();
            this.Region = GetRoundedRegion(new Rectangle(0, 0, this.Width, this.Height), 4);
        }

        /// <summary>
        /// 绘制圆角路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private Region GetRoundedRegion(Rectangle rect, int radius)
        {
            int diameter = radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return new Region(path);
        }
        #endregion
    }
}
