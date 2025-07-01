namespace CollaboRate
{
    partial class frmCreateUpdateTask
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
            this.dgViewUsers = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblTaskDescriptionError = new System.Windows.Forms.Label();
            this.lblTaskTitleError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaskDescription = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTaskTitle = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateUpdateTask = new FrameworkTest.SATAButton();
            this.ckbTaskCompleted = new System.Windows.Forms.CheckBox();
            this.lblTaskDeadlineError = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTaskDeadline = new SATAUiFramework.Controls.SATADateTimePicker();
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
            this.dgViewUsers.Location = new System.Drawing.Point(34, 374);
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
            this.dgViewUsers.Size = new System.Drawing.Size(379, 150);
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
            // lblTaskDescriptionError
            // 
            this.lblTaskDescriptionError.AutoSize = true;
            this.lblTaskDescriptionError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblTaskDescriptionError.Location = new System.Drawing.Point(33, 261);
            this.lblTaskDescriptionError.Name = "lblTaskDescriptionError";
            this.lblTaskDescriptionError.Size = new System.Drawing.Size(35, 16);
            this.lblTaskDescriptionError.TabIndex = 31;
            this.lblTaskDescriptionError.Text = "Error";
            this.lblTaskDescriptionError.Visible = false;
            // 
            // lblTaskTitleError
            // 
            this.lblTaskTitleError.AutoSize = true;
            this.lblTaskTitleError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskTitleError.ForeColor = System.Drawing.Color.Red;
            this.lblTaskTitleError.Location = new System.Drawing.Point(34, 120);
            this.lblTaskTitleError.Name = "lblTaskTitleError";
            this.lblTaskTitleError.Size = new System.Drawing.Size(35, 16);
            this.lblTaskTitleError.TabIndex = 30;
            this.lblTaskTitleError.Text = "Error";
            this.lblTaskTitleError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Task Description";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.BackColor = System.Drawing.Color.White;
            this.txtTaskDescription.BorderColor = System.Drawing.Color.DimGray;
            this.txtTaskDescription.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtTaskDescription.BorderRadius = 5;
            this.txtTaskDescription.BorderSize = 1;
            this.txtTaskDescription.Icon = null;
            this.txtTaskDescription.IconSize = new System.Drawing.Size(20, 20);
            this.txtTaskDescription.Location = new System.Drawing.Point(34, 164);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.PasswordChar = false;
            this.txtTaskDescription.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTaskDescription.PlaceholderText = "Enter task description";
            this.txtTaskDescription.Size = new System.Drawing.Size(379, 94);
            this.txtTaskDescription.TabIndex = 28;
            this.txtTaskDescription.Texts = "";
            this.txtTaskDescription.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Task Title";
            // 
            // txtTaskTitle
            // 
            this.txtTaskTitle.BackColor = System.Drawing.Color.White;
            this.txtTaskTitle.BorderColor = System.Drawing.Color.DimGray;
            this.txtTaskTitle.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtTaskTitle.BorderRadius = 5;
            this.txtTaskTitle.BorderSize = 1;
            this.txtTaskTitle.Icon = null;
            this.txtTaskTitle.IconSize = new System.Drawing.Size(20, 20);
            this.txtTaskTitle.Location = new System.Drawing.Point(35, 79);
            this.txtTaskTitle.Multiline = false;
            this.txtTaskTitle.Name = "txtTaskTitle";
            this.txtTaskTitle.PasswordChar = false;
            this.txtTaskTitle.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtTaskTitle.PlaceholderText = "Enter task title";
            this.txtTaskTitle.Size = new System.Drawing.Size(378, 39);
            this.txtTaskTitle.TabIndex = 26;
            this.txtTaskTitle.Texts = "";
            this.txtTaskTitle.UnderlinedStyle = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(146, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(175, 23);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Create New Task";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "Assigned To:";
            // 
            // btnCreateUpdateTask
            // 
            this.btnCreateUpdateTask.ButtonText = "Create Task";
            this.btnCreateUpdateTask.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCreateUpdateTask.CheckedForeColor = System.Drawing.Color.White;
            this.btnCreateUpdateTask.CheckedImageTint = System.Drawing.Color.White;
            this.btnCreateUpdateTask.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCreateUpdateTask.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateUpdateTask.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateUpdateTask.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnCreateUpdateTask.HoverForeColor = System.Drawing.Color.White;
            this.btnCreateUpdateTask.HoverImage = null;
            this.btnCreateUpdateTask.HoverImageTint = System.Drawing.Color.White;
            this.btnCreateUpdateTask.HoverOutline = System.Drawing.Color.Empty;
            this.btnCreateUpdateTask.Image = null;
            this.btnCreateUpdateTask.ImageAutoCenter = false;
            this.btnCreateUpdateTask.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCreateUpdateTask.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnCreateUpdateTask.ImageTint = System.Drawing.Color.White;
            this.btnCreateUpdateTask.IsToggleButton = false;
            this.btnCreateUpdateTask.IsToggled = false;
            this.btnCreateUpdateTask.Location = new System.Drawing.Point(34, 566);
            this.btnCreateUpdateTask.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCreateUpdateTask.Name = "btnCreateUpdateTask";
            this.btnCreateUpdateTask.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnCreateUpdateTask.NormalForeColor = System.Drawing.Color.White;
            this.btnCreateUpdateTask.NormalOutline = System.Drawing.Color.Empty;
            this.btnCreateUpdateTask.OutlineThickness = 2F;
            this.btnCreateUpdateTask.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnCreateUpdateTask.PressedForeColor = System.Drawing.Color.White;
            this.btnCreateUpdateTask.PressedImageTint = System.Drawing.Color.White;
            this.btnCreateUpdateTask.PressedOutline = System.Drawing.Color.Empty;
            this.btnCreateUpdateTask.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCreateUpdateTask.Size = new System.Drawing.Size(379, 35);
            this.btnCreateUpdateTask.TabIndex = 34;
            this.btnCreateUpdateTask.TextAutoCenter = true;
            this.btnCreateUpdateTask.TextOffset = new System.Drawing.Point(0, 0);
            this.btnCreateUpdateTask.Click += new System.EventHandler(this.btnCreateUpdateTask_Click);
            // 
            // ckbTaskCompleted
            // 
            this.ckbTaskCompleted.AutoSize = true;
            this.ckbTaskCompleted.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.ckbTaskCompleted.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckbTaskCompleted.Location = new System.Drawing.Point(299, 304);
            this.ckbTaskCompleted.Name = "ckbTaskCompleted";
            this.ckbTaskCompleted.Size = new System.Drawing.Size(137, 26);
            this.ckbTaskCompleted.TabIndex = 38;
            this.ckbTaskCompleted.Text = "Completed";
            this.ckbTaskCompleted.UseVisualStyleBackColor = true;
            // 
            // lblTaskDeadlineError
            // 
            this.lblTaskDeadlineError.AutoSize = true;
            this.lblTaskDeadlineError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskDeadlineError.ForeColor = System.Drawing.Color.Red;
            this.lblTaskDeadlineError.Location = new System.Drawing.Point(35, 330);
            this.lblTaskDeadlineError.Name = "lblTaskDeadlineError";
            this.lblTaskDeadlineError.Size = new System.Drawing.Size(35, 16);
            this.lblTaskDeadlineError.TabIndex = 42;
            this.lblTaskDeadlineError.Text = "Error";
            this.lblTaskDeadlineError.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 21);
            this.label4.TabIndex = 41;
            this.label4.Text = "Deadline";
            // 
            // dtpTaskDeadline
            // 
            this.dtpTaskDeadline.BackColor = System.Drawing.Color.Transparent;
            this.dtpTaskDeadline.BackgroundColor = System.Drawing.Color.White;
            this.dtpTaskDeadline.BorderColor = System.Drawing.Color.LightGray;
            this.dtpTaskDeadline.BorderThickness = 1;
            this.dtpTaskDeadline.CornerRadius = 5;
            this.dtpTaskDeadline.Location = new System.Drawing.Point(36, 303);
            this.dtpTaskDeadline.Name = "dtpTaskDeadline";
            this.dtpTaskDeadline.Size = new System.Drawing.Size(250, 28);
            this.dtpTaskDeadline.TabIndex = 40;
            // 
            // frmCreateUpdateTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 620);
            this.Controls.Add(this.lblTaskDeadlineError);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTaskDeadline);
            this.Controls.Add(this.ckbTaskCompleted);
            this.Controls.Add(this.dgViewUsers);
            this.Controls.Add(this.lblTaskDescriptionError);
            this.Controls.Add(this.lblTaskTitleError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTaskTitle);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreateUpdateTask);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCreateUpdateTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Action;
        private System.Windows.Forms.Label lblTaskDescriptionError;
        private System.Windows.Forms.Label lblTaskTitleError;
        private System.Windows.Forms.Label label2;
        private SATATextBox txtTaskDescription;
        private System.Windows.Forms.Label label1;
        private SATATextBox txtTaskTitle;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.Label label3;
        private FrameworkTest.SATAButton btnCreateUpdateTask;
        private System.Windows.Forms.CheckBox ckbTaskCompleted;
        private System.Windows.Forms.Label lblTaskDeadlineError;
        private System.Windows.Forms.Label label4;
        private SATAUiFramework.Controls.SATADateTimePicker dtpTaskDeadline;
    }
}