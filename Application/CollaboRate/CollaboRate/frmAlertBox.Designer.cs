namespace CollaboRate
{
    partial class frmAlertBox
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
            this.components = new System.ComponentModel.Container();
            this.lblTextAlertBox = new System.Windows.Forms.Label();
            this.lblTitleAlertBox = new System.Windows.Forms.Label();
            this.pnlAlertBox = new System.Windows.Forms.Panel();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.elipse = new SATAUiFramework.Controls.SATAEllipseControl();
            this.pbxAlertIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlertIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextAlertBox
            // 
            this.lblTextAlertBox.AutoSize = true;
            this.lblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextAlertBox.Location = new System.Drawing.Point(85, 41);
            this.lblTextAlertBox.Name = "lblTextAlertBox";
            this.lblTextAlertBox.Size = new System.Drawing.Size(128, 23);
            this.lblTextAlertBox.TabIndex = 1;
            this.lblTextAlertBox.Text = "TextAlertBox";
            // 
            // lblTitleAlertBox
            // 
            this.lblTitleAlertBox.AutoSize = true;
            this.lblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAlertBox.Location = new System.Drawing.Point(85, 14);
            this.lblTitleAlertBox.Name = "lblTitleAlertBox";
            this.lblTitleAlertBox.Size = new System.Drawing.Size(149, 27);
            this.lblTitleAlertBox.TabIndex = 2;
            this.lblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // pnlAlertBox
            // 
            this.pnlAlertBox.BackColor = System.Drawing.Color.Black;
            this.pnlAlertBox.Location = new System.Drawing.Point(0, 73);
            this.pnlAlertBox.Name = "pnlAlertBox";
            this.pnlAlertBox.Size = new System.Drawing.Size(1, 6);
            this.pnlAlertBox.TabIndex = 3;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 10;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // elipse
            // 
            this.elipse.CornerRadius = 20;
            this.elipse.TargetControl = this;
            // 
            // pbxAlertIcon
            // 
            this.pbxAlertIcon.Location = new System.Drawing.Point(28, 14);
            this.pbxAlertIcon.Name = "pbxAlertIcon";
            this.pbxAlertIcon.Size = new System.Drawing.Size(50, 50);
            this.pbxAlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAlertIcon.TabIndex = 0;
            this.pbxAlertIcon.TabStop = false;
            // 
            // frmAlertBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 80);
            this.Controls.Add(this.pnlAlertBox);
            this.Controls.Add(this.lblTitleAlertBox);
            this.Controls.Add(this.lblTextAlertBox);
            this.Controls.Add(this.pbxAlertIcon);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlertBox";
            this.Text = "frmAlertBox";
            this.Load += new System.EventHandler(this.frmAlertBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlertIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAlertIcon;
        private System.Windows.Forms.Label lblTextAlertBox;
        private System.Windows.Forms.Label lblTitleAlertBox;
        private System.Windows.Forms.Panel pnlAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
        private SATAUiFramework.Controls.SATAEllipseControl elipse;
    }
}