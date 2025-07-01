namespace CollaboRate
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.linklblRegister = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxShowPassword = new System.Windows.Forms.CheckBox();
            this.lblClear = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbx2 = new System.Windows.Forms.PictureBox();
            this.txtUsername = new SATATextBox();
            this.txtPassword = new SATATextBox();
            this.btnLogin = new FrameworkTest.SATAButton();
            this.lblUsernameError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.pbxLoginLogo = new System.Windows.Forms.PictureBox();
            this.lblGeneralError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoginLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxClose
            // 
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Image = ((System.Drawing.Image)(resources.GetObject("pbxClose.Image")));
            this.pbxClose.Location = new System.Drawing.Point(353, 1);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(32, 22);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxClose.TabIndex = 7;
            this.pbxClose.TabStop = false;
            this.toolTip.SetToolTip(this.pbxClose, "Close");
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // linklblRegister
            // 
            this.linklblRegister.AutoSize = true;
            this.linklblRegister.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblRegister.LinkColor = System.Drawing.Color.Black;
            this.linklblRegister.Location = new System.Drawing.Point(233, 544);
            this.linklblRegister.Name = "linklblRegister";
            this.linklblRegister.Size = new System.Drawing.Size(92, 16);
            this.linklblRegister.TabIndex = 28;
            this.linklblRegister.TabStop = true;
            this.linklblRegister.Text = "Register here";
            this.linklblRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblRegister_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "Don\'t have an account?";
            // 
            // cbxShowPassword
            // 
            this.cbxShowPassword.AutoSize = true;
            this.cbxShowPassword.Location = new System.Drawing.Point(181, 407);
            this.cbxShowPassword.Name = "cbxShowPassword";
            this.cbxShowPassword.Size = new System.Drawing.Size(125, 20);
            this.cbxShowPassword.TabIndex = 25;
            this.cbxShowPassword.Text = "Show Password";
            this.cbxShowPassword.UseVisualStyleBackColor = true;
            this.cbxShowPassword.CheckedChanged += new System.EventHandler(this.cbxShowPassword_CheckedChanged);
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.BackColor = System.Drawing.Color.White;
            this.lblClear.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblClear.Location = new System.Drawing.Point(84, 407);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(55, 21);
            this.lblClear.TabIndex = 26;
            this.lblClear.Text = "Clear";
            this.lblClear.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.label4.Location = new System.Drawing.Point(160, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(132, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "CollaboRate";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.pnlTop.Controls.Add(this.pbxClose);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.pbx2);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(384, 60);
            this.pnlTop.TabIndex = 30;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // pbx2
            // 
            this.pbx2.Location = new System.Drawing.Point(11, 12);
            this.pbx2.Name = "pbx2";
            this.pbx2.Size = new System.Drawing.Size(40, 40);
            this.pbx2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx2.TabIndex = 6;
            this.pbx2.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderColor = System.Drawing.Color.DimGray;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.BorderSize = 1;
            this.txtUsername.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Icon = null;
            this.txtUsername.IconSize = new System.Drawing.Size(20, 20);
            this.txtUsername.Location = new System.Drawing.Point(41, 259);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(301, 39);
            this.txtUsername.TabIndex = 37;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.DimGray;
            this.txtPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Icon = null;
            this.txtPassword.IconSize = new System.Drawing.Size(20, 20);
            this.txtPassword.Location = new System.Drawing.Point(41, 335);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(301, 39);
            this.txtPassword.TabIndex = 38;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            // 
            // btnLogin
            // 
            this.btnLogin.ButtonText = "Login";
            this.btnLogin.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnLogin.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogin.CheckedImageTint = System.Drawing.Color.White;
            this.btnLogin.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnLogin.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnLogin.HoverForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverImage = null;
            this.btnLogin.HoverImageTint = System.Drawing.Color.White;
            this.btnLogin.HoverOutline = System.Drawing.Color.Empty;
            this.btnLogin.Image = null;
            this.btnLogin.ImageAutoCenter = false;
            this.btnLogin.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnLogin.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnLogin.ImageTint = System.Drawing.Color.White;
            this.btnLogin.IsToggleButton = false;
            this.btnLogin.IsToggled = false;
            this.btnLogin.Location = new System.Drawing.Point(41, 487);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnLogin.NormalForeColor = System.Drawing.Color.White;
            this.btnLogin.NormalOutline = System.Drawing.Color.Empty;
            this.btnLogin.OutlineThickness = 2F;
            this.btnLogin.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLogin.PressedForeColor = System.Drawing.Color.White;
            this.btnLogin.PressedImageTint = System.Drawing.Color.White;
            this.btnLogin.PressedOutline = System.Drawing.Color.Empty;
            this.btnLogin.Rounding = new System.Windows.Forms.Padding(5);
            this.btnLogin.Size = new System.Drawing.Size(301, 41);
            this.btnLogin.TabIndex = 47;
            this.btnLogin.TextAutoCenter = true;
            this.btnLogin.TextOffset = new System.Drawing.Point(0, 0);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblUsernameError
            // 
            this.lblUsernameError.AutoSize = true;
            this.lblUsernameError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameError.Location = new System.Drawing.Point(38, 304);
            this.lblUsernameError.Name = "lblUsernameError";
            this.lblUsernameError.Size = new System.Drawing.Size(45, 21);
            this.lblUsernameError.TabIndex = 48;
            this.lblUsernameError.Text = "Error";
            this.lblUsernameError.Visible = false;
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(38, 380);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(45, 21);
            this.lblPasswordError.TabIndex = 49;
            this.lblPasswordError.Text = "Error";
            this.lblPasswordError.Visible = false;
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(175, 305);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 50;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // pbxLoginLogo
            // 
            this.pbxLoginLogo.Location = new System.Drawing.Point(118, 90);
            this.pbxLoginLogo.Name = "pbxLoginLogo";
            this.pbxLoginLogo.Size = new System.Drawing.Size(147, 101);
            this.pbxLoginLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLoginLogo.TabIndex = 31;
            this.pbxLoginLogo.TabStop = false;
            // 
            // lblGeneralError
            // 
            this.lblGeneralError.AutoSize = true;
            this.lblGeneralError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneralError.ForeColor = System.Drawing.Color.Red;
            this.lblGeneralError.Location = new System.Drawing.Point(62, 63);
            this.lblGeneralError.Name = "lblGeneralError";
            this.lblGeneralError.Size = new System.Drawing.Size(258, 21);
            this.lblGeneralError.TabIndex = 51;
            this.lblGeneralError.Text = "Invalid username or password";
            this.lblGeneralError.Visible = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 587);
            this.Controls.Add(this.lblGeneralError);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.lblPasswordError);
            this.Controls.Add(this.lblUsernameError);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.linklblRegister);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxShowPassword);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbxLoginLogo);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoginLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.LinkLabel linklblRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxShowPassword;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbxLoginLogo;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbx2;
        private SATATextBox txtUsername;
        private SATATextBox txtPassword;
        private FrameworkTest.SATAButton btnLogin;
        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
        private System.Windows.Forms.Label lblGeneralError;
    }
}