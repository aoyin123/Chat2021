namespace Chat2021.LogFrm
{
    partial class LogFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PlayVedioPic = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.roundButton1 = new Chat2021.LogFrm.RoundButton();
            this.roundButtonCopy1 = new PulseButtonTest.RoundButtonCopy();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new Chat2021.LogFrm.UserControl1();
            this.pulseButton1 = new PulseButton.PulseButton();
            ((System.ComponentModel.ISupportInitialize)(this.PlayVedioPic)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayVedioPic
            // 
            this.PlayVedioPic.Location = new System.Drawing.Point(0, 0);
            this.PlayVedioPic.Margin = new System.Windows.Forms.Padding(2);
            this.PlayVedioPic.Name = "PlayVedioPic";
            this.PlayVedioPic.Size = new System.Drawing.Size(75, 40);
            this.PlayVedioPic.TabIndex = 0;
            this.PlayVedioPic.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 62);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // roundButton1
            // 
            this.roundButton1.ControlState = Chat2021.LogFrm.ControlState.Normal;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(0)))), ((int)(((byte)(224)))));
            this.roundButton1.Location = new System.Drawing.Point(218, 112);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.roundButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.roundButton1.Radius = 15;
            this.roundButton1.Size = new System.Drawing.Size(75, 23);
            this.roundButton1.TabIndex = 4;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = true;
            // 
            // roundButtonCopy1
            // 
            this.roundButtonCopy1.BackColor = System.Drawing.Color.Blue;
            this.roundButtonCopy1.Location = new System.Drawing.Point(361, 112);
            this.roundButtonCopy1.Name = "roundButtonCopy1";
            this.roundButtonCopy1.Size = new System.Drawing.Size(75, 37);
            this.roundButtonCopy1.TabIndex = 3;
            this.roundButtonCopy1.Text = "123";
            this.roundButtonCopy1.UseVisualStyleBackColor = false;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(42, 205);
            this.elementHost1.Margin = new System.Windows.Forms.Padding(2);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(150, 80);
            this.elementHost1.TabIndex = 1;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // pulseButton1
            // 
            this.pulseButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pulseButton1.Location = new System.Drawing.Point(76, 99);
            this.pulseButton1.Name = "pulseButton1";
            this.pulseButton1.PulseSpeed = 0.3F;
            this.pulseButton1.Size = new System.Drawing.Size(40, 40);
            this.pulseButton1.TabIndex = 5;
            this.pulseButton1.Text = "pulseButton1";
            this.pulseButton1.UseVisualStyleBackColor = true;
            // 
            // LogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.pulseButton1);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.roundButtonCopy1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.PlayVedioPic);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LogFrm";
            this.Text = "LogFrm";
            ((System.ComponentModel.ISupportInitialize)(this.PlayVedioPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlayVedioPic;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private UserControl1 userControl11;
        private System.Windows.Forms.Button button1;
        private PulseButtonTest.RoundButtonCopy roundButtonCopy1;
        private RoundButton roundButton1;
        private PulseButton.PulseButton pulseButton1;
    }
}