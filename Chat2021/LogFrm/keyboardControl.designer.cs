namespace keyboard
{
    partial class UserControl1
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
            this.jBtn = new keyboard.KeyboardBtn1();
            this.iBtn = new keyboard.KeyboardBtn1();
            this.hBtn = new keyboard.KeyboardBtn1();
            this.SuspendLayout();
            // 
            // jBtn
            // 
            this.jBtn.DownRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(163)))), ((int)(((byte)(231)))));
            this.jBtn.Location = new System.Drawing.Point(94, 91);
            this.jBtn.Margin = new System.Windows.Forms.Padding(2);
            this.jBtn.Name = "jBtn";
            this.jBtn.Size = new System.Drawing.Size(31, 30);
            this.jBtn.StrPos = new System.Drawing.Point(10, 9);
            this.jBtn.TabIndex = 2;
            this.jBtn.Text = "keyboardBtn11";
            this.jBtn.UpRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            this.jBtn.UseVisualStyleBackColor = true;
            // 
            // iBtn
            // 
            this.iBtn.DownRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(163)))), ((int)(((byte)(231)))));
            this.iBtn.Location = new System.Drawing.Point(59, 91);
            this.iBtn.Margin = new System.Windows.Forms.Padding(2);
            this.iBtn.Name = "iBtn";
            this.iBtn.Size = new System.Drawing.Size(31, 30);
            this.iBtn.StrPos = new System.Drawing.Point(10, 9);
            this.iBtn.TabIndex = 1;
            this.iBtn.Text = "keyboardBtn11";
            this.iBtn.UpRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            this.iBtn.UseVisualStyleBackColor = true;
            // 
            // hBtn
            // 
            this.hBtn.DownRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(163)))), ((int)(((byte)(231)))));
            this.hBtn.Location = new System.Drawing.Point(22, 91);
            this.hBtn.Margin = new System.Windows.Forms.Padding(2);
            this.hBtn.Name = "hBtn";
            this.hBtn.Size = new System.Drawing.Size(31, 30);
            this.hBtn.StrPos = new System.Drawing.Point(10, 9);
            this.hBtn.TabIndex = 0;
            this.hBtn.Text = "keyboardBtn11";
            this.hBtn.UpRegionColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(187)))), ((int)(((byte)(239)))));
            this.hBtn.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jBtn);
            this.Controls.Add(this.iBtn);
            this.Controls.Add(this.hBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(391, 192);
            this.ResumeLayout(false);

        }

        #endregion

        private KeyboardBtn1 hBtn;
        private KeyboardBtn1 iBtn;
        private KeyboardBtn1 jBtn;
    }
}
