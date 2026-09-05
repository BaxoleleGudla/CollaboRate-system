namespace CollaboRate
{
    partial class frmMain
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
            this.pnlSidemenu = new System.Windows.Forms.Panel();
            this.btnInformation = new System.Windows.Forms.Button();
            this.btnWarning = new System.Windows.Forms.Button();
            this.btnError = new System.Windows.Forms.Button();
            this.btnSuccess = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new FrameworkTest.SATAButton();
            this.pnlTopDiveder = new System.Windows.Forms.Panel();
            this.btnSettings = new FrameworkTest.SATAButton();
            this.btnGroupChats = new FrameworkTest.SATAButton();
            this.btnGroupMeetings = new FrameworkTest.SATAButton();
            this.btnGroupTasks = new FrameworkTest.SATAButton();
            this.btnMemberEvaluations = new FrameworkTest.SATAButton();
            this.btnProjectGroups = new FrameworkTest.SATAButton();
            this.btnHome = new FrameworkTest.SATAButton();
            this.pnlCurrentGroup = new System.Windows.Forms.Panel();
            this.pnlBottomDivider = new System.Windows.Forms.Panel();
            this.cmbxCurrentGroup = new System.Windows.Forms.ComboBox();
            this.lblCurrentGroup = new System.Windows.Forms.Label();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnNotification = new FrameworkTest.SATAButton();
            this.btnMinimize = new FrameworkTest.SATAButton();
            this.btnMaximize = new FrameworkTest.SATAButton();
            this.btnClose = new FrameworkTest.SATAButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlSidemenu.SuspendLayout();
            this.pnlCurrentGroup.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidemenu
            // 
            this.pnlSidemenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.pnlSidemenu.Controls.Add(this.btnInformation);
            this.pnlSidemenu.Controls.Add(this.btnWarning);
            this.pnlSidemenu.Controls.Add(this.btnError);
            this.pnlSidemenu.Controls.Add(this.btnSuccess);
            this.pnlSidemenu.Controls.Add(this.panel1);
            this.pnlSidemenu.Controls.Add(this.btnLogout);
            this.pnlSidemenu.Controls.Add(this.pnlTopDiveder);
            this.pnlSidemenu.Controls.Add(this.btnSettings);
            this.pnlSidemenu.Controls.Add(this.btnGroupChats);
            this.pnlSidemenu.Controls.Add(this.btnGroupMeetings);
            this.pnlSidemenu.Controls.Add(this.btnGroupTasks);
            this.pnlSidemenu.Controls.Add(this.btnMemberEvaluations);
            this.pnlSidemenu.Controls.Add(this.btnProjectGroups);
            this.pnlSidemenu.Controls.Add(this.btnHome);
            this.pnlSidemenu.Controls.Add(this.pnlCurrentGroup);
            this.pnlSidemenu.Controls.Add(this.pnlLogo);
            this.pnlSidemenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidemenu.Location = new System.Drawing.Point(0, 0);
            this.pnlSidemenu.Name = "pnlSidemenu";
            this.pnlSidemenu.Size = new System.Drawing.Size(235, 661);
            this.pnlSidemenu.TabIndex = 0;
            // 
            // btnInformation
            // 
            this.btnInformation.Location = new System.Drawing.Point(29, 528);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(100, 36);
            this.btnInformation.TabIndex = 15;
            this.btnInformation.Text = "Information";
            this.btnInformation.UseVisualStyleBackColor = true;
            this.btnInformation.Click += new System.EventHandler(this.btnInformation_Click);
            // 
            // btnWarning
            // 
            this.btnWarning.Location = new System.Drawing.Point(29, 486);
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.Size = new System.Drawing.Size(100, 36);
            this.btnWarning.TabIndex = 14;
            this.btnWarning.Text = "Warning";
            this.btnWarning.UseVisualStyleBackColor = true;
            this.btnWarning.Click += new System.EventHandler(this.btnWarning_Click);
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(29, 444);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(100, 36);
            this.btnError.TabIndex = 13;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnSuccess
            // 
            this.btnSuccess.Location = new System.Drawing.Point(29, 402);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.Size = new System.Drawing.Size(100, 36);
            this.btnSuccess.TabIndex = 12;
            this.btnSuccess.Text = "Success";
            this.btnSuccess.UseVisualStyleBackColor = true;
            this.btnSuccess.Click += new System.EventHandler(this.btnSuccess_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(182)))), ((int)(((byte)(210)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 1);
            this.panel1.TabIndex = 11;
            // 
            // btnLogout
            // 
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnLogout.CheckedForeColor = System.Drawing.Color.White;
            this.btnLogout.CheckedImageTint = System.Drawing.Color.White;
            this.btnLogout.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnLogout.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnLogout.HoverForeColor = System.Drawing.Color.White;
            this.btnLogout.HoverImage = null;
            this.btnLogout.HoverImageTint = System.Drawing.Color.White;
            this.btnLogout.HoverOutline = System.Drawing.Color.Empty;
            this.btnLogout.Image = global::CollaboRate.Properties.Resources.home;
            this.btnLogout.ImageAutoCenter = false;
            this.btnLogout.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnLogout.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnLogout.ImageTint = System.Drawing.Color.White;
            this.btnLogout.IsToggleButton = false;
            this.btnLogout.IsToggled = false;
            this.btnLogout.Location = new System.Drawing.Point(0, 626);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnLogout.NormalForeColor = System.Drawing.Color.White;
            this.btnLogout.NormalOutline = System.Drawing.Color.Empty;
            this.btnLogout.OutlineThickness = 2F;
            this.btnLogout.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnLogout.PressedForeColor = System.Drawing.Color.White;
            this.btnLogout.PressedImageTint = System.Drawing.Color.White;
            this.btnLogout.PressedOutline = System.Drawing.Color.Empty;
            this.btnLogout.Rounding = new System.Windows.Forms.Padding(5);
            this.btnLogout.Size = new System.Drawing.Size(235, 35);
            this.btnLogout.TabIndex = 11;
            this.btnLogout.TextAutoCenter = false;
            this.btnLogout.TextOffset = new System.Drawing.Point(0, 0);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlTopDiveder
            // 
            this.pnlTopDiveder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(182)))), ((int)(((byte)(210)))));
            this.pnlTopDiveder.Location = new System.Drawing.Point(0, 77);
            this.pnlTopDiveder.Name = "pnlTopDiveder";
            this.pnlTopDiveder.Size = new System.Drawing.Size(235, 1);
            this.pnlTopDiveder.TabIndex = 10;
            // 
            // btnSettings
            // 
            this.btnSettings.ButtonText = "Settings";
            this.btnSettings.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSettings.CheckedForeColor = System.Drawing.Color.White;
            this.btnSettings.CheckedImageTint = System.Drawing.Color.White;
            this.btnSettings.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSettings.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSettings.HoverForeColor = System.Drawing.Color.White;
            this.btnSettings.HoverImage = null;
            this.btnSettings.HoverImageTint = System.Drawing.Color.White;
            this.btnSettings.HoverOutline = System.Drawing.Color.Empty;
            this.btnSettings.Image = global::CollaboRate.Properties.Resources.home;
            this.btnSettings.ImageAutoCenter = false;
            this.btnSettings.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSettings.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSettings.ImageTint = System.Drawing.Color.White;
            this.btnSettings.IsToggleButton = false;
            this.btnSettings.IsToggled = false;
            this.btnSettings.Location = new System.Drawing.Point(0, 359);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSettings.NormalForeColor = System.Drawing.Color.White;
            this.btnSettings.NormalOutline = System.Drawing.Color.Empty;
            this.btnSettings.OutlineThickness = 2F;
            this.btnSettings.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSettings.PressedForeColor = System.Drawing.Color.White;
            this.btnSettings.PressedImageTint = System.Drawing.Color.White;
            this.btnSettings.PressedOutline = System.Drawing.Color.Empty;
            this.btnSettings.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSettings.Size = new System.Drawing.Size(235, 35);
            this.btnSettings.TabIndex = 9;
            this.btnSettings.TextAutoCenter = false;
            this.btnSettings.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnGroupChats
            // 
            this.btnGroupChats.ButtonText = "Chats";
            this.btnGroupChats.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnGroupChats.CheckedForeColor = System.Drawing.Color.White;
            this.btnGroupChats.CheckedImageTint = System.Drawing.Color.White;
            this.btnGroupChats.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnGroupChats.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGroupChats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGroupChats.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupChats.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnGroupChats.HoverForeColor = System.Drawing.Color.White;
            this.btnGroupChats.HoverImage = null;
            this.btnGroupChats.HoverImageTint = System.Drawing.Color.White;
            this.btnGroupChats.HoverOutline = System.Drawing.Color.Empty;
            this.btnGroupChats.Image = global::CollaboRate.Properties.Resources.home;
            this.btnGroupChats.ImageAutoCenter = false;
            this.btnGroupChats.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGroupChats.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnGroupChats.ImageTint = System.Drawing.Color.White;
            this.btnGroupChats.IsToggleButton = false;
            this.btnGroupChats.IsToggled = false;
            this.btnGroupChats.Location = new System.Drawing.Point(0, 324);
            this.btnGroupChats.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnGroupChats.Name = "btnGroupChats";
            this.btnGroupChats.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnGroupChats.NormalForeColor = System.Drawing.Color.White;
            this.btnGroupChats.NormalOutline = System.Drawing.Color.Empty;
            this.btnGroupChats.OutlineThickness = 2F;
            this.btnGroupChats.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnGroupChats.PressedForeColor = System.Drawing.Color.White;
            this.btnGroupChats.PressedImageTint = System.Drawing.Color.White;
            this.btnGroupChats.PressedOutline = System.Drawing.Color.Empty;
            this.btnGroupChats.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGroupChats.Size = new System.Drawing.Size(235, 35);
            this.btnGroupChats.TabIndex = 8;
            this.btnGroupChats.TextAutoCenter = false;
            this.btnGroupChats.TextOffset = new System.Drawing.Point(0, 0);
            this.btnGroupChats.Click += new System.EventHandler(this.btnGroupChats_Click);
            // 
            // btnGroupMeetings
            // 
            this.btnGroupMeetings.ButtonText = "Group Meetings";
            this.btnGroupMeetings.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnGroupMeetings.CheckedForeColor = System.Drawing.Color.White;
            this.btnGroupMeetings.CheckedImageTint = System.Drawing.Color.White;
            this.btnGroupMeetings.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnGroupMeetings.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGroupMeetings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGroupMeetings.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupMeetings.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnGroupMeetings.HoverForeColor = System.Drawing.Color.White;
            this.btnGroupMeetings.HoverImage = null;
            this.btnGroupMeetings.HoverImageTint = System.Drawing.Color.White;
            this.btnGroupMeetings.HoverOutline = System.Drawing.Color.Empty;
            this.btnGroupMeetings.Image = global::CollaboRate.Properties.Resources.home;
            this.btnGroupMeetings.ImageAutoCenter = false;
            this.btnGroupMeetings.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGroupMeetings.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnGroupMeetings.ImageTint = System.Drawing.Color.White;
            this.btnGroupMeetings.IsToggleButton = false;
            this.btnGroupMeetings.IsToggled = false;
            this.btnGroupMeetings.Location = new System.Drawing.Point(0, 289);
            this.btnGroupMeetings.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnGroupMeetings.Name = "btnGroupMeetings";
            this.btnGroupMeetings.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnGroupMeetings.NormalForeColor = System.Drawing.Color.White;
            this.btnGroupMeetings.NormalOutline = System.Drawing.Color.Empty;
            this.btnGroupMeetings.OutlineThickness = 2F;
            this.btnGroupMeetings.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnGroupMeetings.PressedForeColor = System.Drawing.Color.White;
            this.btnGroupMeetings.PressedImageTint = System.Drawing.Color.White;
            this.btnGroupMeetings.PressedOutline = System.Drawing.Color.Empty;
            this.btnGroupMeetings.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGroupMeetings.Size = new System.Drawing.Size(235, 35);
            this.btnGroupMeetings.TabIndex = 7;
            this.btnGroupMeetings.TextAutoCenter = false;
            this.btnGroupMeetings.TextOffset = new System.Drawing.Point(0, 0);
            this.btnGroupMeetings.Click += new System.EventHandler(this.btnGroupMeetings_Click);
            // 
            // btnGroupTasks
            // 
            this.btnGroupTasks.ButtonText = "Group Tasks";
            this.btnGroupTasks.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnGroupTasks.CheckedForeColor = System.Drawing.Color.White;
            this.btnGroupTasks.CheckedImageTint = System.Drawing.Color.White;
            this.btnGroupTasks.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnGroupTasks.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnGroupTasks.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGroupTasks.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroupTasks.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnGroupTasks.HoverForeColor = System.Drawing.Color.White;
            this.btnGroupTasks.HoverImage = null;
            this.btnGroupTasks.HoverImageTint = System.Drawing.Color.White;
            this.btnGroupTasks.HoverOutline = System.Drawing.Color.Empty;
            this.btnGroupTasks.Image = global::CollaboRate.Properties.Resources.home;
            this.btnGroupTasks.ImageAutoCenter = false;
            this.btnGroupTasks.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnGroupTasks.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnGroupTasks.ImageTint = System.Drawing.Color.White;
            this.btnGroupTasks.IsToggleButton = false;
            this.btnGroupTasks.IsToggled = false;
            this.btnGroupTasks.Location = new System.Drawing.Point(0, 254);
            this.btnGroupTasks.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnGroupTasks.Name = "btnGroupTasks";
            this.btnGroupTasks.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnGroupTasks.NormalForeColor = System.Drawing.Color.White;
            this.btnGroupTasks.NormalOutline = System.Drawing.Color.Empty;
            this.btnGroupTasks.OutlineThickness = 2F;
            this.btnGroupTasks.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnGroupTasks.PressedForeColor = System.Drawing.Color.White;
            this.btnGroupTasks.PressedImageTint = System.Drawing.Color.White;
            this.btnGroupTasks.PressedOutline = System.Drawing.Color.Empty;
            this.btnGroupTasks.Rounding = new System.Windows.Forms.Padding(5);
            this.btnGroupTasks.Size = new System.Drawing.Size(235, 35);
            this.btnGroupTasks.TabIndex = 6;
            this.btnGroupTasks.TextAutoCenter = false;
            this.btnGroupTasks.TextOffset = new System.Drawing.Point(0, 0);
            this.btnGroupTasks.Click += new System.EventHandler(this.btnGroupTasks_Click);
            // 
            // btnMemberEvaluations
            // 
            this.btnMemberEvaluations.ButtonText = "Member Evaluations";
            this.btnMemberEvaluations.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnMemberEvaluations.CheckedForeColor = System.Drawing.Color.White;
            this.btnMemberEvaluations.CheckedImageTint = System.Drawing.Color.White;
            this.btnMemberEvaluations.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnMemberEvaluations.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMemberEvaluations.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMemberEvaluations.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberEvaluations.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnMemberEvaluations.HoverForeColor = System.Drawing.Color.White;
            this.btnMemberEvaluations.HoverImage = null;
            this.btnMemberEvaluations.HoverImageTint = System.Drawing.Color.White;
            this.btnMemberEvaluations.HoverOutline = System.Drawing.Color.Empty;
            this.btnMemberEvaluations.Image = global::CollaboRate.Properties.Resources.home;
            this.btnMemberEvaluations.ImageAutoCenter = false;
            this.btnMemberEvaluations.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnMemberEvaluations.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnMemberEvaluations.ImageTint = System.Drawing.Color.White;
            this.btnMemberEvaluations.IsToggleButton = false;
            this.btnMemberEvaluations.IsToggled = false;
            this.btnMemberEvaluations.Location = new System.Drawing.Point(0, 219);
            this.btnMemberEvaluations.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnMemberEvaluations.Name = "btnMemberEvaluations";
            this.btnMemberEvaluations.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnMemberEvaluations.NormalForeColor = System.Drawing.Color.White;
            this.btnMemberEvaluations.NormalOutline = System.Drawing.Color.Empty;
            this.btnMemberEvaluations.OutlineThickness = 2F;
            this.btnMemberEvaluations.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnMemberEvaluations.PressedForeColor = System.Drawing.Color.White;
            this.btnMemberEvaluations.PressedImageTint = System.Drawing.Color.White;
            this.btnMemberEvaluations.PressedOutline = System.Drawing.Color.Empty;
            this.btnMemberEvaluations.Rounding = new System.Windows.Forms.Padding(5);
            this.btnMemberEvaluations.Size = new System.Drawing.Size(235, 35);
            this.btnMemberEvaluations.TabIndex = 5;
            this.btnMemberEvaluations.TextAutoCenter = false;
            this.btnMemberEvaluations.TextOffset = new System.Drawing.Point(0, 0);
            this.btnMemberEvaluations.Click += new System.EventHandler(this.btnMemberEvaluations_Click);
            // 
            // btnProjectGroups
            // 
            this.btnProjectGroups.ButtonText = "Project Groups";
            this.btnProjectGroups.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnProjectGroups.CheckedForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.CheckedImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnProjectGroups.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProjectGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProjectGroups.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectGroups.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnProjectGroups.HoverForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.HoverImage = null;
            this.btnProjectGroups.HoverImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.HoverOutline = System.Drawing.Color.Empty;
            this.btnProjectGroups.Image = global::CollaboRate.Properties.Resources.Project_Groups_Icon;
            this.btnProjectGroups.ImageAutoCenter = false;
            this.btnProjectGroups.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnProjectGroups.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnProjectGroups.ImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.IsToggleButton = false;
            this.btnProjectGroups.IsToggled = false;
            this.btnProjectGroups.Location = new System.Drawing.Point(0, 184);
            this.btnProjectGroups.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnProjectGroups.Name = "btnProjectGroups";
            this.btnProjectGroups.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnProjectGroups.NormalForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.NormalOutline = System.Drawing.Color.Empty;
            this.btnProjectGroups.OutlineThickness = 2F;
            this.btnProjectGroups.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnProjectGroups.PressedForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.PressedImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.PressedOutline = System.Drawing.Color.Empty;
            this.btnProjectGroups.Rounding = new System.Windows.Forms.Padding(5);
            this.btnProjectGroups.Size = new System.Drawing.Size(235, 35);
            this.btnProjectGroups.TabIndex = 4;
            this.btnProjectGroups.TextAutoCenter = false;
            this.btnProjectGroups.TextOffset = new System.Drawing.Point(0, 0);
            this.btnProjectGroups.Click += new System.EventHandler(this.btnProjectGroups_Click);
            // 
            // btnHome
            // 
            this.btnHome.ButtonText = "Home";
            this.btnHome.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnHome.CheckedForeColor = System.Drawing.Color.White;
            this.btnHome.CheckedImageTint = System.Drawing.Color.White;
            this.btnHome.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnHome.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnHome.HoverForeColor = System.Drawing.Color.White;
            this.btnHome.HoverImage = null;
            this.btnHome.HoverImageTint = System.Drawing.Color.White;
            this.btnHome.HoverOutline = System.Drawing.Color.Empty;
            this.btnHome.Image = global::CollaboRate.Properties.Resources.home;
            this.btnHome.ImageAutoCenter = false;
            this.btnHome.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnHome.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnHome.ImageTint = System.Drawing.Color.White;
            this.btnHome.IsToggleButton = false;
            this.btnHome.IsToggled = false;
            this.btnHome.Location = new System.Drawing.Point(0, 149);
            this.btnHome.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnHome.NormalForeColor = System.Drawing.Color.White;
            this.btnHome.NormalOutline = System.Drawing.Color.Empty;
            this.btnHome.OutlineThickness = 2F;
            this.btnHome.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnHome.PressedForeColor = System.Drawing.Color.White;
            this.btnHome.PressedImageTint = System.Drawing.Color.White;
            this.btnHome.PressedOutline = System.Drawing.Color.Empty;
            this.btnHome.Rounding = new System.Windows.Forms.Padding(5);
            this.btnHome.Size = new System.Drawing.Size(235, 35);
            this.btnHome.TabIndex = 3;
            this.btnHome.TextAutoCenter = false;
            this.btnHome.TextOffset = new System.Drawing.Point(0, 0);
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pnlCurrentGroup
            // 
            this.pnlCurrentGroup.Controls.Add(this.pnlBottomDivider);
            this.pnlCurrentGroup.Controls.Add(this.cmbxCurrentGroup);
            this.pnlCurrentGroup.Controls.Add(this.lblCurrentGroup);
            this.pnlCurrentGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCurrentGroup.Location = new System.Drawing.Point(0, 77);
            this.pnlCurrentGroup.Name = "pnlCurrentGroup";
            this.pnlCurrentGroup.Size = new System.Drawing.Size(235, 72);
            this.pnlCurrentGroup.TabIndex = 2;
            // 
            // pnlBottomDivider
            // 
            this.pnlBottomDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(182)))), ((int)(((byte)(210)))));
            this.pnlBottomDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomDivider.Location = new System.Drawing.Point(0, 71);
            this.pnlBottomDivider.Name = "pnlBottomDivider";
            this.pnlBottomDivider.Size = new System.Drawing.Size(235, 1);
            this.pnlBottomDivider.TabIndex = 11;
            // 
            // cmbxCurrentGroup
            // 
            this.cmbxCurrentGroup.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cmbxCurrentGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxCurrentGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbxCurrentGroup.FormattingEnabled = true;
            this.cmbxCurrentGroup.Location = new System.Drawing.Point(1, 30);
            this.cmbxCurrentGroup.Name = "cmbxCurrentGroup";
            this.cmbxCurrentGroup.Size = new System.Drawing.Size(233, 29);
            this.cmbxCurrentGroup.TabIndex = 10;
            this.cmbxCurrentGroup.SelectedIndexChanged += new System.EventHandler(this.cmbxCurrentGroup_SelectedIndexChanged);
            // 
            // lblCurrentGroup
            // 
            this.lblCurrentGroup.AutoSize = true;
            this.lblCurrentGroup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentGroup.ForeColor = System.Drawing.Color.White;
            this.lblCurrentGroup.Location = new System.Drawing.Point(-2, 3);
            this.lblCurrentGroup.Name = "lblCurrentGroup";
            this.lblCurrentGroup.Size = new System.Drawing.Size(131, 21);
            this.lblCurrentGroup.TabIndex = 2;
            this.lblCurrentGroup.Text = "Current group:";
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.lblName);
            this.pnlLogo.Controls.Add(this.pbxLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(235, 77);
            this.pnlLogo.TabIndex = 1;
            this.pnlLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlLogo_MouseDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(73, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(152, 27);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "CollaboRate";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Location = new System.Drawing.Point(14, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(52, 52);
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnNotification);
            this.pnlTop.Controls.Add(this.btnMinimize);
            this.pnlTop.Controls.Add(this.btnMaximize);
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(235, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(810, 34);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDown);
            // 
            // btnNotification
            // 
            this.btnNotification.ButtonText = "";
            this.btnNotification.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnNotification.CheckedForeColor = System.Drawing.Color.White;
            this.btnNotification.CheckedImageTint = System.Drawing.Color.White;
            this.btnNotification.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnNotification.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNotification.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNotification.HoverBackground = System.Drawing.Color.Gainsboro;
            this.btnNotification.HoverForeColor = System.Drawing.Color.White;
            this.btnNotification.HoverImage = null;
            this.btnNotification.HoverImageTint = System.Drawing.Color.White;
            this.btnNotification.HoverOutline = System.Drawing.Color.Empty;
            this.btnNotification.Image = null;
            this.btnNotification.ImageAutoCenter = true;
            this.btnNotification.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnNotification.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnNotification.ImageTint = System.Drawing.Color.White;
            this.btnNotification.IsToggleButton = false;
            this.btnNotification.IsToggled = false;
            this.btnNotification.Location = new System.Drawing.Point(630, 0);
            this.btnNotification.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.NormalBackground = System.Drawing.SystemColors.Control;
            this.btnNotification.NormalForeColor = System.Drawing.Color.White;
            this.btnNotification.NormalOutline = System.Drawing.Color.Empty;
            this.btnNotification.OutlineThickness = 0F;
            this.btnNotification.PressedBackground = System.Drawing.Color.LightGray;
            this.btnNotification.PressedForeColor = System.Drawing.Color.White;
            this.btnNotification.PressedImageTint = System.Drawing.Color.White;
            this.btnNotification.PressedOutline = System.Drawing.Color.Empty;
            this.btnNotification.Rounding = new System.Windows.Forms.Padding(0);
            this.btnNotification.Size = new System.Drawing.Size(45, 34);
            this.btnNotification.TabIndex = 3;
            this.btnNotification.TextAutoCenter = true;
            this.btnNotification.TextOffset = new System.Drawing.Point(0, 0);
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.ButtonText = "";
            this.btnMinimize.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnMinimize.CheckedForeColor = System.Drawing.Color.White;
            this.btnMinimize.CheckedImageTint = System.Drawing.Color.White;
            this.btnMinimize.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnMinimize.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMinimize.HoverBackground = System.Drawing.Color.Gainsboro;
            this.btnMinimize.HoverForeColor = System.Drawing.Color.White;
            this.btnMinimize.HoverImage = null;
            this.btnMinimize.HoverImageTint = System.Drawing.Color.White;
            this.btnMinimize.HoverOutline = System.Drawing.Color.Empty;
            this.btnMinimize.Image = null;
            this.btnMinimize.ImageAutoCenter = true;
            this.btnMinimize.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnMinimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMinimize.ImageTint = System.Drawing.Color.White;
            this.btnMinimize.IsToggleButton = false;
            this.btnMinimize.IsToggled = false;
            this.btnMinimize.Location = new System.Drawing.Point(675, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.NormalBackground = System.Drawing.SystemColors.Control;
            this.btnMinimize.NormalForeColor = System.Drawing.Color.White;
            this.btnMinimize.NormalOutline = System.Drawing.Color.Empty;
            this.btnMinimize.OutlineThickness = 0F;
            this.btnMinimize.PressedBackground = System.Drawing.Color.LightGray;
            this.btnMinimize.PressedForeColor = System.Drawing.Color.White;
            this.btnMinimize.PressedImageTint = System.Drawing.Color.White;
            this.btnMinimize.PressedOutline = System.Drawing.Color.Empty;
            this.btnMinimize.Rounding = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Size = new System.Drawing.Size(45, 34);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.TextAutoCenter = true;
            this.btnMinimize.TextOffset = new System.Drawing.Point(0, 0);
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.ButtonText = "";
            this.btnMaximize.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnMaximize.CheckedForeColor = System.Drawing.Color.White;
            this.btnMaximize.CheckedImageTint = System.Drawing.Color.White;
            this.btnMaximize.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnMaximize.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMaximize.HoverBackground = System.Drawing.Color.Gainsboro;
            this.btnMaximize.HoverForeColor = System.Drawing.Color.White;
            this.btnMaximize.HoverImage = null;
            this.btnMaximize.HoverImageTint = System.Drawing.Color.White;
            this.btnMaximize.HoverOutline = System.Drawing.Color.Empty;
            this.btnMaximize.Image = null;
            this.btnMaximize.ImageAutoCenter = true;
            this.btnMaximize.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnMaximize.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMaximize.ImageTint = System.Drawing.Color.White;
            this.btnMaximize.IsToggleButton = false;
            this.btnMaximize.IsToggled = false;
            this.btnMaximize.Location = new System.Drawing.Point(720, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.NormalBackground = System.Drawing.SystemColors.Control;
            this.btnMaximize.NormalForeColor = System.Drawing.Color.White;
            this.btnMaximize.NormalOutline = System.Drawing.Color.Empty;
            this.btnMaximize.OutlineThickness = 0F;
            this.btnMaximize.PressedBackground = System.Drawing.Color.LightGray;
            this.btnMaximize.PressedForeColor = System.Drawing.Color.White;
            this.btnMaximize.PressedImageTint = System.Drawing.Color.White;
            this.btnMaximize.PressedOutline = System.Drawing.Color.Empty;
            this.btnMaximize.Rounding = new System.Windows.Forms.Padding(0);
            this.btnMaximize.Size = new System.Drawing.Size(45, 34);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.TextAutoCenter = true;
            this.btnMaximize.TextOffset = new System.Drawing.Point(0, 0);
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnClose
            // 
            this.btnClose.ButtonText = "";
            this.btnClose.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnClose.CheckedForeColor = System.Drawing.Color.White;
            this.btnClose.CheckedImageTint = System.Drawing.Color.White;
            this.btnClose.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnClose.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.HoverBackground = System.Drawing.Color.Red;
            this.btnClose.HoverForeColor = System.Drawing.Color.White;
            this.btnClose.HoverImage = null;
            this.btnClose.HoverImageTint = System.Drawing.Color.White;
            this.btnClose.HoverOutline = System.Drawing.Color.Empty;
            this.btnClose.Image = null;
            this.btnClose.ImageAutoCenter = true;
            this.btnClose.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnClose.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnClose.ImageTint = System.Drawing.Color.White;
            this.btnClose.IsToggleButton = false;
            this.btnClose.IsToggled = false;
            this.btnClose.Location = new System.Drawing.Point(765, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalBackground = System.Drawing.SystemColors.Control;
            this.btnClose.NormalForeColor = System.Drawing.Color.White;
            this.btnClose.NormalOutline = System.Drawing.Color.Empty;
            this.btnClose.OutlineThickness = 0F;
            this.btnClose.PressedBackground = System.Drawing.Color.RosyBrown;
            this.btnClose.PressedForeColor = System.Drawing.Color.White;
            this.btnClose.PressedImageTint = System.Drawing.Color.White;
            this.btnClose.PressedOutline = System.Drawing.Color.Empty;
            this.btnClose.Rounding = new System.Windows.Forms.Padding(0);
            this.btnClose.Size = new System.Drawing.Size(45, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.TextAutoCenter = true;
            this.btnClose.TextOffset = new System.Drawing.Point(0, 0);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(235, 34);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(810, 627);
            this.pnlMain.TabIndex = 2;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlSidemenu);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSidemenu.ResumeLayout(false);
            this.pnlCurrentGroup.ResumeLayout(false);
            this.pnlCurrentGroup.PerformLayout();
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidemenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Panel pnlCurrentGroup;
        private System.Windows.Forms.Label lblCurrentGroup;
        private FrameworkTest.SATAButton btnHome;
        private FrameworkTest.SATAButton btnSettings;
        private FrameworkTest.SATAButton btnGroupChats;
        private FrameworkTest.SATAButton btnGroupMeetings;
        private FrameworkTest.SATAButton btnGroupTasks;
        private FrameworkTest.SATAButton btnMemberEvaluations;
        private FrameworkTest.SATAButton btnProjectGroups;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlMain;
        private FrameworkTest.SATAButton btnClose;
        private FrameworkTest.SATAButton btnMinimize;
        private FrameworkTest.SATAButton btnMaximize;
        private System.Windows.Forms.Panel pnlTopDiveder;
        private System.Windows.Forms.Panel pnlBottomDivider;
        private System.Windows.Forms.Panel panel1;
        private FrameworkTest.SATAButton btnLogout;
        private FrameworkTest.SATAButton btnNotification;
        private System.Windows.Forms.Button btnWarning;
        private System.Windows.Forms.Button btnError;
        private System.Windows.Forms.Button btnSuccess;
        private System.Windows.Forms.Button btnInformation;
        public System.Windows.Forms.ComboBox cmbxCurrentGroup;
    }
}

