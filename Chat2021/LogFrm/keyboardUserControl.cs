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

namespace keyboard
{
    public partial class KeyboardUserControl : UserControl
    {
        string strRow3 = "hijklmabcdefg";
        string strRow4 = "qrstuvwxyznop";
        Point row3StartPoint = new Point(11, 71);
        KeyboardBtn1[] row3 = new KeyboardBtn1[13] { 
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1()
        };

        KeyboardBtn1[] row2 = new KeyboardBtn1[12] {
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1()
        };

        KeyboardBtn1[] row4 = new KeyboardBtn1[13] {
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1()
        };

        KeyboardBtn1[] row1 = new KeyboardBtn1[12]{
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1(),
        new KeyboardBtn1()
        };

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void AddEventHandler()
        {
            for(int i = 0; i < 13; i++)
            {
                row3[i].MouseDown += addLetter;
            }
        }

        private void addLetter(object sender, MouseEventArgs e)
        {
            //加字符到TextBox


            //减字符到TextBox
        }

        private void AddStrToTextBox(TextBox textBox)
        {
            textBox.Text = "A";
        
        }


        public KeyboardUserControl()
        {
            InitializeComponent();
            //this.Size = new Size(448, 137);
            //this.BackColor = Color.FromArgb(27, 147, 217);

            //this.hBtn.Location = new Point(13, 71);
            //this.hBtn.Text = "h";
            //this.hBtn.Size = new Size(31, 30);

            //this.iBtn.Location = new Point(47, 71);
            //this.iBtn.Text = "i";
            //this.iBtn.Size = new Size(31, 30);

            //this.jBtn.Location = new Point(81, 71);
            //this.jBtn.Text = "j";
            //this.jBtn.Size = new Size(31, 30);

            this.hBtn.Visible = false;
            this.iBtn.Visible = false;
            this.jBtn.Visible = false;

            //foreach(KeyboardBtn1 keyboardBtn1 in row3)
            //{
            //    keyboardBtn1.Size = new Size(31, 30);
            //    keyboardBtn1.Text = "f";
            //    keyboardBtn1.Location = new Point(0, 0);
            //    this.Controls.Add(keyboardBtn1);
            //}

            for(int i = 0; i < row3.Length; i++)
            {
                row3[i].Size = new Size(31, 30);
                row3[i].Text = strRow3.Substring(i, 1);
                int gapNum = i;
                int gapWidth = i * 2;
                row3[i].Location = new Point(row3StartPoint.X + i * 31 + gapWidth, 71);
                this.Controls.Add(row3[i]);
            }

            for(int i = 0; i<row4.Length; i++)
            {
                row4[i].Size = new Size(31, 30);
                row4[i].Text = strRow4.Substring(i, 1);
                int gapNum = i;
                int gapWidth = i * 2;
                row4[i].Location = new Point(row3StartPoint.X + i * 31 + gapWidth, 104);
                this.Controls.Add(row4[i]);
            }

            row1[0].strToPos.Add("2", new Point(0, 10));
            row1[0].strToPos.Add("@", new Point(10, 3));

            row1[1].strToPos.Add("3", new Point(0, 10));
            row1[1].strToPos.Add("#", new Point(10, 3));

            row1[2].strToPos.Add("4", new Point(0, 10));
            row1[2].strToPos.Add("$", new Point(10, 3));
            
            row1[3].strToPos.Add("5", new Point(0, 10));
            row1[3].strToPos.Add("%", new Point(10, 3));

            row1[4].strToPos.Add("6", new Point(0, 10));
            row1[4].strToPos.Add("^", new Point(10, 3));
            
            row1[5].strToPos.Add("7", new Point(0, 10));
            row1[5].strToPos.Add("&", new Point(10, 3));

            row1[6].strToPos.Add("8", new Point(0, 10));
            row1[6].strToPos.Add("*", new Point(10, 3));

            row1[7].strToPos.Add("9", new Point(0, 10));
            row1[7].strToPos.Add("(", new Point(10, 3));

            row1[8].strToPos.Add("0", new Point(0, 10));
            row1[8].strToPos.Add(")", new Point(10, 3));

            row1[9].strToPos.Add("`", new Point(0, 10));
            row1[9].strToPos.Add("~", new Point(10, 3));

            row1[10].strToPos.Add("1", new Point(0, 10));
            row1[10].strToPos.Add("!", new Point(10, 3));

            row1[11].strToPos.Add("箭头", new Point(10, 0));

            Point startPosRow1 = new Point(11, 5);
            for(int i = 0;i < 11; i++)
            {
                int gapWidth = i * 2;
                row1[i].Location = new Point(11 + gapWidth + i * 31,5);
                row1[i].Size = new Size(31, 30);
                this.Controls.Add(row1[i]);
            }
            row1[11].Location = new Point(375, 5);
            row1[11].Size = new Size(58, 30);
            this.Controls.Add(row1[11]);


            row2[0].Text = "Shift";
            row2[0].Location = new Point(3, 38);
            row2[0].Size = new Size(50, 30);
            this.Controls.Add(row2[0]);

            Point p1 = new Point(0, 10);
            Point p2 = new Point(10, 3);

            row2[1].strToPos.Add("]", p1);
            row2[1].strToPos.Add("}", p2);

            row2[2].strToPos.Add(";", p1);
            row2[2].strToPos.Add(":", p2);

            row2[3].strToPos.Add("'", p1);
            row2[3].strToPos.Add("\"", p2);

            row2[4].strToPos.Add(",", p1);
            row2[4].strToPos.Add("<", p2);

            row2[5].strToPos.Add(".", p1);
            row2[5].strToPos.Add(">", p2);

            row2[6].strToPos.Add("/", p1);
            row2[6].strToPos.Add("?", p2);

            row2[7].strToPos.Add("-", p1);
            row2[7].strToPos.Add("_", p2);

            row2[8].strToPos.Add("=", p1);
            row2[8].strToPos.Add("+", p2);
            
            row2[9].strToPos.Add(@"\", p1);
            row2[9].strToPos.Add("|", p2);

            row2[10].strToPos.Add("[", p1);
            row2[10].strToPos.Add("{", p2);

            for(int i = 1; i < 11;i++)
            {
                row2[i].Size = new Size(31, 30);
                int gapWidth = i * 2;
                row2[i].Location = new Point(24 + gapWidth + 31 * i, 38);
                this.Controls.Add(row2[i]);
            }

            row2[11].strToPos.Add("Caps Lock",new Point(0, 10) );

            row2[11].Size = new Size(55, 31);
            row2[11].Location = new Point(388, 38);
            this.Controls.Add(row2[11]);



            GraphicsPath FormPath;
            Rectangle rect = new Rectangle(0, 0, 448, 137);
            FormPath = GetRoundedRectPath(rect, 4);
            this.Region = new Region(FormPath);
        }

        /// <summary>
        /// 绘制圆角路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
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
            return path;
        }

    }
}
