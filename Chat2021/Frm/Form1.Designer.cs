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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ToolBox = new System.Windows.Forms.PictureBox();
            this.searchBoxUserControl11 = new Chat2021.Frm.searchBoxUserControl1();
            this.frmSwitchUserControl1 = new Chat2021.Frm.FrmSwitchUserControl();
            this.chatListBox1 = new Chat2021.Frm.ChatListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 242);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chatListBox1);
            this.splitContainer1.Size = new System.Drawing.Size(342, 382);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.TabIndex = 3;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ToolBox
            // 
            this.ToolBox.Location = new System.Drawing.Point(0, 625);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(341, 61);
            this.ToolBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ToolBox.TabIndex = 1;
            this.ToolBox.TabStop = false;
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
            // chatListBox1
            // 
            this.chatListBox1.BackColor = System.Drawing.Color.White;
            this.chatListBox1.Location = new System.Drawing.Point(3, -12);
            this.chatListBox1.Name = "chatListBox1";
            this.chatListBox1.Size = new System.Drawing.Size(160, 456);
            this.chatListBox1.TabIndex = 0;
            this.chatListBox1.Text = "chatListBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 689);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.button1);
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
            ((System.ComponentModel.ISupportInitialize)(this.ToolBox)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ToolBox;
    }
}