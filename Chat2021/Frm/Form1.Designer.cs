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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.searchBoxUserControl11 = new Chat2021.Frm.searchBoxUserControl1();
            this.frmSwitchUserControl1 = new Chat2021.Frm.FrmSwitchUserControl();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "编辑个性签名";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // searchBoxUserControl11
            // 
            this.searchBoxUserControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(157)))), ((int)(((byte)(212)))));
            this.searchBoxUserControl11.Location = new System.Drawing.Point(0, 161);
            this.searchBoxUserControl11.Name = "searchBoxUserControl11";
            this.searchBoxUserControl11.Size = new System.Drawing.Size(341, 41);
            this.searchBoxUserControl11.TabIndex = 5;
            // 
            // frmSwitchUserControl1
            // 
            this.frmSwitchUserControl1.Location = new System.Drawing.Point(0, 199);
            this.frmSwitchUserControl1.Name = "frmSwitchUserControl1";
            this.frmSwitchUserControl1.Size = new System.Drawing.Size(342, 41);
            this.frmSwitchUserControl1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 689);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBoxUserControl11);
            this.Controls.Add(this.frmSwitchUserControl1);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ChatListBox chatListBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FrmSwitchUserControl frmSwitchUserControl1;
        private searchBoxUserControl1 searchBoxUserControl11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}