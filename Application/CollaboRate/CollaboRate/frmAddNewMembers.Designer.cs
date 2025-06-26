namespace CollaboRate
{
    partial class frmAddNewMembers
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddMembers = new FrameworkTest.SATAButton();
            this.dgViewUsers = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtSearchUsername = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnBack = new FrameworkTest.SATAButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "Users:";
            // 
            // btnAddMembers
            // 
            this.btnAddMembers.ButtonText = "Add Members";
            this.btnAddMembers.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnAddMembers.CheckedForeColor = System.Drawing.Color.White;
            this.btnAddMembers.CheckedImageTint = System.Drawing.Color.White;
            this.btnAddMembers.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnAddMembers.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddMembers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMembers.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnAddMembers.HoverForeColor = System.Drawing.Color.White;
            this.btnAddMembers.HoverImage = null;
            this.btnAddMembers.HoverImageTint = System.Drawing.Color.White;
            this.btnAddMembers.HoverOutline = System.Drawing.Color.Empty;
            this.btnAddMembers.Image = null;
            this.btnAddMembers.ImageAutoCenter = false;
            this.btnAddMembers.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnAddMembers.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnAddMembers.ImageTint = System.Drawing.Color.White;
            this.btnAddMembers.IsToggleButton = false;
            this.btnAddMembers.IsToggled = false;
            this.btnAddMembers.Location = new System.Drawing.Point(34, 560);
            this.btnAddMembers.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAddMembers.Name = "btnAddMembers";
            this.btnAddMembers.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnAddMembers.NormalForeColor = System.Drawing.Color.White;
            this.btnAddMembers.NormalOutline = System.Drawing.Color.Empty;
            this.btnAddMembers.OutlineThickness = 2F;
            this.btnAddMembers.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnAddMembers.PressedForeColor = System.Drawing.Color.White;
            this.btnAddMembers.PressedImageTint = System.Drawing.Color.White;
            this.btnAddMembers.PressedOutline = System.Drawing.Color.Empty;
            this.btnAddMembers.Rounding = new System.Windows.Forms.Padding(5);
            this.btnAddMembers.Size = new System.Drawing.Size(344, 35);
            this.btnAddMembers.TabIndex = 34;
            this.btnAddMembers.TextAutoCenter = true;
            this.btnAddMembers.TextOffset = new System.Drawing.Point(0, 0);
            this.btnAddMembers.Click += new System.EventHandler(this.btnAddMembers_Click);
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
            this.dgViewUsers.Location = new System.Drawing.Point(34, 135);
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
            this.dgViewUsers.Size = new System.Drawing.Size(344, 386);
            this.dgViewUsers.TabIndex = 33;
            this.dgViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewUsers_CellClick);
            this.dgViewUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewUsers_CellContentClick);
            this.dgViewUsers.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgViewUsers_CurrentCellDirtyStateChanged);
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
            // txtSearchUsername
            // 
            this.txtSearchUsername.BackColor = System.Drawing.Color.White;
            this.txtSearchUsername.BorderColor = System.Drawing.Color.DimGray;
            this.txtSearchUsername.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtSearchUsername.BorderRadius = 5;
            this.txtSearchUsername.BorderSize = 1;
            this.txtSearchUsername.Icon = null;
            this.txtSearchUsername.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchUsername.Location = new System.Drawing.Point(34, 59);
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
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(109, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(198, 23);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Add New Members";
            // 
            // btnBack
            // 
            this.btnBack.ButtonText = "";
            this.btnBack.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnBack.CheckedForeColor = System.Drawing.Color.White;
            this.btnBack.CheckedImageTint = System.Drawing.Color.White;
            this.btnBack.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnBack.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnBack.HoverForeColor = System.Drawing.Color.White;
            this.btnBack.HoverImage = null;
            this.btnBack.HoverImageTint = System.Drawing.Color.White;
            this.btnBack.HoverOutline = System.Drawing.Color.Empty;
            this.btnBack.Image = null;
            this.btnBack.ImageAutoCenter = false;
            this.btnBack.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnBack.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnBack.ImageTint = System.Drawing.Color.White;
            this.btnBack.IsToggleButton = false;
            this.btnBack.IsToggled = false;
            this.btnBack.Location = new System.Drawing.Point(5, 3);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnBack.NormalForeColor = System.Drawing.Color.White;
            this.btnBack.NormalOutline = System.Drawing.Color.Empty;
            this.btnBack.OutlineThickness = 2F;
            this.btnBack.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnBack.PressedForeColor = System.Drawing.Color.White;
            this.btnBack.PressedImageTint = System.Drawing.Color.White;
            this.btnBack.PressedOutline = System.Drawing.Color.Empty;
            this.btnBack.Rounding = new System.Windows.Forms.Padding(5);
            this.btnBack.Size = new System.Drawing.Size(38, 23);
            this.btnBack.TabIndex = 36;
            this.btnBack.TextAutoCenter = true;
            this.btnBack.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // frmAddNewMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 611);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddMembers);
            this.Controls.Add(this.dgViewUsers);
            this.Controls.Add(this.txtSearchUsername);
            this.Controls.Add(this.lblHeading);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAddNewMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private FrameworkTest.SATAButton btnAddMembers;
        private System.Windows.Forms.DataGridView dgViewUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Action;
        private SATATextBox txtSearchUsername;
        private System.Windows.Forms.Label lblHeading;
        private FrameworkTest.SATAButton btnBack;
    }
}