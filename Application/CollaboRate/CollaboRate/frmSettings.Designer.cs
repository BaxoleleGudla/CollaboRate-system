namespace CollaboRate
{
    partial class frmSettings
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
            SATAUiFramework.BorderRadius borderRadius1 = new SATAUiFramework.BorderRadius();
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlAccountAndSecurity = new System.Windows.Forms.Panel();
            this.pnlChangePassword = new SATAUiFramework.SATAPanel();
            this.lblConfirmNewPasswordError = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConfirmNewPassword = new SATATextBox();
            this.btnChangePassword = new FrameworkTest.SATAButton();
            this.lblNewPasswordError = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewPassword = new SATATextBox();
            this.lblCurrentPasswordError = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCurrentPassword = new SATATextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlProfileInformation = new SATAUiFramework.SATAPanel();
            this.btnSaveProfileChanges = new FrameworkTest.SATAButton();
            this.lblEmailError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new SATATextBox();
            this.lblUsernameError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDecoration = new System.Windows.Forms.Panel();
            this.lblAccountAndSecurityHeading = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlSettings.SuspendLayout();
            this.pnlAccountAndSecurity.SuspendLayout();
            this.pnlChangePassword.SuspendLayout();
            this.pnlProfileInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoScroll = true;
            this.pnlSettings.Controls.Add(this.pnlAccountAndSecurity);
            this.pnlSettings.Controls.Add(this.lblHeading);
            this.pnlSettings.Controls.Add(this.pnlTop);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(810, 627);
            this.pnlSettings.TabIndex = 0;
            // 
            // pnlAccountAndSecurity
            // 
            this.pnlAccountAndSecurity.Controls.Add(this.pnlChangePassword);
            this.pnlAccountAndSecurity.Controls.Add(this.pnlProfileInformation);
            this.pnlAccountAndSecurity.Controls.Add(this.pnlDecoration);
            this.pnlAccountAndSecurity.Controls.Add(this.lblAccountAndSecurityHeading);
            this.pnlAccountAndSecurity.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccountAndSecurity.Location = new System.Drawing.Point(0, 80);
            this.pnlAccountAndSecurity.Name = "pnlAccountAndSecurity";
            this.pnlAccountAndSecurity.Size = new System.Drawing.Size(789, 767);
            this.pnlAccountAndSecurity.TabIndex = 17;
            // 
            // pnlChangePassword
            // 
            this.pnlChangePassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlChangePassword.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.pnlChangePassword.BorderColor = System.Drawing.Color.Black;
            borderRadius1.BottomLeft = 5;
            borderRadius1.BottomRight = 5;
            borderRadius1.TopLeft = 5;
            borderRadius1.TopRight = 5;
            this.pnlChangePassword.BorderRadius = borderRadius1;
            this.pnlChangePassword.BorderThickness = 0;
            this.pnlChangePassword.Controls.Add(this.lblConfirmNewPasswordError);
            this.pnlChangePassword.Controls.Add(this.label6);
            this.pnlChangePassword.Controls.Add(this.txtConfirmNewPassword);
            this.pnlChangePassword.Controls.Add(this.btnChangePassword);
            this.pnlChangePassword.Controls.Add(this.lblNewPasswordError);
            this.pnlChangePassword.Controls.Add(this.label5);
            this.pnlChangePassword.Controls.Add(this.txtNewPassword);
            this.pnlChangePassword.Controls.Add(this.lblCurrentPasswordError);
            this.pnlChangePassword.Controls.Add(this.label7);
            this.pnlChangePassword.Controls.Add(this.txtCurrentPassword);
            this.pnlChangePassword.Controls.Add(this.label8);
            this.pnlChangePassword.Location = new System.Drawing.Point(16, 377);
            this.pnlChangePassword.Name = "pnlChangePassword";
            this.pnlChangePassword.Size = new System.Drawing.Size(755, 378);
            this.pnlChangePassword.TabIndex = 21;
            // 
            // lblConfirmNewPasswordError
            // 
            this.lblConfirmNewPasswordError.AutoSize = true;
            this.lblConfirmNewPasswordError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmNewPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmNewPasswordError.Location = new System.Drawing.Point(16, 290);
            this.lblConfirmNewPasswordError.Name = "lblConfirmNewPasswordError";
            this.lblConfirmNewPasswordError.Size = new System.Drawing.Size(45, 21);
            this.lblConfirmNewPasswordError.TabIndex = 31;
            this.lblConfirmNewPasswordError.Text = "Error";
            this.lblConfirmNewPasswordError.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 21);
            this.label6.TabIndex = 30;
            this.label6.Text = "Confirm New Password";
            // 
            // txtConfirmNewPassword
            // 
            this.txtConfirmNewPassword.BackColor = System.Drawing.Color.White;
            this.txtConfirmNewPassword.BorderColor = System.Drawing.Color.DimGray;
            this.txtConfirmNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtConfirmNewPassword.BorderRadius = 5;
            this.txtConfirmNewPassword.BorderSize = 1;
            this.txtConfirmNewPassword.Icon = null;
            this.txtConfirmNewPassword.IconSize = new System.Drawing.Size(20, 20);
            this.txtConfirmNewPassword.Location = new System.Drawing.Point(21, 248);
            this.txtConfirmNewPassword.Multiline = false;
            this.txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            this.txtConfirmNewPassword.PasswordChar = false;
            this.txtConfirmNewPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtConfirmNewPassword.PlaceholderText = "";
            this.txtConfirmNewPassword.Size = new System.Drawing.Size(508, 39);
            this.txtConfirmNewPassword.TabIndex = 29;
            this.txtConfirmNewPassword.Texts = "";
            this.txtConfirmNewPassword.UnderlinedStyle = false;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.ButtonText = "Change Password";
            this.btnChangePassword.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnChangePassword.CheckedForeColor = System.Drawing.Color.White;
            this.btnChangePassword.CheckedImageTint = System.Drawing.Color.White;
            this.btnChangePassword.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnChangePassword.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChangePassword.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnChangePassword.HoverForeColor = System.Drawing.Color.White;
            this.btnChangePassword.HoverImage = null;
            this.btnChangePassword.HoverImageTint = System.Drawing.Color.White;
            this.btnChangePassword.HoverOutline = System.Drawing.Color.Empty;
            this.btnChangePassword.Image = null;
            this.btnChangePassword.ImageAutoCenter = false;
            this.btnChangePassword.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnChangePassword.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnChangePassword.ImageTint = System.Drawing.Color.White;
            this.btnChangePassword.IsToggleButton = false;
            this.btnChangePassword.IsToggled = false;
            this.btnChangePassword.Location = new System.Drawing.Point(20, 328);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnChangePassword.NormalForeColor = System.Drawing.Color.White;
            this.btnChangePassword.NormalOutline = System.Drawing.Color.Empty;
            this.btnChangePassword.OutlineThickness = 2F;
            this.btnChangePassword.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnChangePassword.PressedForeColor = System.Drawing.Color.White;
            this.btnChangePassword.PressedImageTint = System.Drawing.Color.White;
            this.btnChangePassword.PressedOutline = System.Drawing.Color.Empty;
            this.btnChangePassword.Rounding = new System.Windows.Forms.Padding(5);
            this.btnChangePassword.Size = new System.Drawing.Size(195, 35);
            this.btnChangePassword.TabIndex = 28;
            this.btnChangePassword.TextAutoCenter = true;
            this.btnChangePassword.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblNewPasswordError
            // 
            this.lblNewPasswordError.AutoSize = true;
            this.lblNewPasswordError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblNewPasswordError.Location = new System.Drawing.Point(16, 199);
            this.lblNewPasswordError.Name = "lblNewPasswordError";
            this.lblNewPasswordError.Size = new System.Drawing.Size(45, 21);
            this.lblNewPasswordError.TabIndex = 27;
            this.lblNewPasswordError.Text = "Error";
            this.lblNewPasswordError.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 21);
            this.label5.TabIndex = 26;
            this.label5.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.White;
            this.txtNewPassword.BorderColor = System.Drawing.Color.DimGray;
            this.txtNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtNewPassword.BorderRadius = 5;
            this.txtNewPassword.BorderSize = 1;
            this.txtNewPassword.Icon = null;
            this.txtNewPassword.IconSize = new System.Drawing.Size(20, 20);
            this.txtNewPassword.Location = new System.Drawing.Point(21, 157);
            this.txtNewPassword.Multiline = false;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = false;
            this.txtNewPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtNewPassword.PlaceholderText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(508, 39);
            this.txtNewPassword.TabIndex = 25;
            this.txtNewPassword.Texts = "";
            this.txtNewPassword.UnderlinedStyle = false;
            // 
            // lblCurrentPasswordError
            // 
            this.lblCurrentPasswordError.AutoSize = true;
            this.lblCurrentPasswordError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblCurrentPasswordError.Location = new System.Drawing.Point(16, 112);
            this.lblCurrentPasswordError.Name = "lblCurrentPasswordError";
            this.lblCurrentPasswordError.Size = new System.Drawing.Size(45, 21);
            this.lblCurrentPasswordError.TabIndex = 24;
            this.lblCurrentPasswordError.Text = "Error";
            this.lblCurrentPasswordError.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Current Password";
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.BackColor = System.Drawing.Color.White;
            this.txtCurrentPassword.BorderColor = System.Drawing.Color.DimGray;
            this.txtCurrentPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtCurrentPassword.BorderRadius = 5;
            this.txtCurrentPassword.BorderSize = 1;
            this.txtCurrentPassword.Icon = null;
            this.txtCurrentPassword.IconSize = new System.Drawing.Size(20, 20);
            this.txtCurrentPassword.Location = new System.Drawing.Point(21, 70);
            this.txtCurrentPassword.Multiline = false;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = false;
            this.txtCurrentPassword.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtCurrentPassword.PlaceholderText = "";
            this.txtCurrentPassword.Size = new System.Drawing.Size(508, 39);
            this.txtCurrentPassword.TabIndex = 22;
            this.txtCurrentPassword.Texts = "";
            this.txtCurrentPassword.UnderlinedStyle = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(17, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 22);
            this.label8.TabIndex = 21;
            this.label8.Text = "Change Password";
            // 
            // pnlProfileInformation
            // 
            this.pnlProfileInformation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProfileInformation.BackColor2 = System.Drawing.Color.WhiteSmoke;
            this.pnlProfileInformation.BorderColor = System.Drawing.Color.Black;
            borderRadius2.BottomLeft = 5;
            borderRadius2.BottomRight = 5;
            borderRadius2.TopLeft = 5;
            borderRadius2.TopRight = 5;
            this.pnlProfileInformation.BorderRadius = borderRadius2;
            this.pnlProfileInformation.BorderThickness = 0;
            this.pnlProfileInformation.Controls.Add(this.btnSaveProfileChanges);
            this.pnlProfileInformation.Controls.Add(this.lblEmailError);
            this.pnlProfileInformation.Controls.Add(this.label4);
            this.pnlProfileInformation.Controls.Add(this.txtEmail);
            this.pnlProfileInformation.Controls.Add(this.lblUsernameError);
            this.pnlProfileInformation.Controls.Add(this.label2);
            this.pnlProfileInformation.Controls.Add(this.txtUsername);
            this.pnlProfileInformation.Controls.Add(this.label1);
            this.pnlProfileInformation.Location = new System.Drawing.Point(16, 55);
            this.pnlProfileInformation.Name = "pnlProfileInformation";
            this.pnlProfileInformation.Size = new System.Drawing.Size(755, 294);
            this.pnlProfileInformation.TabIndex = 20;
            // 
            // btnSaveProfileChanges
            // 
            this.btnSaveProfileChanges.ButtonText = "Save Profile Changes";
            this.btnSaveProfileChanges.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSaveProfileChanges.CheckedForeColor = System.Drawing.Color.White;
            this.btnSaveProfileChanges.CheckedImageTint = System.Drawing.Color.White;
            this.btnSaveProfileChanges.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSaveProfileChanges.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveProfileChanges.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProfileChanges.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSaveProfileChanges.HoverForeColor = System.Drawing.Color.White;
            this.btnSaveProfileChanges.HoverImage = null;
            this.btnSaveProfileChanges.HoverImageTint = System.Drawing.Color.White;
            this.btnSaveProfileChanges.HoverOutline = System.Drawing.Color.Empty;
            this.btnSaveProfileChanges.Image = null;
            this.btnSaveProfileChanges.ImageAutoCenter = false;
            this.btnSaveProfileChanges.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSaveProfileChanges.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSaveProfileChanges.ImageTint = System.Drawing.Color.White;
            this.btnSaveProfileChanges.IsToggleButton = false;
            this.btnSaveProfileChanges.IsToggled = false;
            this.btnSaveProfileChanges.Location = new System.Drawing.Point(20, 235);
            this.btnSaveProfileChanges.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveProfileChanges.Name = "btnSaveProfileChanges";
            this.btnSaveProfileChanges.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSaveProfileChanges.NormalForeColor = System.Drawing.Color.White;
            this.btnSaveProfileChanges.NormalOutline = System.Drawing.Color.Empty;
            this.btnSaveProfileChanges.OutlineThickness = 2F;
            this.btnSaveProfileChanges.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSaveProfileChanges.PressedForeColor = System.Drawing.Color.White;
            this.btnSaveProfileChanges.PressedImageTint = System.Drawing.Color.White;
            this.btnSaveProfileChanges.PressedOutline = System.Drawing.Color.Empty;
            this.btnSaveProfileChanges.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSaveProfileChanges.Size = new System.Drawing.Size(195, 35);
            this.btnSaveProfileChanges.TabIndex = 28;
            this.btnSaveProfileChanges.TextAutoCenter = true;
            this.btnSaveProfileChanges.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblEmailError
            // 
            this.lblEmailError.AutoSize = true;
            this.lblEmailError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailError.ForeColor = System.Drawing.Color.Red;
            this.lblEmailError.Location = new System.Drawing.Point(16, 199);
            this.lblEmailError.Name = "lblEmailError";
            this.lblEmailError.Size = new System.Drawing.Size(45, 21);
            this.lblEmailError.TabIndex = 27;
            this.lblEmailError.Text = "Error";
            this.lblEmailError.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 26;
            this.label4.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderColor = System.Drawing.Color.DimGray;
            this.txtEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.BorderSize = 1;
            this.txtEmail.Icon = null;
            this.txtEmail.IconSize = new System.Drawing.Size(20, 20);
            this.txtEmail.Location = new System.Drawing.Point(21, 157);
            this.txtEmail.Multiline = false;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = false;
            this.txtEmail.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.Size = new System.Drawing.Size(508, 39);
            this.txtEmail.TabIndex = 25;
            this.txtEmail.Texts = "";
            this.txtEmail.UnderlinedStyle = false;
            // 
            // lblUsernameError
            // 
            this.lblUsernameError.AutoSize = true;
            this.lblUsernameError.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameError.Location = new System.Drawing.Point(16, 112);
            this.lblUsernameError.Name = "lblUsernameError";
            this.lblUsernameError.Size = new System.Drawing.Size(45, 21);
            this.lblUsernameError.TabIndex = 24;
            this.lblUsernameError.Text = "Error";
            this.lblUsernameError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderColor = System.Drawing.Color.DimGray;
            this.txtUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.BorderSize = 1;
            this.txtUsername.Icon = null;
            this.txtUsername.IconSize = new System.Drawing.Size(20, 20);
            this.txtUsername.Location = new System.Drawing.Point(21, 70);
            this.txtUsername.Multiline = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = false;
            this.txtUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.Size = new System.Drawing.Size(508, 39);
            this.txtUsername.TabIndex = 22;
            this.txtUsername.Texts = "";
            this.txtUsername.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Profile Information";
            // 
            // pnlDecoration
            // 
            this.pnlDecoration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.pnlDecoration.Location = new System.Drawing.Point(15, 36);
            this.pnlDecoration.Name = "pnlDecoration";
            this.pnlDecoration.Size = new System.Drawing.Size(755, 1);
            this.pnlDecoration.TabIndex = 19;
            // 
            // lblAccountAndSecurityHeading
            // 
            this.lblAccountAndSecurityHeading.AutoSize = true;
            this.lblAccountAndSecurityHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountAndSecurityHeading.Location = new System.Drawing.Point(12, 7);
            this.lblAccountAndSecurityHeading.Name = "lblAccountAndSecurityHeading";
            this.lblAccountAndSecurityHeading.Size = new System.Drawing.Size(197, 23);
            this.lblAccountAndSecurityHeading.TabIndex = 18;
            this.lblAccountAndSecurityHeading.Text = "Account && Security";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(98, 27);
            this.lblHeading.TabIndex = 16;
            this.lblHeading.Text = "Settings";
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(789, 80);
            this.pnlTop.TabIndex = 0;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pnlSettings);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlAccountAndSecurity.ResumeLayout(false);
            this.pnlAccountAndSecurity.PerformLayout();
            this.pnlChangePassword.ResumeLayout(false);
            this.pnlChangePassword.PerformLayout();
            this.pnlProfileInformation.ResumeLayout(false);
            this.pnlProfileInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlAccountAndSecurity;
        private System.Windows.Forms.Panel pnlDecoration;
        private System.Windows.Forms.Label lblAccountAndSecurityHeading;
        private SATAUiFramework.SATAPanel pnlProfileInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label label2;
        private SATATextBox txtUsername;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label label4;
        private SATATextBox txtEmail;
        private FrameworkTest.SATAButton btnSaveProfileChanges;
        private SATAUiFramework.SATAPanel pnlChangePassword;
        private FrameworkTest.SATAButton btnChangePassword;
        private System.Windows.Forms.Label lblNewPasswordError;
        private System.Windows.Forms.Label label5;
        private SATATextBox txtNewPassword;
        private System.Windows.Forms.Label lblCurrentPasswordError;
        private System.Windows.Forms.Label label7;
        private SATATextBox txtCurrentPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblConfirmNewPasswordError;
        private System.Windows.Forms.Label label6;
        private SATATextBox txtConfirmNewPassword;
    }
}