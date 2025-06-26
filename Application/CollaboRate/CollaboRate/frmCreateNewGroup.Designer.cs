namespace CollaboRate
{
    partial class frmCreateNewGroup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCurrentProjectGroup = new System.Windows.Forms.Label();
            this.txtGroupName = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupDescription = new SATATextBox();
            this.lblGroupNameError = new System.Windows.Forms.Label();
            this.lblGroupDescriptionError = new System.Windows.Forms.Label();
            this.txtSearchUsername = new SATATextBox();
            this.dgViewUsers = new System.Windows.Forms.DataGridView();
            this.btnCreateGroup = new FrameworkTest.SATAButton();
            this.label3 = new System.Windows.Forms.Label();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurrentProjectGroup
            // 
            this.lblCurrentProjectGroup.AutoSize = true;
            this.lblCurrentProjectGroup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentProjectGroup.Location = new System.Drawing.Point(109, 3);
            this.lblCurrentProjectGroup.Name = "lblCurrentProjectGroup";
            this.lblCurrentProjectGroup.Size = new System.Drawing.Size(194, 23);
            this.lblCurrentProjectGroup.TabIndex = 13;
            this.lblCurrentProjectGroup.Text = "Create New Group";
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
            this.txtGroupName.TabIndex = 15;
            this.txtGroupName.Texts = "";
            this.txtGroupName.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 16;
            this.label1.Text = "Group Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 21);
            this.label2.TabIndex = 18;
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
            this.txtGroupDescription.TabIndex = 17;
            this.txtGroupDescription.Texts = "";
            this.txtGroupDescription.UnderlinedStyle = false;
            // 
            // lblGroupNameError
            // 
            this.lblGroupNameError.AutoSize = true;
            this.lblGroupNameError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupNameError.ForeColor = System.Drawing.Color.Red;
            this.lblGroupNameError.Location = new System.Drawing.Point(34, 125);
            this.lblGroupNameError.Name = "lblGroupNameError";
            this.lblGroupNameError.Size = new System.Drawing.Size(35, 16);
            this.lblGroupNameError.TabIndex = 19;
            this.lblGroupNameError.Text = "Error";
            this.lblGroupNameError.Visible = false;
            // 
            // lblGroupDescriptionError
            // 
            this.lblGroupDescriptionError.AutoSize = true;
            this.lblGroupDescriptionError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblGroupDescriptionError.Location = new System.Drawing.Point(33, 274);
            this.lblGroupDescriptionError.Name = "lblGroupDescriptionError";
            this.lblGroupDescriptionError.Size = new System.Drawing.Size(35, 16);
            this.lblGroupDescriptionError.TabIndex = 20;
            this.lblGroupDescriptionError.Text = "Error";
            this.lblGroupDescriptionError.Visible = false;
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
            this.txtSearchUsername.TabIndex = 21;
            this.txtSearchUsername.Texts = "";
            this.txtSearchUsername.UnderlinedStyle = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewUsers.ColumnHeadersHeight = 35;
            this.dgViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewUsers.ColumnHeadersVisible = false;
            this.dgViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Name,
            this.Action});
            this.dgViewUsers.EnableHeadersVisualStyles = false;
            this.dgViewUsers.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewUsers.Location = new System.Drawing.Point(34, 387);
            this.dgViewUsers.Name = "dgViewUsers";
            this.dgViewUsers.ReadOnly = true;
            this.dgViewUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewUsers.RowHeadersVisible = false;
            this.dgViewUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewUsers.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewUsers.RowTemplate.Height = 35;
            this.dgViewUsers.Size = new System.Drawing.Size(344, 144);
            this.dgViewUsers.TabIndex = 22;
            this.dgViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewUsers_CellClick);
            this.dgViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewUsers_CellContentClick);
            this.dgViewUsers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgViewUsers_CurrentCellDirtyStateChanged);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.ButtonText = "Create Group";
            this.btnCreateGroup.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCreateGroup.CheckedForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.CheckedImageTint = System.Drawing.Color.White;
            this.btnCreateGroup.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCreateGroup.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateGroup.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateGroup.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnCreateGroup.HoverForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.HoverImage = null;
            this.btnCreateGroup.HoverImageTint = System.Drawing.Color.White;
            this.btnCreateGroup.HoverOutline = System.Drawing.Color.Empty;
            this.btnCreateGroup.Image = null;
            this.btnCreateGroup.ImageAutoCenter = false;
            this.btnCreateGroup.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCreateGroup.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnCreateGroup.ImageTint = System.Drawing.Color.White;
            this.btnCreateGroup.IsToggleButton = false;
            this.btnCreateGroup.IsToggled = false;
            this.btnCreateGroup.Location = new System.Drawing.Point(34, 560);
            this.btnCreateGroup.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnCreateGroup.NormalForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.NormalOutline = System.Drawing.Color.Empty;
            this.btnCreateGroup.OutlineThickness = 2F;
            this.btnCreateGroup.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnCreateGroup.PressedForeColor = System.Drawing.Color.White;
            this.btnCreateGroup.PressedImageTint = System.Drawing.Color.White;
            this.btnCreateGroup.PressedOutline = System.Drawing.Color.Empty;
            this.btnCreateGroup.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCreateGroup.Size = new System.Drawing.Size(344, 35);
            this.btnCreateGroup.TabIndex = 23;
            this.btnCreateGroup.TextAutoCenter = true;
            this.btnCreateGroup.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Add members";
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
            // Action
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.Action.DefaultCellStyle = dataGridViewCellStyle2;
            this.Action.FillWeight = 75F;
            this.Action.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Action.Width = 50;
            // 
            // frmCreateNewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 611);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.dgViewUsers);
            this.Controls.Add(this.txtSearchUsername);
            this.Controls.Add(this.lblGroupDescriptionError);
            this.Controls.Add(this.lblGroupNameError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGroupDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.lblCurrentProjectGroup);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateNewGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentProjectGroup;
        private SATATextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SATATextBox txtGroupDescription;
        private System.Windows.Forms.Label lblGroupNameError;
        private System.Windows.Forms.Label lblGroupDescriptionError;
        private SATATextBox txtSearchUsername;
        private System.Windows.Forms.DataGridView dgViewUsers;
        private FrameworkTest.SATAButton btnCreateGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Action;
    }
}