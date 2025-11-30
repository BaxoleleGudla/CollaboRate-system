namespace CollaboRate
{
    partial class frmHome
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeading = new System.Windows.Forms.Label();
            this.lblProjectGroupName = new System.Windows.Forms.Label();
            this.tblPanelHome = new System.Windows.Forms.TableLayoutPanel();
            this.lblEvaluationsHeading = new System.Windows.Forms.Label();
            this.lblTasksHeading = new System.Windows.Forms.Label();
            this.lblMeetingsHeading = new System.Windows.Forms.Label();
            this.lblGroupMembersHeading = new System.Windows.Forms.Label();
            this.dgViewMembers = new System.Windows.Forms.DataGridView();
            this.dgViewMemberEvaluations = new System.Windows.Forms.DataGridView();
            this.dgViewTasks = new System.Windows.Forms.DataGridView();
            this.dgViewMeetings = new System.Windows.Forms.DataGridView();
            this.Meeting_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUpcomingMeetings = new System.Windows.Forms.Label();
            this.lblMemberEvaluations = new System.Windows.Forms.Label();
            this.lblUpcomingTasks = new System.Windows.Forms.Label();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveMember = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblPanelHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(80, 27);
            this.lblHeading.TabIndex = 16;
            this.lblHeading.Text = "Home";
            // 
            // lblProjectGroupName
            // 
            this.lblProjectGroupName.AutoSize = true;
            this.lblProjectGroupName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectGroupName.Location = new System.Drawing.Point(14, 96);
            this.lblProjectGroupName.Name = "lblProjectGroupName";
            this.lblProjectGroupName.Size = new System.Drawing.Size(171, 19);
            this.lblProjectGroupName.TabIndex = 17;
            this.lblProjectGroupName.Text = "Project group name";
            // 
            // tblPanelHome
            // 
            this.tblPanelHome.ColumnCount = 2;
            this.tblPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.Controls.Add(this.lblEvaluationsHeading, 1, 1);
            this.tblPanelHome.Controls.Add(this.lblTasksHeading, 0, 1);
            this.tblPanelHome.Controls.Add(this.lblMeetingsHeading, 1, 0);
            this.tblPanelHome.Controls.Add(this.lblGroupMembersHeading, 0, 0);
            this.tblPanelHome.Location = new System.Drawing.Point(18, 131);
            this.tblPanelHome.Name = "tblPanelHome";
            this.tblPanelHome.RowCount = 2;
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPanelHome.Size = new System.Drawing.Size(774, 467);
            this.tblPanelHome.TabIndex = 18;
            // 
            // lblEvaluationsHeading
            // 
            this.lblEvaluationsHeading.AutoSize = true;
            this.lblEvaluationsHeading.Location = new System.Drawing.Point(387, 233);
            this.lblEvaluationsHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvaluationsHeading.Name = "lblEvaluationsHeading";
            this.lblEvaluationsHeading.Size = new System.Drawing.Size(186, 21);
            this.lblEvaluationsHeading.TabIndex = 21;
            this.lblEvaluationsHeading.Text = "Member Evaluations:";
            // 
            // lblTasksHeading
            // 
            this.lblTasksHeading.AutoSize = true;
            this.lblTasksHeading.Location = new System.Drawing.Point(0, 233);
            this.lblTasksHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblTasksHeading.Name = "lblTasksHeading";
            this.lblTasksHeading.Size = new System.Drawing.Size(148, 21);
            this.lblTasksHeading.TabIndex = 20;
            this.lblTasksHeading.Text = "Upcoming Tasks:";
            // 
            // lblMeetingsHeading
            // 
            this.lblMeetingsHeading.AutoSize = true;
            this.lblMeetingsHeading.Location = new System.Drawing.Point(387, 0);
            this.lblMeetingsHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeetingsHeading.Name = "lblMeetingsHeading";
            this.lblMeetingsHeading.Size = new System.Drawing.Size(182, 21);
            this.lblMeetingsHeading.TabIndex = 20;
            this.lblMeetingsHeading.Text = "Upcoming Meetings:";
            // 
            // lblGroupMembersHeading
            // 
            this.lblGroupMembersHeading.AutoSize = true;
            this.lblGroupMembersHeading.Location = new System.Drawing.Point(0, 0);
            this.lblGroupMembersHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupMembersHeading.Name = "lblGroupMembersHeading";
            this.lblGroupMembersHeading.Size = new System.Drawing.Size(151, 21);
            this.lblGroupMembersHeading.TabIndex = 19;
            this.lblGroupMembersHeading.Text = "Group Members:";
            // 
            // dgViewMembers
            // 
            this.dgViewMembers.AllowUserToAddRows = false;
            this.dgViewMembers.AllowUserToDeleteRows = false;
            this.dgViewMembers.AllowUserToResizeColumns = false;
            this.dgViewMembers.AllowUserToResizeRows = false;
            this.dgViewMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgViewMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgViewMembers.ColumnHeadersHeight = 35;
            this.dgViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMembers.ColumnHeadersVisible = false;
            this.dgViewMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Username,
            this.User_Role,
            this.RemoveMember});
            this.dgViewMembers.EnableHeadersVisualStyles = false;
            this.dgViewMembers.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMembers.Location = new System.Drawing.Point(21, 162);
            this.dgViewMembers.Name = "dgViewMembers";
            this.dgViewMembers.ReadOnly = true;
            this.dgViewMembers.RowHeadersVisible = false;
            this.dgViewMembers.RowHeadersWidth = 51;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMembers.RowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgViewMembers.RowTemplate.DividerHeight = 5;
            this.dgViewMembers.RowTemplate.Height = 35;
            this.dgViewMembers.Size = new System.Drawing.Size(365, 180);
            this.dgViewMembers.TabIndex = 19;
            // 
            // dgViewMemberEvaluations
            // 
            this.dgViewMemberEvaluations.AllowUserToAddRows = false;
            this.dgViewMemberEvaluations.AllowUserToDeleteRows = false;
            this.dgViewMemberEvaluations.AllowUserToResizeColumns = false;
            this.dgViewMemberEvaluations.AllowUserToResizeRows = false;
            this.dgViewMemberEvaluations.BackgroundColor = System.Drawing.Color.White;
            this.dgViewMemberEvaluations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewMemberEvaluations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMemberEvaluations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgViewMemberEvaluations.ColumnHeadersHeight = 35;
            this.dgViewMemberEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMemberEvaluations.ColumnHeadersVisible = false;
            this.dgViewMemberEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.MemberAverage});
            this.dgViewMemberEvaluations.EnableHeadersVisualStyles = false;
            this.dgViewMemberEvaluations.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMemberEvaluations.Location = new System.Drawing.Point(408, 397);
            this.dgViewMemberEvaluations.Name = "dgViewMemberEvaluations";
            this.dgViewMemberEvaluations.ReadOnly = true;
            this.dgViewMemberEvaluations.RowHeadersVisible = false;
            this.dgViewMemberEvaluations.RowHeadersWidth = 51;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMemberEvaluations.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.dgViewMemberEvaluations.RowTemplate.DividerHeight = 5;
            this.dgViewMemberEvaluations.RowTemplate.Height = 35;
            this.dgViewMemberEvaluations.Size = new System.Drawing.Size(365, 180);
            this.dgViewMemberEvaluations.TabIndex = 21;
            // 
            // dgViewTasks
            // 
            this.dgViewTasks.AllowUserToAddRows = false;
            this.dgViewTasks.AllowUserToDeleteRows = false;
            this.dgViewTasks.AllowUserToResizeColumns = false;
            this.dgViewTasks.AllowUserToResizeRows = false;
            this.dgViewTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgViewTasks.ColumnHeadersHeight = 35;
            this.dgViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewTasks.ColumnHeadersVisible = false;
            this.dgViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task_ID,
            this.Task_Title,
            this.Deadline});
            this.dgViewTasks.EnableHeadersVisualStyles = false;
            this.dgViewTasks.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewTasks.Location = new System.Drawing.Point(22, 397);
            this.dgViewTasks.Name = "dgViewTasks";
            this.dgViewTasks.ReadOnly = true;
            this.dgViewTasks.RowHeadersVisible = false;
            this.dgViewTasks.RowHeadersWidth = 51;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewTasks.RowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dgViewTasks.RowTemplate.DividerHeight = 5;
            this.dgViewTasks.RowTemplate.Height = 35;
            this.dgViewTasks.Size = new System.Drawing.Size(365, 180);
            this.dgViewTasks.TabIndex = 22;
            // 
            // dgViewMeetings
            // 
            this.dgViewMeetings.AllowUserToAddRows = false;
            this.dgViewMeetings.AllowUserToDeleteRows = false;
            this.dgViewMeetings.AllowUserToResizeColumns = false;
            this.dgViewMeetings.AllowUserToResizeRows = false;
            this.dgViewMeetings.BackgroundColor = System.Drawing.Color.White;
            this.dgViewMeetings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewMeetings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMeetings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dgViewMeetings.ColumnHeadersHeight = 35;
            this.dgViewMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMeetings.ColumnHeadersVisible = false;
            this.dgViewMeetings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Meeting_ID,
            this.Meeting_Title,
            this.Meeting_Date});
            this.dgViewMeetings.EnableHeadersVisualStyles = false;
            this.dgViewMeetings.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMeetings.Location = new System.Drawing.Point(406, 162);
            this.dgViewMeetings.Name = "dgViewMeetings";
            this.dgViewMeetings.ReadOnly = true;
            this.dgViewMeetings.RowHeadersVisible = false;
            this.dgViewMeetings.RowHeadersWidth = 51;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMeetings.RowsDefaultCellStyle = dataGridViewCellStyle36;
            this.dgViewMeetings.RowTemplate.DividerHeight = 5;
            this.dgViewMeetings.RowTemplate.Height = 35;
            this.dgViewMeetings.Size = new System.Drawing.Size(365, 180);
            this.dgViewMeetings.TabIndex = 23;
            // 
            // Meeting_ID
            // 
            this.Meeting_ID.DataPropertyName = "Meeting_ID";
            this.Meeting_ID.HeaderText = "Meeting ID";
            this.Meeting_ID.MinimumWidth = 6;
            this.Meeting_ID.Name = "Meeting_ID";
            this.Meeting_ID.ReadOnly = true;
            this.Meeting_ID.Visible = false;
            this.Meeting_ID.Width = 125;
            // 
            // Meeting_Title
            // 
            this.Meeting_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Meeting_Title.DataPropertyName = "Meeting_Title";
            this.Meeting_Title.HeaderText = "Meeting Title";
            this.Meeting_Title.MinimumWidth = 6;
            this.Meeting_Title.Name = "Meeting_Title";
            this.Meeting_Title.ReadOnly = true;
            // 
            // Meeting_Date
            // 
            this.Meeting_Date.DataPropertyName = "Meeting_Date";
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.White;
            this.Meeting_Date.DefaultCellStyle = dataGridViewCellStyle35;
            this.Meeting_Date.HeaderText = "Meeting Date";
            this.Meeting_Date.MinimumWidth = 6;
            this.Meeting_Date.Name = "Meeting_Date";
            this.Meeting_Date.ReadOnly = true;
            this.Meeting_Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Meeting_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Meeting_Date.ToolTipText = "Meeting Date";
            this.Meeting_Date.Width = 114;
            // 
            // lblUpcomingMeetings
            // 
            this.lblUpcomingMeetings.AutoSize = true;
            this.lblUpcomingMeetings.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingMeetings.Location = new System.Drawing.Point(408, 164);
            this.lblUpcomingMeetings.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpcomingMeetings.Name = "lblUpcomingMeetings";
            this.lblUpcomingMeetings.Size = new System.Drawing.Size(190, 18);
            this.lblUpcomingMeetings.TabIndex = 24;
            this.lblUpcomingMeetings.Text = "(No upcoming meetings)";
            this.lblUpcomingMeetings.Visible = false;
            // 
            // lblMemberEvaluations
            // 
            this.lblMemberEvaluations.AutoSize = true;
            this.lblMemberEvaluations.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberEvaluations.Location = new System.Drawing.Point(408, 399);
            this.lblMemberEvaluations.Margin = new System.Windows.Forms.Padding(0);
            this.lblMemberEvaluations.Name = "lblMemberEvaluations";
            this.lblMemberEvaluations.Size = new System.Drawing.Size(194, 18);
            this.lblMemberEvaluations.TabIndex = 25;
            this.lblMemberEvaluations.Text = "(No member evaluations)";
            this.lblMemberEvaluations.Visible = false;
            // 
            // lblUpcomingTasks
            // 
            this.lblUpcomingTasks.AutoSize = true;
            this.lblUpcomingTasks.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingTasks.Location = new System.Drawing.Point(22, 399);
            this.lblUpcomingTasks.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpcomingTasks.Name = "lblUpcomingTasks";
            this.lblUpcomingTasks.Size = new System.Drawing.Size(157, 18);
            this.lblUpcomingTasks.TabIndex = 26;
            this.lblUpcomingTasks.Text = "(No upcoming tasks)";
            this.lblUpcomingTasks.Visible = false;
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(378, 345);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 52;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "User ID";
            this.User_ID.MinimumWidth = 6;
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Visible = false;
            this.User_ID.Width = 125;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // User_Role
            // 
            this.User_Role.DataPropertyName = "User_Role";
            this.User_Role.HeaderText = "Member Role";
            this.User_Role.MinimumWidth = 6;
            this.User_Role.Name = "User_Role";
            this.User_Role.ReadOnly = true;
            this.User_Role.Width = 125;
            // 
            // RemoveMember
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(45)))), ((int)(((byte)(0)))));
            this.RemoveMember.DefaultCellStyle = dataGridViewCellStyle26;
            this.RemoveMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveMember.HeaderText = "Remove";
            this.RemoveMember.MinimumWidth = 6;
            this.RemoveMember.Name = "RemoveMember";
            this.RemoveMember.ReadOnly = true;
            this.RemoveMember.Text = "Remove";
            this.RemoveMember.UseColumnTextForButtonValue = true;
            this.RemoveMember.Width = 114;
            // 
            // Task_ID
            // 
            this.Task_ID.DataPropertyName = "Task_ID";
            this.Task_ID.HeaderText = "Task_ID";
            this.Task_ID.MinimumWidth = 6;
            this.Task_ID.Name = "Task_ID";
            this.Task_ID.ReadOnly = true;
            this.Task_ID.Visible = false;
            this.Task_ID.Width = 125;
            // 
            // Task_Title
            // 
            this.Task_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Task_Title.DataPropertyName = "Task_Title";
            this.Task_Title.HeaderText = "Task Title";
            this.Task_Title.MinimumWidth = 6;
            this.Task_Title.Name = "Task_Title";
            this.Task_Title.ReadOnly = true;
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.White;
            this.Deadline.DefaultCellStyle = dataGridViewCellStyle32;
            this.Deadline.HeaderText = "Deadline";
            this.Deadline.MinimumWidth = 6;
            this.Deadline.Name = "Deadline";
            this.Deadline.ReadOnly = true;
            this.Deadline.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Deadline.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Deadline.ToolTipText = "Deadline";
            this.Deadline.Width = 114;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "User_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "User ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Username";
            this.dataGridViewTextBoxColumn2.HeaderText = "Username";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // MemberAverage
            // 
            this.MemberAverage.DataPropertyName = "Average_Score";
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.White;
            this.MemberAverage.DefaultCellStyle = dataGridViewCellStyle29;
            this.MemberAverage.HeaderText = "Average Contribution";
            this.MemberAverage.MinimumWidth = 6;
            this.MemberAverage.Name = "MemberAverage";
            this.MemberAverage.ReadOnly = true;
            this.MemberAverage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MemberAverage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MemberAverage.ToolTipText = "Average Contribution";
            this.MemberAverage.Width = 114;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.lblUpcomingTasks);
            this.Controls.Add(this.lblMemberEvaluations);
            this.Controls.Add(this.lblUpcomingMeetings);
            this.Controls.Add(this.dgViewMeetings);
            this.Controls.Add(this.dgViewTasks);
            this.Controls.Add(this.dgViewMemberEvaluations);
            this.Controls.Add(this.dgViewMembers);
            this.Controls.Add(this.tblPanelHome);
            this.Controls.Add(this.lblProjectGroupName);
            this.Controls.Add(this.lblHeading);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.tblPanelHome.ResumeLayout(false);
            this.tblPanelHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblProjectGroupName;
        private System.Windows.Forms.TableLayoutPanel tblPanelHome;
        private System.Windows.Forms.Label lblGroupMembersHeading;
        private System.Windows.Forms.Label lblEvaluationsHeading;
        private System.Windows.Forms.Label lblTasksHeading;
        private System.Windows.Forms.Label lblMeetingsHeading;
        private System.Windows.Forms.DataGridView dgViewMembers;
        private System.Windows.Forms.DataGridView dgViewMemberEvaluations;
        private System.Windows.Forms.DataGridView dgViewTasks;
        private System.Windows.Forms.DataGridView dgViewMeetings;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Date;
        private System.Windows.Forms.Label lblUpcomingMeetings;
        private System.Windows.Forms.Label lblMemberEvaluations;
        private System.Windows.Forms.Label lblUpcomingTasks;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Role;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberAverage;
    }
}