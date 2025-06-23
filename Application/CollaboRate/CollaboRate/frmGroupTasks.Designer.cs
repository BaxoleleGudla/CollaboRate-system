namespace CollaboRate
{
    partial class frmGroupTasks
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
            this.btnCreateNewTask = new FrameworkTest.SATAButton();
            this.lblHeading = new System.Windows.Forms.Label();
            this.txtSearchTask = new SATATextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgViewTasks = new System.Windows.Forms.DataGridView();
            this.Task_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assigned_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkAsCompleted = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateNewTask
            // 
            this.btnCreateNewTask.ButtonText = "Create New Task";
            this.btnCreateNewTask.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCreateNewTask.CheckedForeColor = System.Drawing.Color.White;
            this.btnCreateNewTask.CheckedImageTint = System.Drawing.Color.White;
            this.btnCreateNewTask.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCreateNewTask.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreateNewTask.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewTask.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnCreateNewTask.HoverForeColor = System.Drawing.Color.White;
            this.btnCreateNewTask.HoverImage = null;
            this.btnCreateNewTask.HoverImageTint = System.Drawing.Color.White;
            this.btnCreateNewTask.HoverOutline = System.Drawing.Color.Empty;
            this.btnCreateNewTask.Image = global::CollaboRate.Properties.Resources.home;
            this.btnCreateNewTask.ImageAutoCenter = false;
            this.btnCreateNewTask.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCreateNewTask.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnCreateNewTask.ImageTint = System.Drawing.Color.White;
            this.btnCreateNewTask.IsToggleButton = false;
            this.btnCreateNewTask.IsToggled = false;
            this.btnCreateNewTask.Location = new System.Drawing.Point(557, 27);
            this.btnCreateNewTask.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCreateNewTask.Name = "btnCreateNewTask";
            this.btnCreateNewTask.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnCreateNewTask.NormalForeColor = System.Drawing.Color.White;
            this.btnCreateNewTask.NormalOutline = System.Drawing.Color.Empty;
            this.btnCreateNewTask.OutlineThickness = 2F;
            this.btnCreateNewTask.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnCreateNewTask.PressedForeColor = System.Drawing.Color.White;
            this.btnCreateNewTask.PressedImageTint = System.Drawing.Color.White;
            this.btnCreateNewTask.PressedOutline = System.Drawing.Color.Empty;
            this.btnCreateNewTask.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCreateNewTask.Size = new System.Drawing.Size(235, 35);
            this.btnCreateNewTask.TabIndex = 20;
            this.btnCreateNewTask.TextAutoCenter = false;
            this.btnCreateNewTask.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(219, 27);
            this.lblHeading.TabIndex = 19;
            this.lblHeading.Text = "Task Management";
            // 
            // txtSearchTask
            // 
            this.txtSearchTask.BackColor = System.Drawing.Color.White;
            this.txtSearchTask.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchTask.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtSearchTask.BorderRadius = 5;
            this.txtSearchTask.BorderSize = 1;
            this.txtSearchTask.Icon = null;
            this.txtSearchTask.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchTask.Location = new System.Drawing.Point(15, 91);
            this.txtSearchTask.Multiline = false;
            this.txtSearchTask.Name = "txtSearchTask";
            this.txtSearchTask.PasswordChar = false;
            this.txtSearchTask.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchTask.PlaceholderText = "Search task";
            this.txtSearchTask.Size = new System.Drawing.Size(772, 39);
            this.txtSearchTask.TabIndex = 22;
            this.txtSearchTask.Texts = "";
            this.txtSearchTask.UnderlinedStyle = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(324, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgViewTasks
            // 
            this.dgViewTasks.AllowUserToAddRows = false;
            this.dgViewTasks.AllowUserToDeleteRows = false;
            this.dgViewTasks.AllowUserToResizeColumns = false;
            this.dgViewTasks.AllowUserToResizeRows = false;
            this.dgViewTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgViewTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewTasks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgViewTasks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewTasks.ColumnHeadersHeight = 35;
            this.dgViewTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Task_ID,
            this.Task_Title,
            this.Task_Description,
            this.Task_Deadline,
            this.Assigned_To,
            this.Task_Status,
            this.MarkAsCompleted});
            this.dgViewTasks.EnableHeadersVisualStyles = false;
            this.dgViewTasks.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewTasks.Location = new System.Drawing.Point(15, 152);
            this.dgViewTasks.MultiSelect = false;
            this.dgViewTasks.Name = "dgViewTasks";
            this.dgViewTasks.ReadOnly = true;
            this.dgViewTasks.RowHeadersVisible = false;
            this.dgViewTasks.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewTasks.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewTasks.RowTemplate.Height = 35;
            this.dgViewTasks.Size = new System.Drawing.Size(772, 463);
            this.dgViewTasks.TabIndex = 24;
            // 
            // Task_ID
            // 
            this.Task_ID.HeaderText = "Task ID";
            this.Task_ID.MinimumWidth = 6;
            this.Task_ID.Name = "Task_ID";
            this.Task_ID.ReadOnly = true;
            this.Task_ID.Visible = false;
            this.Task_ID.Width = 155;
            // 
            // Task_Title
            // 
            this.Task_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Task_Title.HeaderText = "Task Title";
            this.Task_Title.MinimumWidth = 6;
            this.Task_Title.Name = "Task_Title";
            this.Task_Title.ReadOnly = true;
            // 
            // Task_Description
            // 
            this.Task_Description.HeaderText = "Description";
            this.Task_Description.MinimumWidth = 6;
            this.Task_Description.Name = "Task_Description";
            this.Task_Description.ReadOnly = true;
            this.Task_Description.Width = 125;
            // 
            // Task_Deadline
            // 
            this.Task_Deadline.HeaderText = "Deadline";
            this.Task_Deadline.MinimumWidth = 6;
            this.Task_Deadline.Name = "Task_Deadline";
            this.Task_Deadline.ReadOnly = true;
            this.Task_Deadline.Width = 125;
            // 
            // Assigned_To
            // 
            this.Assigned_To.HeaderText = "Assigned To";
            this.Assigned_To.MinimumWidth = 6;
            this.Assigned_To.Name = "Assigned_To";
            this.Assigned_To.ReadOnly = true;
            this.Assigned_To.Width = 114;
            // 
            // Task_Status
            // 
            this.Task_Status.HeaderText = "Status";
            this.Task_Status.MinimumWidth = 6;
            this.Task_Status.Name = "Task_Status";
            this.Task_Status.ReadOnly = true;
            this.Task_Status.Width = 110;
            // 
            // MarkAsCompleted
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.MarkAsCompleted.DefaultCellStyle = dataGridViewCellStyle2;
            this.MarkAsCompleted.FillWeight = 75F;
            this.MarkAsCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarkAsCompleted.HeaderText = "Action";
            this.MarkAsCompleted.MinimumWidth = 6;
            this.MarkAsCompleted.Name = "MarkAsCompleted";
            this.MarkAsCompleted.ReadOnly = true;
            this.MarkAsCompleted.Text = "Mark as completed";
            this.MarkAsCompleted.UseColumnTextForButtonValue = true;
            this.MarkAsCompleted.Width = 160;
            // 
            // frmGroupTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.dgViewTasks);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCreateNewTask);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtSearchTask);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGroupTasks";
            this.Text = "frmGroupTasks";
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameworkTest.SATAButton btnCreateNewTask;
        private System.Windows.Forms.Label lblHeading;
        private SATATextBox txtSearchTask;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgViewTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assigned_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_Status;
        private System.Windows.Forms.DataGridViewButtonColumn MarkAsCompleted;
    }
}