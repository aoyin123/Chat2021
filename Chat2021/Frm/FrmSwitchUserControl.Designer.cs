namespace Chat2021.Frm
{
    partial class FrmSwitchUserControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.msgswtBtn = new System.Windows.Forms.Button();
            this.contactsBtn = new System.Windows.Forms.Button();
            this.spaceBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // msgswtBtn
            // 
            this.msgswtBtn.BackColor = System.Drawing.Color.White;
            this.msgswtBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.msgswtBtn.Location = new System.Drawing.Point(0, 0);
            this.msgswtBtn.Name = "msgswtBtn";
            this.msgswtBtn.Size = new System.Drawing.Size(138, 150);
            this.msgswtBtn.TabIndex = 0;
            this.msgswtBtn.Tag = "消息";
            this.msgswtBtn.UseVisualStyleBackColor = false;
            // 
            // contactsBtn
            // 
            this.contactsBtn.BackColor = System.Drawing.Color.White;
            this.contactsBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.contactsBtn.Location = new System.Drawing.Point(138, 0);
            this.contactsBtn.Name = "contactsBtn";
            this.contactsBtn.Size = new System.Drawing.Size(149, 150);
            this.contactsBtn.TabIndex = 1;
            this.contactsBtn.Tag = "联系人";
            this.contactsBtn.UseVisualStyleBackColor = false;
            // 
            // spaceBtn
            // 
            this.spaceBtn.BackColor = System.Drawing.Color.White;
            this.spaceBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.spaceBtn.Location = new System.Drawing.Point(287, 0);
            this.spaceBtn.Name = "spaceBtn";
            this.spaceBtn.Size = new System.Drawing.Size(143, 150);
            this.spaceBtn.TabIndex = 2;
            this.spaceBtn.Tag = "空间";
            this.spaceBtn.UseVisualStyleBackColor = false;
            // 
            // FrmSwitchUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spaceBtn);
            this.Controls.Add(this.contactsBtn);
            this.Controls.Add(this.msgswtBtn);
            this.Name = "FrmSwitchUserControl";
            this.Size = new System.Drawing.Size(425, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button msgswtBtn;
        private System.Windows.Forms.Button contactsBtn;
        private System.Windows.Forms.Button spaceBtn;
    }
}
