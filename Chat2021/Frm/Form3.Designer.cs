namespace Chat2021.Frm
{
    partial class Form3
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
            this.chatItem1 = new Chat2021.Frm.ChatItem();
            this.SuspendLayout();
            // 
            // chatItem1
            // 
            this.chatItem1.BackColor = System.Drawing.Color.White;
            this.chatItem1.Location = new System.Drawing.Point(155, 21);
            this.chatItem1.Name = "chatItem1";
            this.chatItem1.Size = new System.Drawing.Size(452, 517);
            this.chatItem1.TabIndex = 0;
            this.chatItem1.Text = "chatItem1";
            this.chatItem1.TitleBru = null;
            this.chatItem1.TitleFont = null;
            this.chatItem1.TitleSize = new System.Drawing.Size(0, 0);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 566);
            this.Controls.Add(this.chatItem1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private ChatItem chatItem1;
    }
}