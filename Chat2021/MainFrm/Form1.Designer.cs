namespace Chat2021.MainFrm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chatItem1 = new Chat2021.MainFrm.ChatItem();
            this.SuspendLayout();
            // 
            // chatItem1
            // 
            this.chatItem1.BackColor = System.Drawing.Color.White;
            this.chatItem1.Location = new System.Drawing.Point(179, 56);
            this.chatItem1.Name = "chatItem1";
            this.chatItem1.Size = new System.Drawing.Size(458, 475);
            this.chatItem1.TabIndex = 0;
            this.chatItem1.Text = resources.GetString("chatItem1.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.chatItem1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ChatItem chatItem1;
    }
}