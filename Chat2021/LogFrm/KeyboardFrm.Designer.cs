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
            // KeyboardFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userControl11);
            this.Name = "KeyboardFrm";
            this.Text = "KeyboardFrm";
            this.ResumeLayout(false);

        }

        #endregion
        private keyboard.UserControl1 userControl11;
    }
}