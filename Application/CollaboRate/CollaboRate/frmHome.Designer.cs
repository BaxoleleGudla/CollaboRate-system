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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblPanelHome = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTasks = new System.Windows.Forms.Panel();
            this.lblUpcomingTasks = new System.Windows.Forms.Label();
            this.dgViewTasks = new System.Windows.Forms.DataGridView();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTasksHeading = new System.Windows.Forms.Label();
            this.pnlGroupMembers = new System.Windows.Forms.Panel();
            this.dgViewMembers = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemoveMember = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblGroupMembersHeading = new System.Windows.Forms.Label();
            this.pnlUpcomingMeetings = new System.Windows.Forms.Panel();
            this.lblUpcomingMeetings = new System.Windows.Forms.Label();
            this.dgViewMeetings = new System.Windows.Forms.DataGridView();
            this.Meeting_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMeetingsHeading = new System.Windows.Forms.Label();
            this.pnlMemberEvaluations = new System.Windows.Forms.Panel();
            this.lblMemberEvaluations = new System.Windows.Forms.Label();
            this.dgViewMemberEvaluations = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemberAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEvaluationsHeading = new System.Windows.Forms.Label();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblProjectGroupName = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.tblPanelHome.SuspendLayout();
            this.pnlTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).BeginInit();
            this.pnlGroupMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMembers)).BeginInit();
            this.pnlUpcomingMeetings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).BeginInit();
            this.pnlMemberEvaluations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblPanelHome
            // 
            this.tblPanelHome.ColumnCount = 2;
            this.tblPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.Controls.Add(this.pnlTasks, 0, 1);
            this.tblPanelHome.Controls.Add(this.pnlGroupMembers, 0, 0);
            this.tblPanelHome.Controls.Add(this.pnlUpcomingMeetings, 1, 0);
            this.tblPanelHome.Controls.Add(this.pnlMemberEvaluations, 1, 1);
            this.tblPanelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblPanelHome.Location = new System.Drawing.Point(0, 105);
            this.tblPanelHome.Name = "tblPanelHome";
            this.tblPanelHome.Padding = new System.Windows.Forms.Padding(6, 6, 6, 8);
            this.tblPanelHome.RowCount = 2;
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPanelHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblPanelHome.Size = new System.Drawing.Size(810, 522);
            this.tblPanelHome.TabIndex = 18;
            // 
            // pnlTasks
            // 
            this.pnlTasks.Controls.Add(this.lblUpcomingTasks);
            this.pnlTasks.Controls.Add(this.dgViewTasks);
            this.pnlTasks.Controls.Add(this.lblTasksHeading);
            this.pnlTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTasks.Location = new System.Drawing.Point(9, 263);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(393, 248);
            this.pnlTasks.TabIndex = 61;
            // 
            // lblUpcomingTasks
            // 
            this.lblUpcomingTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpcomingTasks.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingTasks.Location = new System.Drawing.Point(0, 21);
            this.lblUpcomingTasks.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpcomingTasks.Name = "lblUpcomingTasks";
            this.lblUpcomingTasks.Size = new System.Drawing.Size(393, 227);
            this.lblUpcomingTasks.TabIndex = 28;
            this.lblUpcomingTasks.Text = "(No upcoming tasks)";
            this.lblUpcomingTasks.Visible = false;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewTasks.ColumnHeadersHeight = 35;
            this.dgViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewTasks.ColumnHeadersVisible = false;
            this.dgViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task_ID,
            this.Task_Title,
            this.Deadline});
            this.dgViewTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewTasks.EnableHeadersVisualStyles = false;
            this.dgViewTasks.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewTasks.Location = new System.Drawing.Point(0, 21);
            this.dgViewTasks.Name = "dgViewTasks";
            this.dgViewTasks.ReadOnly = true;
            this.dgViewTasks.RowHeadersVisible = false;
            this.dgViewTasks.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewTasks.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewTasks.RowTemplate.DividerHeight = 5;
            this.dgViewTasks.RowTemplate.Height = 35;
            this.dgViewTasks.Size = new System.Drawing.Size(393, 227);
            this.dgViewTasks.TabIndex = 22;
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
            this.Task_Title.FillWeight = 300F;
            this.Task_Title.HeaderText = "Task Title";
            this.Task_Title.MinimumWidth = 6;
            this.Task_Title.Name = "Task_Title";
            this.Task_Title.ReadOnly = true;
            // 
            // Deadline
            // 
            this.Deadline.DataPropertyName = "Deadline";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            this.Deadline.DefaultCellStyle = dataGridViewCellStyle2;
            this.Deadline.HeaderText = "Deadline";
            this.Deadline.MinimumWidth = 6;
            this.Deadline.Name = "Deadline";
            this.Deadline.ReadOnly = true;
            this.Deadline.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Deadline.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Deadline.ToolTipText = "Deadline";
            this.Deadline.Width = 114;
            // 
            // lblTasksHeading
            // 
            this.lblTasksHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTasksHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasksHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblTasksHeading.Location = new System.Drawing.Point(0, 0);
            this.lblTasksHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblTasksHeading.Name = "lblTasksHeading";
            this.lblTasksHeading.Size = new System.Drawing.Size(393, 21);
            this.lblTasksHeading.TabIndex = 20;
            this.lblTasksHeading.Text = "Upcoming Tasks:";
            // 
            // pnlGroupMembers
            // 
            this.pnlGroupMembers.BackColor = System.Drawing.Color.White;
            this.pnlGroupMembers.Controls.Add(this.dgViewMembers);
            this.pnlGroupMembers.Controls.Add(this.lblGroupMembersHeading);
            this.pnlGroupMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupMembers.Location = new System.Drawing.Point(9, 9);
            this.pnlGroupMembers.Name = "pnlGroupMembers";
            this.pnlGroupMembers.Size = new System.Drawing.Size(393, 248);
            this.pnlGroupMembers.TabIndex = 59;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgViewMembers.ColumnHeadersHeight = 35;
            this.dgViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMembers.ColumnHeadersVisible = false;
            this.dgViewMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Username,
            this.User_Role,
            this.RemoveMember});
            this.dgViewMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewMembers.EnableHeadersVisualStyles = false;
            this.dgViewMembers.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMembers.Location = new System.Drawing.Point(0, 21);
            this.dgViewMembers.Name = "dgViewMembers";
            this.dgViewMembers.ReadOnly = true;
            this.dgViewMembers.RowHeadersVisible = false;
            this.dgViewMembers.RowHeadersWidth = 51;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMembers.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgViewMembers.RowTemplate.DividerHeight = 5;
            this.dgViewMembers.RowTemplate.Height = 35;
            this.dgViewMembers.Size = new System.Drawing.Size(393, 227);
            this.dgViewMembers.TabIndex = 19;
            this.dgViewMembers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewMembers_CellContentClick);
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
            this.Username.FillWeight = 300F;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(45)))), ((int)(((byte)(0)))));
            this.RemoveMember.DefaultCellStyle = dataGridViewCellStyle5;
            this.RemoveMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveMember.HeaderText = "Remove";
            this.RemoveMember.MinimumWidth = 6;
            this.RemoveMember.Name = "RemoveMember";
            this.RemoveMember.ReadOnly = true;
            this.RemoveMember.Text = "Remove";
            this.RemoveMember.UseColumnTextForButtonValue = true;
            this.RemoveMember.Visible = false;
            this.RemoveMember.Width = 114;
            // 
            // lblGroupMembersHeading
            // 
            this.lblGroupMembersHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGroupMembersHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupMembersHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblGroupMembersHeading.Location = new System.Drawing.Point(0, 0);
            this.lblGroupMembersHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupMembersHeading.Name = "lblGroupMembersHeading";
            this.lblGroupMembersHeading.Size = new System.Drawing.Size(393, 21);
            this.lblGroupMembersHeading.TabIndex = 58;
            this.lblGroupMembersHeading.Text = "Group Members:";
            // 
            // pnlUpcomingMeetings
            // 
            this.pnlUpcomingMeetings.Controls.Add(this.lblUpcomingMeetings);
            this.pnlUpcomingMeetings.Controls.Add(this.dgViewMeetings);
            this.pnlUpcomingMeetings.Controls.Add(this.lblMeetingsHeading);
            this.pnlUpcomingMeetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpcomingMeetings.Location = new System.Drawing.Point(408, 9);
            this.pnlUpcomingMeetings.Name = "pnlUpcomingMeetings";
            this.pnlUpcomingMeetings.Size = new System.Drawing.Size(393, 248);
            this.pnlUpcomingMeetings.TabIndex = 60;
            // 
            // lblUpcomingMeetings
            // 
            this.lblUpcomingMeetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpcomingMeetings.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingMeetings.Location = new System.Drawing.Point(0, 21);
            this.lblUpcomingMeetings.Margin = new System.Windows.Forms.Padding(0);
            this.lblUpcomingMeetings.Name = "lblUpcomingMeetings";
            this.lblUpcomingMeetings.Size = new System.Drawing.Size(393, 227);
            this.lblUpcomingMeetings.TabIndex = 25;
            this.lblUpcomingMeetings.Text = "(No upcoming meetings)";
            this.lblUpcomingMeetings.Visible = false;
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMeetings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgViewMeetings.ColumnHeadersHeight = 35;
            this.dgViewMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMeetings.ColumnHeadersVisible = false;
            this.dgViewMeetings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Meeting_ID,
            this.Meeting_Title,
            this.Meeting_Date});
            this.dgViewMeetings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewMeetings.EnableHeadersVisualStyles = false;
            this.dgViewMeetings.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMeetings.Location = new System.Drawing.Point(0, 21);
            this.dgViewMeetings.Name = "dgViewMeetings";
            this.dgViewMeetings.ReadOnly = true;
            this.dgViewMeetings.RowHeadersVisible = false;
            this.dgViewMeetings.RowHeadersWidth = 51;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMeetings.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgViewMeetings.RowTemplate.DividerHeight = 5;
            this.dgViewMeetings.RowTemplate.Height = 35;
            this.dgViewMeetings.Size = new System.Drawing.Size(393, 227);
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
            this.Meeting_Title.FillWeight = 300F;
            this.Meeting_Title.HeaderText = "Meeting Title";
            this.Meeting_Title.MinimumWidth = 6;
            this.Meeting_Title.Name = "Meeting_Title";
            this.Meeting_Title.ReadOnly = true;
            // 
            // Meeting_Date
            // 
            this.Meeting_Date.DataPropertyName = "Meeting_Date";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            this.Meeting_Date.DefaultCellStyle = dataGridViewCellStyle8;
            this.Meeting_Date.HeaderText = "Meeting Date";
            this.Meeting_Date.MinimumWidth = 6;
            this.Meeting_Date.Name = "Meeting_Date";
            this.Meeting_Date.ReadOnly = true;
            this.Meeting_Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Meeting_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Meeting_Date.ToolTipText = "Meeting Date";
            this.Meeting_Date.Width = 114;
            // 
            // lblMeetingsHeading
            // 
            this.lblMeetingsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMeetingsHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingsHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblMeetingsHeading.Location = new System.Drawing.Point(0, 0);
            this.lblMeetingsHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeetingsHeading.Name = "lblMeetingsHeading";
            this.lblMeetingsHeading.Size = new System.Drawing.Size(393, 21);
            this.lblMeetingsHeading.TabIndex = 20;
            this.lblMeetingsHeading.Text = "Upcoming Meetings:";
            // 
            // pnlMemberEvaluations
            // 
            this.pnlMemberEvaluations.Controls.Add(this.lblMemberEvaluations);
            this.pnlMemberEvaluations.Controls.Add(this.dgViewMemberEvaluations);
            this.pnlMemberEvaluations.Controls.Add(this.lblEvaluationsHeading);
            this.pnlMemberEvaluations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberEvaluations.Location = new System.Drawing.Point(408, 263);
            this.pnlMemberEvaluations.Name = "pnlMemberEvaluations";
            this.pnlMemberEvaluations.Size = new System.Drawing.Size(393, 248);
            this.pnlMemberEvaluations.TabIndex = 62;
            // 
            // lblMemberEvaluations
            // 
            this.lblMemberEvaluations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMemberEvaluations.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberEvaluations.Location = new System.Drawing.Point(0, 21);
            this.lblMemberEvaluations.Margin = new System.Windows.Forms.Padding(0);
            this.lblMemberEvaluations.Name = "lblMemberEvaluations";
            this.lblMemberEvaluations.Size = new System.Drawing.Size(393, 227);
            this.lblMemberEvaluations.TabIndex = 26;
            this.lblMemberEvaluations.Text = "(No member evaluations)";
            this.lblMemberEvaluations.Visible = false;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMemberEvaluations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgViewMemberEvaluations.ColumnHeadersHeight = 35;
            this.dgViewMemberEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMemberEvaluations.ColumnHeadersVisible = false;
            this.dgViewMemberEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.MemberAverage});
            this.dgViewMemberEvaluations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewMemberEvaluations.EnableHeadersVisualStyles = false;
            this.dgViewMemberEvaluations.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMemberEvaluations.Location = new System.Drawing.Point(0, 21);
            this.dgViewMemberEvaluations.Name = "dgViewMemberEvaluations";
            this.dgViewMemberEvaluations.ReadOnly = true;
            this.dgViewMemberEvaluations.RowHeadersVisible = false;
            this.dgViewMemberEvaluations.RowHeadersWidth = 51;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMemberEvaluations.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgViewMemberEvaluations.RowTemplate.DividerHeight = 5;
            this.dgViewMemberEvaluations.RowTemplate.Height = 35;
            this.dgViewMemberEvaluations.Size = new System.Drawing.Size(393, 227);
            this.dgViewMemberEvaluations.TabIndex = 22;
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
            this.dataGridViewTextBoxColumn2.FillWeight = 300F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Username";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // MemberAverage
            // 
            this.MemberAverage.DataPropertyName = "Average_Score";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            this.MemberAverage.DefaultCellStyle = dataGridViewCellStyle11;
            this.MemberAverage.HeaderText = "Average Contribution";
            this.MemberAverage.MinimumWidth = 6;
            this.MemberAverage.Name = "MemberAverage";
            this.MemberAverage.ReadOnly = true;
            this.MemberAverage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MemberAverage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MemberAverage.ToolTipText = "Average Contribution";
            this.MemberAverage.Width = 114;
            // 
            // lblEvaluationsHeading
            // 
            this.lblEvaluationsHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEvaluationsHeading.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvaluationsHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.lblEvaluationsHeading.Location = new System.Drawing.Point(0, 0);
            this.lblEvaluationsHeading.Margin = new System.Windows.Forms.Padding(0);
            this.lblEvaluationsHeading.Name = "lblEvaluationsHeading";
            this.lblEvaluationsHeading.Size = new System.Drawing.Size(393, 21);
            this.lblEvaluationsHeading.TabIndex = 21;
            this.lblEvaluationsHeading.Text = "Member Evaluations:";
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(388, 357);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 52;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.lblProjectGroupName);
            this.pnlTop.Controls.Add(this.lblHeading);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(810, 105);
            this.pnlTop.TabIndex = 54;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 56;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblProjectGroupName
            // 
            this.lblProjectGroupName.AutoSize = true;
            this.lblProjectGroupName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectGroupName.Location = new System.Drawing.Point(11, 82);
            this.lblProjectGroupName.Name = "lblProjectGroupName";
            this.lblProjectGroupName.Size = new System.Drawing.Size(171, 19);
            this.lblProjectGroupName.TabIndex = 55;
            this.lblProjectGroupName.Text = "Project group name";
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(80, 27);
            this.lblHeading.TabIndex = 54;
            this.lblHeading.Text = "Home";
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.tblPanelHome);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmHome";
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.tblPanelHome.ResumeLayout(false);
            this.pnlTasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).EndInit();
            this.pnlGroupMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMembers)).EndInit();
            this.pnlUpcomingMeetings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).EndInit();
            this.pnlMemberEvaluations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tblPanelHome;
        private System.Windows.Forms.Label lblEvaluationsHeading;
        private System.Windows.Forms.Label lblTasksHeading;
        private System.Windows.Forms.Label lblMeetingsHeading;
        private System.Windows.Forms.DataGridView dgViewMembers;
        private System.Windows.Forms.DataGridView dgViewTasks;
        private System.Windows.Forms.DataGridView dgViewMeetings;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblProjectGroupName;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label lblGroupMembersHeading;
        private System.Windows.Forms.Panel pnlGroupMembers;
        private System.Windows.Forms.Panel pnlUpcomingMeetings;
        private System.Windows.Forms.Panel pnlTasks;
        public System.Windows.Forms.Label lblUpcomingMeetings;
        private System.Windows.Forms.Panel pnlMemberEvaluations;
        private System.Windows.Forms.DataGridView dgViewMemberEvaluations;
        public System.Windows.Forms.Label lblUpcomingTasks;
        public System.Windows.Forms.Label lblMemberEvaluations;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Role;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberAverage;
    }
}