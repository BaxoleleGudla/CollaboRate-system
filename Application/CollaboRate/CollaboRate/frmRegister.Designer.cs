namespace CollaboRate
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.lblClear = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxShowPassword = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.pbxShoppingListLogo = new System.Windows.Forms.PictureBox();
            this.linklblLogin = new System.Windows.Forms.LinkLabel();
            this.pbxSignUpLogo = new System.Windows.Forms.PictureBox();
            this.txtEmail = new SATATextBox();
            this.txtUsername = new SATATextBox();
            this.txtPassword = new SATATextBox();
            this.btnSignUp = new FrameworkTest.SATAButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblUsernameError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.lblEmailError = new System.Windows.Forms.Label();
            this.lblGeneralError = new System.Windows.Forms.Label();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShoppingListLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSignUpLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.BackColor = System.Drawing.Color.White;
            this.lblClear.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblClear.Location = new System.Drawing.Point(84, 474);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(55, 21);
            this.lblClear.TabIndex = 72;
            this.lblClear.Text = "Clear";
            this.lblClear.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.label4.Location = new System.Drawing.Point(148, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 65;
            this.label4.Text = "Sign Up";
            // 
            // cbxShowPassword
            // 
            this.cbxShowPassword.AutoSize = true;
            this.cbxShowPassword.Location = new System.Drawing.Point(181, 474);
            this.cbxShowPassword.Name = "cbxShowPassword";
            this.cbxShowPassword.Size = new System.Drawing.Size(125, 20);
            this.cbxShowPassword.TabIndex = 59;
            this.cbxShowPassword.Text = "Show Password";
            this.cbxShowPassword.UseVisualStyleBackColor = true;
            this.cbxShowPassword.CheckedChanged += new System.EventHandler(this.cbxShowPassword_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Already have an account?";
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.pbxClose);
            this.pnlTop.Controls.Add(this.pbxShoppingListLogo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(384, 60);
            this.pnlTop.TabIndex = 63;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(133, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "CollaboRate";
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
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // pbxShoppingListLogo
            // 
            this.pbxShoppingListLogo.Location = new System.Drawing.Point(11, 12);
            this.pbxShoppingListLogo.Name = "pbxShoppingListLogo";
            this.pbxShoppingListLogo.Size = new System.Drawing.Size(40, 40);
            this.pbxShoppingListLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxShoppingListLogo.TabIndex = 6;
            this.pbxShoppingListLogo.TabStop = false;
            // 
            // linklblLogin
            // 
            this.linklblLogin.AutoSize = true;
            this.linklblLogin.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblLogin.LinkColor = System.Drawing.Color.Black;
            this.linklblLogin.Location = new System.Drawing.Point(252, 599);
            this.linklblLogin.Name = "linklblLogin";
            this.linklblLogin.Size = new System.Drawing.Size(75, 16);
            this.linklblLogin.TabIndex = 61;
            this.linklblLogin.TabStop = true;
            this.linklblLogin.Text = "Login here";
            this.linklblLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblLogin_LinkClicked);
            // 
            // pbxSignUpLogo
            // 
            this.pbxSignUpLogo.Location = new System.Drawing.Point(114, 88);
            this.pbxSignUpLogo.Name = "pbxSignUpLogo";
            this.pbxSignUpLogo.Size = new System.Drawing.Size(147, 101);
            this.pbxSignUpLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxSignUpLogo.TabIndex = 64;
            this.pbxSignUpLogo.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.DimGray;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Icon = null;
            this.txtEmail.IconSize = new System.Drawing.Size(20, 20);
            this.txtEmail.Location = new System.Drawing.Point(41, 253);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.Size = new System.Drawing.Size(302, 39);
            this.txtEmail.TabIndex = 73;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = false;
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
            this.txtUsername.Location = new System.Drawing.Point(41, 328);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(302, 39);
            this.txtUsername.TabIndex = 74;
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
            this.txtPassword.Location = new System.Drawing.Point(41, 401);
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = true;
            this.txtPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(302, 39);
            this.txtPassword.TabIndex = 75;
            this.txtPassword.Texts = "";
            this.txtPassword.UnderlinedStyle = false;
            // 
            // btnSignUp
            // 
            this.btnSignUp.ButtonText = "Sign Up";
            this.btnSignUp.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSignUp.CheckedForeColor = System.Drawing.Color.White;
            this.btnSignUp.CheckedImageTint = System.Drawing.Color.White;
            this.btnSignUp.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSignUp.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSignUp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSignUp.HoverForeColor = System.Drawing.Color.White;
            this.btnSignUp.HoverImage = null;
            this.btnSignUp.HoverImageTint = System.Drawing.Color.White;
            this.btnSignUp.HoverOutline = System.Drawing.Color.Empty;
            this.btnSignUp.Image = null;
            this.btnSignUp.ImageAutoCenter = false;
            this.btnSignUp.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSignUp.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSignUp.ImageTint = System.Drawing.Color.White;
            this.btnSignUp.IsToggleButton = false;
            this.btnSignUp.IsToggled = false;
            this.btnSignUp.Location = new System.Drawing.Point(41, 544);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(5);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSignUp.NormalForeColor = System.Drawing.Color.White;
            this.btnSignUp.NormalOutline = System.Drawing.Color.Empty;
            this.btnSignUp.OutlineThickness = 2F;
            this.btnSignUp.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSignUp.PressedForeColor = System.Drawing.Color.White;
            this.btnSignUp.PressedImageTint = System.Drawing.Color.White;
            this.btnSignUp.PressedOutline = System.Drawing.Color.Empty;
            this.btnSignUp.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSignUp.Size = new System.Drawing.Size(301, 41);
            this.btnSignUp.TabIndex = 76;
            this.btnSignUp.TextAutoCenter = true;
            this.btnSignUp.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // lblUsernameError
            // 
            this.lblUsernameError.AutoSize = true;
            this.lblUsernameError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameError.Location = new System.Drawing.Point(38, 374);
            this.lblUsernameError.Name = "lblUsernameError";
            this.lblUsernameError.Size = new System.Drawing.Size(45, 21);
            this.lblUsernameError.TabIndex = 77;
            this.lblUsernameError.Text = "Error";
            this.lblUsernameError.Visible = false;
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(38, 447);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(45, 21);
            this.lblPasswordError.TabIndex = 78;
            this.lblPasswordError.Text = "Error";
            this.lblPasswordError.Visible = false;
            // 
            // lblEmailError
            // 
            this.lblEmailError.AutoSize = true;
            this.lblEmailError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailError.ForeColor = System.Drawing.Color.Red;
            this.lblEmailError.Location = new System.Drawing.Point(38, 299);
            this.lblEmailError.Name = "lblEmailError";
            this.lblEmailError.Size = new System.Drawing.Size(45, 21);
            this.lblEmailError.TabIndex = 79;
            this.lblEmailError.Text = "Error";
            this.lblEmailError.Visible = false;
            // 
            // lblGeneralError
            // 
            this.lblGeneralError.AutoSize = true;
            this.lblGeneralError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneralError.ForeColor = System.Drawing.Color.Red;
            this.lblGeneralError.Location = new System.Drawing.Point(62, 63);
            this.lblGeneralError.Name = "lblGeneralError";
            this.lblGeneralError.Size = new System.Drawing.Size(258, 21);
            this.lblGeneralError.TabIndex = 80;
            this.lblGeneralError.Text = "Invalid username or password";
            this.lblGeneralError.Visible = false;
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(175, 298);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 81;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 638);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.lblGeneralError);
            this.Controls.Add(this.lblEmailError);
            this.Controls.Add(this.lblPasswordError);
            this.Controls.Add(this.lblUsernameError);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbxSignUpLogo);
            this.Controls.Add(this.cbxShowPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.linklblLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxShoppingListLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSignUpLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbxSignUpLogo;
        private System.Windows.Forms.CheckBox cbxShowPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.PictureBox pbxShoppingListLogo;
        private System.Windows.Forms.LinkLabel linklblLogin;
        private SATATextBox txtUsername;
        private SATATextBox txtEmail;
        private SATATextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private FrameworkTest.SATAButton btnSignUp;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblGeneralError;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
    }
}