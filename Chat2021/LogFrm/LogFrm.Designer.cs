namespace Chat2021.LogFrm
{
    partial class LogFrm
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
            this.PlayVedioPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlayVedioPic)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayVedioPic
            // 
            this.PlayVedioPic.Location = new System.Drawing.Point(0, 0);
            this.PlayVedioPic.Name = "PlayVedioPic";
            this.PlayVedioPic.Size = new System.Drawing.Size(100, 50);
            this.PlayVedioPic.TabIndex = 0;
            this.PlayVedioPic.TabStop = false;
            // 
            // LogFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayVedioPic);
            this.Name = "LogFrm";
            this.Text = "LogFrm";
            ((System.ComponentModel.ISupportInitialize)(this.PlayVedioPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PlayVedioPic;
    }
}