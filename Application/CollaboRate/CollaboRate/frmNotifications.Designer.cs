namespace CollaboRate
{
    partial class frmNotifications
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblHeading = new System.Windows.Forms.Label();
            this.flpNotifications = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.pnlTop.Controls.Add(this.lblHeading);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(3);
            this.pnlTop.Size = new System.Drawing.Size(344, 38);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.White;
            this.lblHeading.Location = new System.Drawing.Point(13, 10);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(131, 23);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "Notifications";
            // 
            // flpNotifications
            // 
            this.flpNotifications.AutoScroll = true;
            this.flpNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpNotifications.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpNotifications.Location = new System.Drawing.Point(3, 41);
            this.flpNotifications.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.flpNotifications.Name = "flpNotifications";
            this.flpNotifications.Padding = new System.Windows.Forms.Padding(3);
            this.flpNotifications.Size = new System.Drawing.Size(344, 406);
            this.flpNotifications.TabIndex = 1;
            this.flpNotifications.WrapContents = false;
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoadingSpinner.BackColor = System.Drawing.SystemColors.Control;
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(156, 202);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 55;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // frmNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 450);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.flpNotifications);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNotifications";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "frmNotifications";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmNotifications_Paint);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.FlowLayoutPanel flpNotifications;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
    }
}