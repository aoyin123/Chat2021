namespace Chat2021.Frm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chatListBox1 = new Chat2021.Frm.ChatListBox();
            this.frmSwitchUserControl1 = new Chat2021.Frm.FrmSwitchUserControl();
            this.searchBoxUserControl11 = new Chat2021.Frm.searchBoxUserControl1();
            this.userControl11 = new Chat2021.Frm.UserControl1();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 242);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chatListBox1);
            this.splitContainer1.Size = new System.Drawing.Size(342, 447);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 3;
            // 
            // chatListBox1
            // 
            this.chatListBox1.BackColor = System.Drawing.Color.White;
            this.chatListBox1.Location = new System.Drawing.Point(3, -12);
            this.chatListBox1.Name = "chatListBox1";
            this.chatListBox1.Size = new System.Drawing.Size(160, 456);
            this.chatListBox1.TabIndex = 0;
            this.chatListBox1.Text = "chatListBox1";
            // 
            // frmSwitchUserControl1
            // 
            this.frmSwitchUserControl1.Location = new System.Drawing.Point(0, 199);
            this.frmSwitchUserControl1.Name = "frmSwitchUserControl1";
            this.frmSwitchUserControl1.Size = new System.Drawing.Size(342, 41);
            this.frmSwitchUserControl1.TabIndex = 4;
            // 
            // searchBoxUserControl11
            // 
            this.searchBoxUserControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(157)))), ((int)(((byte)(212)))));
            this.searchBoxUserControl11.Location = new System.Drawing.Point(0, 0);
            this.searchBoxUserControl11.Name = "searchBoxUserControl11";
            this.searchBoxUserControl11.Size = new System.Drawing.Size(341, 41);
            this.searchBoxUserControl11.TabIndex = 5;
            // 
            // userControl11
            // 
            this.userControl11.Location = new System.Drawing.Point(13, 47);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(233, 150);
            this.userControl11.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 689);
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.searchBoxUserControl11);
            this.Controls.Add(this.frmSwitchUserControl1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ChatListBox chatListBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FrmSwitchUserControl frmSwitchUserControl1;
        private searchBoxUserControl1 searchBoxUserControl11;
        private UserControl1 userControl11;
    }
}