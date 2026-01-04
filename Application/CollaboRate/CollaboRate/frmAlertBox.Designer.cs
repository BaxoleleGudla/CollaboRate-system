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
            this.pbxClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlertIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTextAlertBox
            // 
            this.lblTextAlertBox.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextAlertBox.Location = new System.Drawing.Point(56, 30);
            this.lblTextAlertBox.Name = "lblTextAlertBox";
            this.lblTextAlertBox.Size = new System.Drawing.Size(288, 20);
            this.lblTextAlertBox.TabIndex = 1;
            this.lblTextAlertBox.Text = "TextAlertBox";
            // 
            // lblTitleAlertBox
            // 
            this.lblTitleAlertBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleAlertBox.Location = new System.Drawing.Point(56, 11);
            this.lblTitleAlertBox.Name = "lblTitleAlertBox";
            this.lblTitleAlertBox.Size = new System.Drawing.Size(206, 23);
            this.lblTitleAlertBox.TabIndex = 2;
            this.lblTitleAlertBox.Text = "TitleAlertBox";
            // 
            // pnlAlertBox
            // 
            this.pnlAlertBox.BackColor = System.Drawing.Color.Black;
            this.pnlAlertBox.Location = new System.Drawing.Point(-1, 57);
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
            this.elipse.CornerRadius = 12;
            this.elipse.TargetControl = this;
            // 
            // pbxAlertIcon
            // 
            this.pbxAlertIcon.Location = new System.Drawing.Point(16, 15);
            this.pbxAlertIcon.Name = "pbxAlertIcon";
            this.pbxAlertIcon.Size = new System.Drawing.Size(30, 30);
            this.pbxAlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxAlertIcon.TabIndex = 0;
            this.pbxAlertIcon.TabStop = false;
            // 
            // pbxClose
            // 
            this.pbxClose.Image = global::CollaboRate.Properties.Resources.Error_Icon;
            this.pbxClose.Location = new System.Drawing.Point(332, 3);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(18, 18);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClose.TabIndex = 4;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // frmAlertBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(353, 64);
            this.Controls.Add(this.pbxClose);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxAlertIcon;
        private System.Windows.Forms.Label lblTextAlertBox;
        private System.Windows.Forms.Label lblTitleAlertBox;
        private System.Windows.Forms.Panel pnlAlertBox;
        private System.Windows.Forms.Timer timerAnimation;
        private SATAUiFramework.Controls.SATAEllipseControl elipse;
        private System.Windows.Forms.PictureBox pbxClose;
    }
}