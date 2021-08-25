using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Chat2021.MainFrm
{
    partial class contactFrm
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
            this.FrmChanged = new System.Windows.Forms.SplitContainer();
            this.userNameLabe = new System.Windows.Forms.Label();
            this.signTextBox = new System.Windows.Forms.TextBox();
            this.ToolBox = new System.Windows.Forms.PictureBox();
            this.searchBoxUserControl11 = new Chat2021.MainFrm.searchBoxUserControl1();
            this.frmSwitchUserControl1 = new Chat2021.MainFrm.FrmSwitchUserControl();
            this.chatListBox = new Chat2021.MainFrm.ChatListBox1();
            this.chatItem = new Chat2021.MainFrm.ChatItem();
            this.miniFrmBtn = new CloseBtn(Resource1.miniBtn, Resource1.miniBtnShadow, new HookSpace.MouseClickHandler(MiniFrm));
            this.closeBtn = new CloseBtn(Resource1.CloseBtn, Resource1.CloseBtnShadow, new HookSpace.MouseClickHandler(CloseFrm));
            ((System.ComponentModel.ISupportInitialize)(this.FrmChanged)).BeginInit();
            this.FrmChanged.Panel1.SuspendLayout();
            this.FrmChanged.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.FrmChanged.Location = new System.Drawing.Point(0, 242);
            this.FrmChanged.Name = "FrmChanged";
            // 
            // splitContainer1.Panel1
            // 
            this.FrmChanged.Panel1.Controls.Add(this.chatListBox);
            this.FrmChanged.Panel2.Controls.Add(this.chatItem);
            this.FrmChanged.Size = new System.Drawing.Size(342, 382);
            this.FrmChanged.SplitterDistance = 114;
            this.FrmChanged.TabIndex = 3;
            this.FrmChanged.Panel2Collapsed = true;
            // 
            // label1
            // 
            this.userNameLabe.AutoSize = true;
            this.userNameLabe.Location = new System.Drawing.Point(64, 67);
            this.userNameLabe.Name = "label1";
            this.userNameLabe.Size = new System.Drawing.Size(97, 15);
            this.userNameLabe.Location = new Point(102, 85);
            this.userNameLabe.TabIndex = 6;
            this.userNameLabe.Text = "编辑个性签名";
            this.userNameLabe.Click += new System.EventHandler(this.userNameLabeClick);
            this.userNameLabe.BackColor = Color.Transparent;
            // 
            // textBox1
            // 
            this.signTextBox.Location = new System.Drawing.Point(67, 85);
            this.signTextBox.Name = "textBox1";
            this.signTextBox.Size = new System.Drawing.Size(189, 25);
            this.signTextBox.TabIndex = 7;
            this.signTextBox.Visible = false;
            this.signTextBox.Location = this.userNameLabe.Location;
            // 
            // ToolBox
            // 
            this.ToolBox.Location = new System.Drawing.Point(0, 625);
            this.ToolBox.Name = "ToolBox";
            this.ToolBox.Size = new System.Drawing.Size(341, 61);
            this.ToolBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ToolBox.TabIndex = 1;
            this.ToolBox.TabStop = false;
            this.ToolBox.Location = new Point(0, 624);
            this.ToolBox.Size = new Size(342, 65);
            this.ToolBox.BackColor = Color.White;
            this.ToolBox.Paint += DrawToolBox;
            // 
            // searchBoxUserControl11
            // 
            this.searchBoxUserControl11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(157)))), ((int)(((byte)(212)))));
            this.searchBoxUserControl11.Location = new System.Drawing.Point(0, 161);
            this.searchBoxUserControl11.Name = "searchBoxUserControl11";
            this.searchBoxUserControl11.Size = new System.Drawing.Size(341, 41);
            this.searchBoxUserControl11.TabIndex = 5;
            this.searchBoxUserControl11.Location = new Point(0, 160);
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
            this.chatListBox.BackColor = System.Drawing.Color.White;
            this.chatListBox.Location = new System.Drawing.Point(3, -12);
            this.chatListBox.Name = "chatListBox";
            this.chatListBox.Size = new System.Drawing.Size(160, 382);
            this.chatListBox.TabIndex = 0;
            this.chatListBox.Location = new Point(0, 0);
            //
            //chatItem
            //
            this.chatItem.BackColor = System.Drawing.Color.White;
            this.chatItem.Location = new System.Drawing.Point(0, 0);
            this.chatItem.Size = new System.Drawing.Size(this.Width, 402);
            this.chatItem.Show();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 689);
            this.Controls.Add(this.ToolBox);
            this.Controls.Add(this.signTextBox);
            this.Controls.Add(this.userNameLabe);
            this.Controls.Add(this.searchBoxUserControl11);
            this.Controls.Add(this.frmSwitchUserControl1);
            this.Controls.Add(this.FrmChanged);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(MoveFrm);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(ChangeMouseStyle);
            this.LocationChanged += new System.EventHandler(MoveMiniFrmBtn);
            //this.miniFrmBtn.Location = new Point(Location.X + 265, Location.Y + 20);
            this.closeBtn.Location = new Point(Location.X + 305, Location.Y + 20);
            
            this.FrmChanged.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrmChanged)).EndInit();
            this.FrmChanged.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.chatListBox.Width = this.Width;
            this.chatItem.Width = this.Width;
            this.chatItem.Height = this.FrmChanged.Height;

        }

        #endregion
        private ChatListBox1 chatListBox;
        private System.Windows.Forms.SplitContainer FrmChanged;
        private FrmSwitchUserControl frmSwitchUserControl1;
        private searchBoxUserControl1 searchBoxUserControl11;
        private System.Windows.Forms.Label userNameLabe;
        private System.Windows.Forms.TextBox signTextBox;
        private System.Windows.Forms.PictureBox ToolBox;
        private CloseBtn miniFrmBtn;
        private CloseBtn closeBtn;
        private ChatItem chatItem;
    }
}