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
            SATAUiFramework.BorderRadius borderRadius2 = new SATAUiFramework.BorderRadius();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblCurrentProjectGroup = new System.Windows.Forms.Label();
            this.pnlCurrentGroup = new SATAUiFramework.SATAPanel();
            this.btnProjectGroups = new FrameworkTest.SATAButton();
            this.lblHeading = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.dgViewJoinRequests = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcceptRequest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.RejectRequest = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pbxGroupNameIcon = new System.Windows.Forms.PictureBox();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.lblGroupDescription = new System.Windows.Forms.Label();
            this.btnEditGroup = new FrameworkTest.SATAButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNumOfMembers = new System.Windows.Forms.Label();
            this.pbxNumOfMembers = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.pnlCurrentGroup.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewJoinRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGroupNameIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNumOfMembers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblCurrentProjectGroup);
            this.pnlTop.Controls.Add(this.pnlCurrentGroup);
            this.pnlTop.Controls.Add(this.btnProjectGroups);
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
            this.lblCurrentProjectGroup.Size = new System.Drawing.Size(153, 17);
            this.lblCurrentProjectGroup.TabIndex = 11;
            this.lblCurrentProjectGroup.Text = "Current Project Group";
            // 
            // pnlCurrentGroup
            // 
            this.pnlCurrentGroup.BackColor = System.Drawing.Color.White;
            this.pnlCurrentGroup.BackColor2 = System.Drawing.Color.White;
            this.pnlCurrentGroup.BorderColor = System.Drawing.Color.LightGray;
            borderRadius2.BottomLeft = 5;
            borderRadius2.BottomRight = 5;
            borderRadius2.TopLeft = 5;
            borderRadius2.TopRight = 5;
            this.pnlCurrentGroup.BorderRadius = borderRadius2;
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
            // btnProjectGroups
            // 
            this.btnProjectGroups.ButtonText = "Project Groups";
            this.btnProjectGroups.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnProjectGroups.CheckedForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.CheckedImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnProjectGroups.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProjectGroups.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjectGroups.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnProjectGroups.HoverForeColor = System.Drawing.Color.White;
            this.btnProjectGroups.HoverImage = null;
            this.btnProjectGroups.HoverImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.HoverOutline = System.Drawing.Color.Empty;
            this.btnProjectGroups.Image = global::CollaboRate.Properties.Resources.home;
            this.btnProjectGroups.ImageAutoCenter = false;
            this.btnProjectGroups.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnProjectGroups.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnProjectGroups.ImageTint = System.Drawing.Color.White;
            this.btnProjectGroups.IsToggleButton = false;
            this.btnProjectGroups.IsToggled = false;
            this.btnProjectGroups.Location = new System.Drawing.Point(557, 27);
            this.btnProjectGroups.Margin = new System.Windows.Forms.Padding(5);
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
            this.btnProjectGroups.TabIndex = 9;
            this.btnProjectGroups.TextAutoCenter = false;
            this.btnProjectGroups.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(238, 23);
            this.lblHeading.TabIndex = 8;
            this.lblHeading.Text = "Project Group Managent";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.dgViewJoinRequests);
            this.pnlMiddle.Controls.Add(this.label1);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 283);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(810, 119);
            this.pnlMiddle.TabIndex = 1;
            // 
            // dgViewJoinRequests
            // 
            this.dgViewJoinRequests.AllowUserToDeleteRows = false;
            this.dgViewJoinRequests.AllowUserToResizeColumns = false;
            this.dgViewJoinRequests.AllowUserToResizeRows = false;
            this.dgViewJoinRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewJoinRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgViewJoinRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewJoinRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgViewJoinRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewJoinRequests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewJoinRequests.ColumnHeadersHeight = 29;
            this.dgViewJoinRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewJoinRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Description,
            this.AcceptRequest,
            this.RejectRequest});
            this.dgViewJoinRequests.EnableHeadersVisualStyles = false;
            this.dgViewJoinRequests.GridColor = System.Drawing.Color.White;
            this.dgViewJoinRequests.Location = new System.Drawing.Point(19, 22);
            this.dgViewJoinRequests.Margin = new System.Windows.Forms.Padding(0);
            this.dgViewJoinRequests.MultiSelect = false;
            this.dgViewJoinRequests.Name = "dgViewJoinRequests";
            this.dgViewJoinRequests.ReadOnly = true;
            this.dgViewJoinRequests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewJoinRequests.RowHeadersVisible = false;
            this.dgViewJoinRequests.RowHeadersWidth = 50;
            this.dgViewJoinRequests.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgViewJoinRequests.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgViewJoinRequests.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgViewJoinRequests.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgViewJoinRequests.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.dgViewJoinRequests.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewJoinRequests.RowTemplate.Height = 24;
            this.dgViewJoinRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewJoinRequests.Size = new System.Drawing.Size(773, 97);
            this.dgViewJoinRequests.TabIndex = 13;
            // 
            // Id
            // 
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 40;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.FillWeight = 110F;
            this.Description.HeaderText = "Username";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // AcceptRequest
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            this.AcceptRequest.DefaultCellStyle = dataGridViewCellStyle5;
            this.AcceptRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AcceptRequest.HeaderText = "Accept";
            this.AcceptRequest.MinimumWidth = 6;
            this.AcceptRequest.Name = "AcceptRequest";
            this.AcceptRequest.ReadOnly = true;
            this.AcceptRequest.Text = "Accept";
            this.AcceptRequest.UseColumnTextForButtonValue = true;
            this.AcceptRequest.Width = 125;
            // 
            // RejectRequest
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.RejectRequest.DefaultCellStyle = dataGridViewCellStyle6;
            this.RejectRequest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RejectRequest.HeaderText = "Reject";
            this.RejectRequest.MinimumWidth = 6;
            this.RejectRequest.Name = "RejectRequest";
            this.RejectRequest.ReadOnly = true;
            this.RejectRequest.Text = "Reject";
            this.RejectRequest.UseColumnTextForButtonValue = true;
            this.RejectRequest.Width = 125;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 402);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(810, 225);
            this.pnlBottom.TabIndex = 2;
            // 
            // pbxGroupNameIcon
            // 
            this.pbxGroupNameIcon.Location = new System.Drawing.Point(13, 9);
            this.pbxGroupNameIcon.Name = "pbxGroupNameIcon";
            this.pbxGroupNameIcon.Size = new System.Drawing.Size(20, 20);
            this.pbxGroupNameIcon.TabIndex = 0;
            this.pbxGroupNameIcon.TabStop = false;
            // 
            // lblGroupName
            // 
            this.lblGroupName.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.Location = new System.Drawing.Point(37, 12);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(721, 20);
            this.lblGroupName.TabIndex = 1;
            this.lblGroupName.Text = "Group Name";
            // 
            // lblGroupDescription
            // 
            this.lblGroupDescription.AutoSize = true;
            this.lblGroupDescription.Location = new System.Drawing.Point(10, 38);
            this.lblGroupDescription.Name = "lblGroupDescription";
            this.lblGroupDescription.Size = new System.Drawing.Size(133, 19);
            this.lblGroupDescription.TabIndex = 2;
            this.lblGroupDescription.Text = "Group Description";
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.ButtonText = "Edit Group";
            this.btnEditGroup.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnEditGroup.CheckedForeColor = System.Drawing.Color.White;
            this.btnEditGroup.CheckedImageTint = System.Drawing.Color.White;
            this.btnEditGroup.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnEditGroup.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnEditGroup.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroup.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(106)))), ((int)(((byte)(0)))));
            this.btnEditGroup.HoverForeColor = System.Drawing.Color.White;
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
            this.btnEditGroup.Location = new System.Drawing.Point(2, 120);
            this.btnEditGroup.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.NormalBackground = System.Drawing.Color.White;
            this.btnEditGroup.NormalForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnEditGroup.NormalOutline = System.Drawing.Color.Empty;
            this.btnEditGroup.OutlineThickness = 2F;
            this.btnEditGroup.PressedBackground = System.Drawing.Color.RoyalBlue;
            this.btnEditGroup.PressedForeColor = System.Drawing.Color.White;
            this.btnEditGroup.PressedImageTint = System.Drawing.Color.White;
            this.btnEditGroup.PressedOutline = System.Drawing.Color.Empty;
            this.btnEditGroup.Rounding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnEditGroup.Size = new System.Drawing.Size(770, 29);
            this.btnEditGroup.TabIndex = 3;
            this.btnEditGroup.TextAutoCenter = true;
            this.btnEditGroup.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 1);
            this.panel1.TabIndex = 4;
            // 
            // lblNumOfMembers
            // 
            this.lblNumOfMembers.AutoSize = true;
            this.lblNumOfMembers.Location = new System.Drawing.Point(36, 91);
            this.lblNumOfMembers.Name = "lblNumOfMembers";
            this.lblNumOfMembers.Size = new System.Drawing.Size(148, 19);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Pending Membership Requests";
            // 
            // frmProjectGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
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
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewJoinRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGroupNameIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNumOfMembers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblCurrentProjectGroup;
        private SATAUiFramework.SATAPanel pnlCurrentGroup;
        private FrameworkTest.SATAButton btnProjectGroups;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBottom;
        public System.Windows.Forms.DataGridView dgViewJoinRequests;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewButtonColumn AcceptRequest;
        private System.Windows.Forms.DataGridViewButtonColumn RejectRequest;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.PictureBox pbxGroupNameIcon;
        private System.Windows.Forms.Label lblGroupDescription;
        private FrameworkTest.SATAButton btnEditGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNumOfMembers;
        private System.Windows.Forms.PictureBox pbxNumOfMembers;
        private System.Windows.Forms.Label label1;
    }
}