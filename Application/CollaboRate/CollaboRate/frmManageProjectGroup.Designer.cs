namespace CollaboRate
{
    partial class frmEditGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgViewUsers = new System.Windows.Forms.DataGridView();
            this.txtSearchUsername = new SATATextBox();
            this.lblGroupDescriptionError = new System.Windows.Forms.Label();
            this.lblGroupNameError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupDescription = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new FrameworkTest.SATAButton();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Role = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAddNewMembers = new FrameworkTest.SATAButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewUsers
            // 
            this.dgViewUsers.AllowUserToAddRows = false;
            this.dgViewUsers.AllowUserToDeleteRows = false;
            this.dgViewUsers.AllowUserToResizeColumns = false;
            this.dgViewUsers.AllowUserToResizeRows = false;
            this.dgViewUsers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgViewUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewUsers.ColumnHeadersHeight = 28;
            this.dgViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Name,
            this.User_Role});
            this.dgViewUsers.EnableHeadersVisualStyles = false;
            this.dgViewUsers.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewUsers.Location = new System.Drawing.Point(34, 387);
            this.dgViewUsers.Name = "dgViewUsers";
            this.dgViewUsers.ReadOnly = true;
            this.dgViewUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewUsers.RowHeadersVisible = false;
            this.dgViewUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewUsers.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgViewUsers.RowTemplate.Height = 28;
            this.dgViewUsers.Size = new System.Drawing.Size(344, 144);
            this.dgViewUsers.TabIndex = 33;
            // 
            // txtSearchUsername
            // 
            this.txtSearchUsername.BackColor = System.Drawing.Color.White;
            this.txtSearchUsername.BorderColor = System.Drawing.Color.DimGray;
            this.txtSearchUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtSearchUsername.BorderRadius = 5;
            this.txtSearchUsername.BorderSize = 1;
            this.txtSearchUsername.Icon = null;
            this.txtSearchUsername.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchUsername.Location = new System.Drawing.Point(34, 336);
            this.txtSearchUsername.Multiline = false;
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.PasswordChar = false;
            this.txtSearchUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchUsername.PlaceholderText = "Search username";
            this.txtSearchUsername.Size = new System.Drawing.Size(344, 39);
            this.txtSearchUsername.TabIndex = 32;
            this.txtSearchUsername.Texts = "";
            this.txtSearchUsername.UnderlinedStyle = false;
            // 
            // lblGroupDescriptionError
            // 
            this.lblGroupDescriptionError.AutoSize = true;
            this.lblGroupDescriptionError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblGroupDescriptionError.Location = new System.Drawing.Point(33, 274);
            this.lblGroupDescriptionError.Name = "lblGroupDescriptionError";
            this.lblGroupDescriptionError.Size = new System.Drawing.Size(35, 16);
            this.lblGroupDescriptionError.TabIndex = 31;
            this.lblGroupDescriptionError.Text = "Error";
            this.lblGroupDescriptionError.Visible = false;
            // 
            // lblGroupNameError
            // 
            this.lblGroupNameError.AutoSize = true;
            this.lblGroupNameError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupNameError.ForeColor = System.Drawing.Color.Red;
            this.lblGroupNameError.Location = new System.Drawing.Point(34, 125);
            this.lblGroupNameError.Name = "lblGroupNameError";
            this.lblGroupNameError.Size = new System.Drawing.Size(35, 16);
            this.lblGroupNameError.TabIndex = 30;
            this.lblGroupNameError.Text = "Error";
            this.lblGroupNameError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Group Description";
            // 
            // txtGroupDescription
            // 
            this.txtGroupDescription.BackColor = System.Drawing.Color.White;
            this.txtGroupDescription.BorderColor = System.Drawing.Color.DimGray;
            this.txtGroupDescription.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtGroupDescription.BorderRadius = 5;
            this.txtGroupDescription.BorderSize = 1;
            this.txtGroupDescription.Icon = null;
            this.txtGroupDescription.IconSize = new System.Drawing.Size(20, 20);
            this.txtGroupDescription.Location = new System.Drawing.Point(34, 177);
            this.txtGroupDescription.Multiline = true;
            this.txtGroupDescription.Name = "txtGroupDescription";
            this.txtGroupDescription.PasswordChar = false;
            this.txtGroupDescription.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtGroupDescription.PlaceholderText = "Enter group description";
            this.txtGroupDescription.Size = new System.Drawing.Size(344, 94);
            this.txtGroupDescription.TabIndex = 28;
            this.txtGroupDescription.Texts = "";
            this.txtGroupDescription.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Group Name";
            // 
            // txtGroupName
            // 
            this.txtGroupName.BackColor = System.Drawing.Color.White;
            this.txtGroupName.BorderColor = System.Drawing.Color.DimGray;
            this.txtGroupName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtGroupName.BorderRadius = 5;
            this.txtGroupName.BorderSize = 1;
            this.txtGroupName.Icon = null;
            this.txtGroupName.IconSize = new System.Drawing.Size(20, 20);
            this.txtGroupName.Location = new System.Drawing.Point(35, 84);
            this.txtGroupName.Multiline = false;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.PasswordChar = false;
            this.txtGroupName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtGroupName.PlaceholderText = "Enter group name";
            this.txtGroupName.Size = new System.Drawing.Size(344, 39);
            this.txtGroupName.TabIndex = 26;
            this.txtGroupName.Texts = "";
            this.txtGroupName.UnderlinedStyle = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(91, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(232, 23);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Manage Project Group";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Group Members";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.ButtonText = "Save Changes";
            this.btnSaveChanges.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.CheckedForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.CheckedImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveChanges.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSaveChanges.HoverForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.HoverImage = null;
            this.btnSaveChanges.HoverImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.HoverOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.Image = null;
            this.btnSaveChanges.ImageAutoCenter = false;
            this.btnSaveChanges.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSaveChanges.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSaveChanges.ImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.IsToggleButton = false;
            this.btnSaveChanges.IsToggled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(210, 560);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSaveChanges.NormalForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.NormalOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.OutlineThickness = 2F;
            this.btnSaveChanges.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSaveChanges.PressedForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.PressedImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.PressedOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSaveChanges.Size = new System.Drawing.Size(169, 35);
            this.btnSaveChanges.TabIndex = 34;
            this.btnSaveChanges.TextAutoCenter = true;
            this.btnSaveChanges.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSaveChanges.Click += new System.EventHandler(this.btnCreateGroup_Click);
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
            // User_Role
            // 
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.User_Role.DefaultCellStyle = dataGridViewCellStyle5;
            this.User_Role.FillWeight = 75F;
            this.User_Role.HeaderText = "Role";
            this.User_Role.Items.AddRange(new object[] {
            "Member",
            "Admin"});
            this.User_Role.MinimumWidth = 6;
            this.User_Role.Name = "User_Role";
            this.User_Role.ReadOnly = true;
            this.User_Role.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.User_Role.Width = 125;
            // 
            // btnAddNewMembers
            // 
            this.btnAddNewMembers.ButtonText = "Add New Members";
            this.btnAddNewMembers.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnAddNewMembers.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddNewMembers.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddNewMembers.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAddNewMembers.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddNewMembers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewMembers.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnAddNewMembers.HoverForeColor = System.Drawing.Color.White;
            this.btnAddNewMembers.HoverImage = null;
            this.btnAddNewMembers.HoverImageTint = System.Drawing.Color.White;
            this.btnAddNewMembers.HoverOutline = System.Drawing.Color.Empty;
            this.btnAddNewMembers.Image = null;
            this.btnAddNewMembers.ImageAutoCenter = false;
            this.btnAddNewMembers.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAddNewMembers.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnAddNewMembers.ImageTint = System.Drawing.Color.White;
            this.btnAddNewMembers.IsToggleButton = false;
            this.btnAddNewMembers.IsToggled = false;
            this.btnAddNewMembers.Location = new System.Drawing.Point(34, 560);
            this.btnAddNewMembers.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAddNewMembers.Name = "btnAddNewMembers";
            this.btnAddNewMembers.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnAddNewMembers.NormalForeColor = System.Drawing.Color.White;
            this.btnAddNewMembers.NormalOutline = System.Drawing.Color.Empty;
            this.btnAddNewMembers.OutlineThickness = 2F;
            this.btnAddNewMembers.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAddNewMembers.PressedForeColor = System.Drawing.Color.White;
            this.btnAddNewMembers.PressedImageTint = System.Drawing.Color.White;
            this.btnAddNewMembers.PressedOutline = System.Drawing.Color.Empty;
            this.btnAddNewMembers.Rounding = new System.Windows.Forms.Padding(5);
            this.btnAddNewMembers.Size = new System.Drawing.Size(169, 35);
            this.btnAddNewMembers.TabIndex = 36;
            this.btnAddNewMembers.TextAutoCenter = true;
            this.btnAddNewMembers.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddNewMembers.Click += new System.EventHandler(this.btnAddNewMembers_Click);
            // 
            // frmEditGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 611);
            this.Controls.Add(this.btnAddNewMembers);
            this.Controls.Add(this.dgViewUsers);
            this.Controls.Add(this.txtSearchUsername);
            this.Controls.Add(this.lblGroupDescriptionError);
            this.Controls.Add(this.lblGroupNameError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSaveChanges);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEditGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewUsers;
        private SATATextBox txtSearchUsername;
        private System.Windows.Forms.Label lblGroupDescriptionError;
        private System.Windows.Forms.Label lblGroupNameError;
        private System.Windows.Forms.Label label2;
        private SATATextBox txtGroupDescription;
        private System.Windows.Forms.Label label1;
        private SATATextBox txtGroupName;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label3;
        private FrameworkTest.SATAButton btnSaveChanges;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn User_Role;
        private FrameworkTest.SATAButton btnAddNewMembers;
    }
}