namespace CollaboRate
{
    partial class frmGroupMeetings
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
            this.dgViewMeetings = new System.Windows.Forms.DataGridView();
            this.lblHeading = new System.Windows.Forms.Label();
            this.txtSearchMeeting = new SATATextBox();
            this.btnScheduleNewMeeting = new FrameworkTest.SATAButton();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.Meeting_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Meeting_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MarkAsCompleted = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewMeetings
            // 
            this.dgViewMeetings.AllowUserToAddRows = false;
            this.dgViewMeetings.AllowUserToDeleteRows = false;
            this.dgViewMeetings.AllowUserToResizeColumns = false;
            this.dgViewMeetings.AllowUserToResizeRows = false;
            this.dgViewMeetings.BackgroundColor = System.Drawing.Color.White;
            this.dgViewMeetings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewMeetings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgViewMeetings.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMeetings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMeetings.ColumnHeadersHeight = 35;
            this.dgViewMeetings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMeetings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Meeting_ID,
            this.Meeting_Title,
            this.Meeting_Description,
            this.Meeting_Date,
            this.MarkAsCompleted});
            this.dgViewMeetings.EnableHeadersVisualStyles = false;
            this.dgViewMeetings.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMeetings.Location = new System.Drawing.Point(15, 152);
            this.dgViewMeetings.MultiSelect = false;
            this.dgViewMeetings.Name = "dgViewMeetings";
            this.dgViewMeetings.ReadOnly = true;
            this.dgViewMeetings.RowHeadersVisible = false;
            this.dgViewMeetings.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMeetings.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewMeetings.RowTemplate.Height = 35;
            this.dgViewMeetings.Size = new System.Drawing.Size(772, 463);
            this.dgViewMeetings.TabIndex = 29;
            this.dgViewMeetings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewMeetings_CellClick);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(264, 27);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Meeting Management";
            // 
            // txtSearchMeeting
            // 
            this.txtSearchMeeting.BackColor = System.Drawing.Color.White;
            this.txtSearchMeeting.BorderColor = System.Drawing.Color.DarkGray;
            this.txtSearchMeeting.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchMeeting.BorderRadius = 5;
            this.txtSearchMeeting.BorderSize = 1;
            this.txtSearchMeeting.Icon = null;
            this.txtSearchMeeting.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchMeeting.Location = new System.Drawing.Point(15, 91);
            this.txtSearchMeeting.Multiline = false;
            this.txtSearchMeeting.Name = "txtSearchMeeting";
            this.txtSearchMeeting.PasswordChar = false;
            this.txtSearchMeeting.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchMeeting.PlaceholderText = "Search meeting";
            this.txtSearchMeeting.Size = new System.Drawing.Size(772, 39);
            this.txtSearchMeeting.TabIndex = 27;
            this.txtSearchMeeting.Texts = "";
            this.txtSearchMeeting.UnderlinedStyle = false;
            this.txtSearchMeeting._TextChanged += new System.EventHandler(this.txtSearchMeeting__TextChanged);
            // 
            // btnScheduleNewMeeting
            // 
            this.btnScheduleNewMeeting.ButtonText = "Schedule Meeting";
            this.btnScheduleNewMeeting.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnScheduleNewMeeting.CheckedForeColor = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.CheckedImageTint = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnScheduleNewMeeting.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScheduleNewMeeting.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleNewMeeting.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnScheduleNewMeeting.HoverForeColor = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.HoverImage = null;
            this.btnScheduleNewMeeting.HoverImageTint = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.HoverOutline = System.Drawing.Color.Empty;
            this.btnScheduleNewMeeting.Image = global::CollaboRate.Properties.Resources.home;
            this.btnScheduleNewMeeting.ImageAutoCenter = false;
            this.btnScheduleNewMeeting.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnScheduleNewMeeting.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnScheduleNewMeeting.ImageTint = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.IsToggleButton = false;
            this.btnScheduleNewMeeting.IsToggled = false;
            this.btnScheduleNewMeeting.Location = new System.Drawing.Point(557, 27);
            this.btnScheduleNewMeeting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnScheduleNewMeeting.Name = "btnScheduleNewMeeting";
            this.btnScheduleNewMeeting.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnScheduleNewMeeting.NormalForeColor = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.NormalOutline = System.Drawing.Color.Empty;
            this.btnScheduleNewMeeting.OutlineThickness = 2F;
            this.btnScheduleNewMeeting.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnScheduleNewMeeting.PressedForeColor = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.PressedImageTint = System.Drawing.Color.White;
            this.btnScheduleNewMeeting.PressedOutline = System.Drawing.Color.Empty;
            this.btnScheduleNewMeeting.Rounding = new System.Windows.Forms.Padding(5);
            this.btnScheduleNewMeeting.Size = new System.Drawing.Size(235, 35);
            this.btnScheduleNewMeeting.TabIndex = 26;
            this.btnScheduleNewMeeting.TextAutoCenter = false;
            this.btnScheduleNewMeeting.TextOffset = new System.Drawing.Point(0, 0);
            this.btnScheduleNewMeeting.Click += new System.EventHandler(this.btnScheduleNewMeeting_Click);
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.BackColor = System.Drawing.SystemColors.Control;
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(389, 300);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 53;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // Meeting_ID
            // 
            this.Meeting_ID.DataPropertyName = "Meeting_ID";
            this.Meeting_ID.HeaderText = "Meeting ID";
            this.Meeting_ID.MinimumWidth = 6;
            this.Meeting_ID.Name = "Meeting_ID";
            this.Meeting_ID.ReadOnly = true;
            this.Meeting_ID.Visible = false;
            this.Meeting_ID.Width = 155;
            // 
            // Meeting_Title
            // 
            this.Meeting_Title.DataPropertyName = "Meeting_Title";
            this.Meeting_Title.FillWeight = 150F;
            this.Meeting_Title.HeaderText = "Meeting Title";
            this.Meeting_Title.MinimumWidth = 6;
            this.Meeting_Title.Name = "Meeting_Title";
            this.Meeting_Title.ReadOnly = true;
            this.Meeting_Title.Width = 260;
            // 
            // Meeting_Description
            // 
            this.Meeting_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Meeting_Description.DataPropertyName = "Meeting_Description";
            this.Meeting_Description.HeaderText = "Description";
            this.Meeting_Description.MinimumWidth = 6;
            this.Meeting_Description.Name = "Meeting_Description";
            this.Meeting_Description.ReadOnly = true;
            // 
            // Meeting_Date
            // 
            this.Meeting_Date.DataPropertyName = "Meeting_Date";
            this.Meeting_Date.HeaderText = "Meeting Date";
            this.Meeting_Date.MinimumWidth = 6;
            this.Meeting_Date.Name = "Meeting_Date";
            this.Meeting_Date.ReadOnly = true;
            this.Meeting_Date.Width = 160;
            // 
            // MarkAsCompleted
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.MarkAsCompleted.DefaultCellStyle = dataGridViewCellStyle2;
            this.MarkAsCompleted.FillWeight = 75F;
            this.MarkAsCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarkAsCompleted.HeaderText = "Action";
            this.MarkAsCompleted.MinimumWidth = 6;
            this.MarkAsCompleted.Name = "MarkAsCompleted";
            this.MarkAsCompleted.ReadOnly = true;
            this.MarkAsCompleted.Text = "Cancel Meeting";
            this.MarkAsCompleted.UseColumnTextForButtonValue = true;
            this.MarkAsCompleted.Width = 160;
            // 
            // frmGroupMeetings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.dgViewMeetings);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtSearchMeeting);
            this.Controls.Add(this.btnScheduleNewMeeting);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGroupMeetings";
            this.Text = "frmGroupMeetings";
            this.Load += new System.EventHandler(this.frmGroupMeetings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMeetings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewMeetings;
        private System.Windows.Forms.Label lblHeading;
        private SATATextBox txtSearchMeeting;
        private FrameworkTest.SATAButton btnScheduleNewMeeting;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Meeting_Date;
        private System.Windows.Forms.DataGridViewButtonColumn MarkAsCompleted;
    }
}