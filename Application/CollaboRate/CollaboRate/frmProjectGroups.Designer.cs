namespace CollaboRate
{
    partial class frmProjectGroups
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblCurrentProjectGroup = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlCurrentGroup = new SATAUiFramework.SATAPanel();
            this.lblNumOfMembers = new System.Windows.Forms.Label();
            this.pbxNumOfMembers = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditGroup = new FrameworkTest.SATAButton();
            this.lblGroupDescription = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.pbxGroupNameIcon = new System.Windows.Forms.PictureBox();
            this.btnCreateNewGroup = new FrameworkTest.SATAButton();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgViewJoinRequests = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptRequest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Control_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RejectRequest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.txtSearchGroup = new SATATextBox();
            this.dgViewProjectGroups = new System.Windows.Forms.DataGridView();
            this.Group_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestCancelJoin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlCurrentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNumOfMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGroupNameIcon)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewJoinRequests)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewProjectGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblCurrentProjectGroup);
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.pnlCurrentGroup);
            this.pnlTop.Controls.Add(this.btnCreateNewGroup);
            this.pnlTop.Controls.Add(this.lblHeading);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(810, 283);
            this.pnlTop.TabIndex = 0;
            // 
            // lblCurrentProjectGroup
            // 
            this.lblCurrentProjectGroup.AutoSize = true;
            this.lblCurrentProjectGroup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProjectGroup.Location = new System.Drawing.Point(16, 96);
            this.lblCurrentProjectGroup.Name = "lblCurrentProjectGroup";
            this.lblCurrentProjectGroup.Size = new System.Drawing.Size(184, 19);
            this.lblCurrentProjectGroup.TabIndex = 11;
            this.lblCurrentProjectGroup.Text = "Current Project Group";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlCurrentGroup
            // 
            this.pnlCurrentGroup.BackColor = System.Drawing.Color.White;
            this.pnlCurrentGroup.BackColor2 = System.Drawing.Color.White;
            this.pnlCurrentGroup.BorderColor = System.Drawing.Color.LightGray;
            borderRadius1.BottomLeft = 5;
            borderRadius1.BottomRight = 5;
            borderRadius1.TopLeft = 5;
            borderRadius1.TopRight = 5;
            this.pnlCurrentGroup.BorderRadius = borderRadius1;
            this.pnlCurrentGroup.BorderThickness = 2;
            this.pnlCurrentGroup.Controls.Add(this.lblNumOfMembers);
            this.pnlCurrentGroup.Controls.Add(this.pbxNumOfMembers);
            this.pnlCurrentGroup.Controls.Add(this.panel1);
            this.pnlCurrentGroup.Controls.Add(this.btnEditGroup);
            this.pnlCurrentGroup.Controls.Add(this.lblGroupDescription);
            this.pnlCurrentGroup.Controls.Add(this.lblGroupName);
            this.pnlCurrentGroup.Controls.Add(this.pbxGroupNameIcon);
            this.pnlCurrentGroup.Location = new System.Drawing.Point(18, 122);
            this.pnlCurrentGroup.Name = "pnlCurrentGroup";
            this.pnlCurrentGroup.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.pnlCurrentGroup.Size = new System.Drawing.Size(774, 151);
            this.pnlCurrentGroup.TabIndex = 10;
            // 
            // lblNumOfMembers
            // 
            this.lblNumOfMembers.AutoSize = true;
            this.lblNumOfMembers.Location = new System.Drawing.Point(36, 91);
            this.lblNumOfMembers.Name = "lblNumOfMembers";
            this.lblNumOfMembers.Size = new System.Drawing.Size(178, 21);
            this.lblNumOfMembers.TabIndex = 6;
            this.lblNumOfMembers.Text = "Number of members";
            // 
            // pbxNumOfMembers
            // 
            this.pbxNumOfMembers.Location = new System.Drawing.Point(13, 91);
            this.pbxNumOfMembers.Name = "pbxNumOfMembers";
            this.pbxNumOfMembers.Size = new System.Drawing.Size(20, 20);
            this.pbxNumOfMembers.TabIndex = 5;
            this.pbxNumOfMembers.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(2, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 1);
            this.panel1.TabIndex = 4;
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.ButtonText = "Edit Group";
            this.btnEditGroup.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnEditGroup.CheckedForeColor = System.Drawing.Color.White;
            this.btnEditGroup.CheckedImageTint = System.Drawing.Color.White;
            this.btnEditGroup.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnEditGroup.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroup.HoverBackground = System.Drawing.Color.Gainsboro;
            this.btnEditGroup.HoverForeColor = System.Drawing.Color.Black;
            this.btnEditGroup.HoverImage = null;
            this.btnEditGroup.HoverImageTint = System.Drawing.Color.White;
            this.btnEditGroup.HoverOutline = System.Drawing.Color.Empty;
            this.btnEditGroup.Image = null;
            this.btnEditGroup.ImageAutoCenter = true;
            this.btnEditGroup.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnEditGroup.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnEditGroup.ImageTint = System.Drawing.Color.White;
            this.btnEditGroup.IsToggleButton = false;
            this.btnEditGroup.IsToggled = false;
            this.btnEditGroup.Location = new System.Drawing.Point(2, 118);
            this.btnEditGroup.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.NormalBackground = System.Drawing.Color.White;
            this.btnEditGroup.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnEditGroup.NormalOutline = System.Drawing.Color.Empty;
            this.btnEditGroup.OutlineThickness = 2F;
            this.btnEditGroup.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnEditGroup.PressedForeColor = System.Drawing.Color.White;
            this.btnEditGroup.PressedImageTint = System.Drawing.Color.White;
            this.btnEditGroup.PressedOutline = System.Drawing.Color.Empty;
            this.btnEditGroup.Rounding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.btnEditGroup.Size = new System.Drawing.Size(770, 29);
            this.btnEditGroup.TabIndex = 3;
            this.btnEditGroup.TextAutoCenter = true;
            this.btnEditGroup.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblGroupDescription
            // 
            this.lblGroupDescription.AutoSize = true;
            this.lblGroupDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lblGroupDescription.Location = new System.Drawing.Point(10, 38);
            this.lblGroupDescription.Name = "lblGroupDescription";
            this.lblGroupDescription.Size = new System.Drawing.Size(161, 21);
            this.lblGroupDescription.TabIndex = 2;
            this.lblGroupDescription.Text = "Group Description";
            // 
            // lblGroupName
            // 
            this.lblGroupName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.Location = new System.Drawing.Point(37, 10);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(721, 20);
            this.lblGroupName.TabIndex = 1;
            this.lblGroupName.Text = "Group Name";
            // 
            // pbxGroupNameIcon
            // 
            this.pbxGroupNameIcon.Location = new System.Drawing.Point(13, 10);
            this.pbxGroupNameIcon.Name = "pbxGroupNameIcon";
            this.pbxGroupNameIcon.Size = new System.Drawing.Size(20, 20);
            this.pbxGroupNameIcon.TabIndex = 0;
            this.pbxGroupNameIcon.TabStop = false;
            // 
            // btnCreateNewGroup
            // 
            this.btnCreateNewGroup.ButtonText = "Create New Group";
            this.btnCreateNewGroup.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCreateNewGroup.CheckedForeColor = System.Drawing.Color.White;
            this.btnCreateNewGroup.CheckedImageTint = System.Drawing.Color.White;
            this.btnCreateNewGroup.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCreateNewGroup.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateNewGroup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewGroup.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnCreateNewGroup.HoverForeColor = System.Drawing.Color.White;
            this.btnCreateNewGroup.HoverImage = null;
            this.btnCreateNewGroup.HoverImageTint = System.Drawing.Color.White;
            this.btnCreateNewGroup.HoverOutline = System.Drawing.Color.Empty;
            this.btnCreateNewGroup.Image = global::CollaboRate.Properties.Resources.home;
            this.btnCreateNewGroup.ImageAutoCenter = false;
            this.btnCreateNewGroup.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCreateNewGroup.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnCreateNewGroup.ImageTint = System.Drawing.Color.White;
            this.btnCreateNewGroup.IsToggleButton = false;
            this.btnCreateNewGroup.IsToggled = false;
            this.btnCreateNewGroup.Location = new System.Drawing.Point(557, 27);
            this.btnCreateNewGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCreateNewGroup.Name = "btnCreateNewGroup";
            this.btnCreateNewGroup.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnCreateNewGroup.NormalForeColor = System.Drawing.Color.White;
            this.btnCreateNewGroup.NormalOutline = System.Drawing.Color.Empty;
            this.btnCreateNewGroup.OutlineThickness = 2F;
            this.btnCreateNewGroup.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnCreateNewGroup.PressedForeColor = System.Drawing.Color.White;
            this.btnCreateNewGroup.PressedImageTint = System.Drawing.Color.White;
            this.btnCreateNewGroup.PressedOutline = System.Drawing.Color.Empty;
            this.btnCreateNewGroup.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCreateNewGroup.Size = new System.Drawing.Size(235, 35);
            this.btnCreateNewGroup.TabIndex = 9;
            this.btnCreateNewGroup.TextAutoCenter = false;
            this.btnCreateNewGroup.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(325, 27);
            this.lblHeading.TabIndex = 8;
            this.lblHeading.Text = "Project Group Management";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.label1);
            this.pnlMiddle.Controls.Add(this.dgViewJoinRequests);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 283);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(810, 119);
            this.pnlMiddle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pending Membership Requests";
            // 
            // dgViewJoinRequests
            // 
            this.dgViewJoinRequests.AllowUserToAddRows = false;
            this.dgViewJoinRequests.AllowUserToDeleteRows = false;
            this.dgViewJoinRequests.AllowUserToResizeColumns = false;
            this.dgViewJoinRequests.AllowUserToResizeRows = false;
            this.dgViewJoinRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgViewJoinRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewJoinRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewJoinRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewJoinRequests.ColumnHeadersHeight = 35;
            this.dgViewJoinRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewJoinRequests.ColumnHeadersVisible = false;
            this.dgViewJoinRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Name,
            this.AcceptRequest,
            this.Control_Column,
            this.RejectRequest});
            this.dgViewJoinRequests.EnableHeadersVisualStyles = false;
            this.dgViewJoinRequests.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewJoinRequests.Location = new System.Drawing.Point(18, 26);
            this.dgViewJoinRequests.Name = "dgViewJoinRequests";
            this.dgViewJoinRequests.ReadOnly = true;
            this.dgViewJoinRequests.RowHeadersVisible = false;
            this.dgViewJoinRequests.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewJoinRequests.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewJoinRequests.RowTemplate.DividerHeight = 5;
            this.dgViewJoinRequests.RowTemplate.Height = 35;
            this.dgViewJoinRequests.Size = new System.Drawing.Size(774, 93);
            this.dgViewJoinRequests.TabIndex = 0;
            // 
            // User_ID
            // 
            this.User_ID.HeaderText = "User ID";
            this.User_ID.MinimumWidth = 6;
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Visible = false;
            this.User_ID.Width = 125;
            // 
            // User_Name
            // 
            this.User_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_Name.HeaderText = "Username";
            this.User_Name.MinimumWidth = 6;
            this.User_Name.Name = "User_Name";
            this.User_Name.ReadOnly = true;
            // 
            // AcceptRequest
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.AcceptRequest.DefaultCellStyle = dataGridViewCellStyle2;
            this.AcceptRequest.FillWeight = 75F;
            this.AcceptRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AcceptRequest.HeaderText = "Accept";
            this.AcceptRequest.MinimumWidth = 6;
            this.AcceptRequest.Name = "AcceptRequest";
            this.AcceptRequest.ReadOnly = true;
            this.AcceptRequest.Text = "Accept";
            this.AcceptRequest.UseColumnTextForButtonValue = true;
            this.AcceptRequest.Width = 114;
            // 
            // Control_Column
            // 
            this.Control_Column.HeaderText = "Control Column";
            this.Control_Column.MinimumWidth = 6;
            this.Control_Column.Name = "Control_Column";
            this.Control_Column.ReadOnly = true;
            this.Control_Column.Width = 6;
            // 
            // RejectRequest
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(45)))), ((int)(((byte)(0)))));
            this.RejectRequest.DefaultCellStyle = dataGridViewCellStyle3;
            this.RejectRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RejectRequest.HeaderText = "Reject";
            this.RejectRequest.MinimumWidth = 6;
            this.RejectRequest.Name = "RejectRequest";
            this.RejectRequest.ReadOnly = true;
            this.RejectRequest.Text = "Reject";
            this.RejectRequest.UseColumnTextForButtonValue = true;
            this.RejectRequest.Width = 114;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.txtSearchGroup);
            this.pnlBottom.Controls.Add(this.dgViewProjectGroups);
            this.pnlBottom.Controls.Add(this.label2);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 402);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(810, 225);
            this.pnlBottom.TabIndex = 2;
            // 
            // txtSearchGroup
            // 
            this.txtSearchGroup.BackColor = System.Drawing.Color.White;
            this.txtSearchGroup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchGroup.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtSearchGroup.BorderRadius = 5;
            this.txtSearchGroup.BorderSize = 1;
            this.txtSearchGroup.Icon = null;
            this.txtSearchGroup.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchGroup.Location = new System.Drawing.Point(20, 45);
            this.txtSearchGroup.Multiline = false;
            this.txtSearchGroup.Name = "txtSearchGroup";
            this.txtSearchGroup.PasswordChar = false;
            this.txtSearchGroup.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchGroup.PlaceholderText = "Search project group";
            this.txtSearchGroup.Size = new System.Drawing.Size(770, 39);
            this.txtSearchGroup.TabIndex = 14;
            this.txtSearchGroup.Texts = "";
            this.txtSearchGroup.UnderlinedStyle = false;
            // 
            // dgViewProjectGroups
            // 
            this.dgViewProjectGroups.AllowUserToAddRows = false;
            this.dgViewProjectGroups.AllowUserToDeleteRows = false;
            this.dgViewProjectGroups.AllowUserToResizeColumns = false;
            this.dgViewProjectGroups.AllowUserToResizeRows = false;
            this.dgViewProjectGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgViewProjectGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewProjectGroups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewProjectGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgViewProjectGroups.ColumnHeadersHeight = 35;
            this.dgViewProjectGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewProjectGroups.ColumnHeadersVisible = false;
            this.dgViewProjectGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group_ID,
            this.Group_Name,
            this.RequestCancelJoin});
            this.dgViewProjectGroups.EnableHeadersVisualStyles = false;
            this.dgViewProjectGroups.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewProjectGroups.Location = new System.Drawing.Point(20, 95);
            this.dgViewProjectGroups.Name = "dgViewProjectGroups";
            this.dgViewProjectGroups.ReadOnly = true;
            this.dgViewProjectGroups.RowHeadersVisible = false;
            this.dgViewProjectGroups.RowHeadersWidth = 51;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewProjectGroups.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgViewProjectGroups.RowTemplate.DividerHeight = 5;
            this.dgViewProjectGroups.RowTemplate.Height = 35;
            this.dgViewProjectGroups.Size = new System.Drawing.Size(772, 118);
            this.dgViewProjectGroups.TabIndex = 13;
            // 
            // Group_ID
            // 
            this.Group_ID.HeaderText = "Group ID";
            this.Group_ID.MinimumWidth = 6;
            this.Group_ID.Name = "Group_ID";
            this.Group_ID.ReadOnly = true;
            this.Group_ID.Visible = false;
            this.Group_ID.Width = 125;
            // 
            // Group_Name
            // 
            this.Group_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Group_Name.HeaderText = "Group Name";
            this.Group_Name.MinimumWidth = 6;
            this.Group_Name.Name = "Group_Name";
            this.Group_Name.ReadOnly = true;
            // 
            // RequestCancelJoin
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.RequestCancelJoin.DefaultCellStyle = dataGridViewCellStyle6;
            this.RequestCancelJoin.FillWeight = 75F;
            this.RequestCancelJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RequestCancelJoin.HeaderText = "Action";
            this.RequestCancelJoin.MinimumWidth = 6;
            this.RequestCancelJoin.Name = "RequestCancelJoin";
            this.RequestCancelJoin.ReadOnly = true;
            this.RequestCancelJoin.Text = "Request To Join";
            this.RequestCancelJoin.UseColumnTextForButtonValue = true;
            this.RequestCancelJoin.Width = 235;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Search && Join Other Groups";
            // 
            // frmProjectGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProjectGroups";
            this.Text = "frmProjectGroups";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlCurrentGroup.ResumeLayout(false);
            this.pnlCurrentGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNumOfMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGroupNameIcon)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewJoinRequests)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewProjectGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblCurrentProjectGroup;
        private SATAUiFramework.SATAPanel pnlCurrentGroup;
        private FrameworkTest.SATAButton btnCreateNewGroup;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.PictureBox pbxGroupNameIcon;
        private System.Windows.Forms.Label lblGroupDescription;
        private FrameworkTest.SATAButton btnEditGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumOfMembers;
        private System.Windows.Forms.PictureBox pbxNumOfMembers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgViewJoinRequests;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgViewProjectGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewButtonColumn AcceptRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control_Column;
        private System.Windows.Forms.DataGridViewButtonColumn RejectRequest;
        private SATATextBox txtSearchGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group_Name;
        private System.Windows.Forms.DataGridViewButtonColumn RequestCancelJoin;
    }
}