namespace Chat2021.LogFrm
{
    partial class KeyboardFrm
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
            this.userControl11 = new keyboard.UserControl1();
            this.roundButton1 = new Chat2021.LogFrm.RoundButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(286, 161);
            this.userControl11.Margin = new System.Windows.Forms.Padding(2);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(455, 192);
            this.userControl11.TabIndex = 1;
            // 
            // roundButton1
            // 
            this.roundButton1.ControlState = Chat2021.LogFrm.ControlState.Normal;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(0)))), ((int)(((byte)(224)))));
            this.roundButton1.Location = new System.Drawing.Point(363, 60);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.roundButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.roundButton1.Radius = 15;
            this.roundButton1.Size = new System.Drawing.Size(75, 73);
            this.roundButton1.TabIndex = 2;
            this.roundButton1.Text = "roundButton1";
            this.roundButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(345, 359);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(95, 16);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // KeyboardFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.userControl11);
            this.Name = "KeyboardFrm";
            this.Text = "KeyboardFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private keyboard.UserControl1 userControl11;
        private RoundButton roundButton1;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}