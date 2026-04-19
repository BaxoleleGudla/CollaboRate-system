namespace CollaboRate
{
    partial class frmMemberEvaluations
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.txtSearchMemberName = new SATATextBox();
            this.dgViewMemberEvaluations = new System.Windows.Forms.DataGridView();
            this.btnSaveEvaluations = new FrameworkTest.SATAButton();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MyCurrentScore = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AverageScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedRatingsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PotentialRatingsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RatingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(298, 27);
            this.lblHeading.TabIndex = 15;
            this.lblHeading.Text = "Evaluations Management";
            // 
            // txtSearchMemberName
            // 
            this.txtSearchMemberName.BackColor = System.Drawing.Color.White;
            this.txtSearchMemberName.BorderColor = System.Drawing.Color.DimGray;
            this.txtSearchMemberName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchMemberName.BorderRadius = 5;
            this.txtSearchMemberName.BorderSize = 1;
            this.txtSearchMemberName.Icon = null;
            this.txtSearchMemberName.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchMemberName.Location = new System.Drawing.Point(15, 91);
            this.txtSearchMemberName.Multiline = false;
            this.txtSearchMemberName.Name = "txtSearchMemberName";
            this.txtSearchMemberName.PasswordChar = false;
            this.txtSearchMemberName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchMemberName.PlaceholderText = "Search nember name";
            this.txtSearchMemberName.Size = new System.Drawing.Size(394, 39);
            this.txtSearchMemberName.TabIndex = 18;
            this.txtSearchMemberName.Texts = "";
            this.txtSearchMemberName.UnderlinedStyle = false;
            this.txtSearchMemberName._TextChanged += new System.EventHandler(this.txtSearchMemberName__TextChanged);
            // 
            // dgViewMemberEvaluations
            // 
            this.dgViewMemberEvaluations.AllowUserToAddRows = false;
            this.dgViewMemberEvaluations.AllowUserToDeleteRows = false;
            this.dgViewMemberEvaluations.AllowUserToResizeColumns = false;
            this.dgViewMemberEvaluations.AllowUserToResizeRows = false;
            this.dgViewMemberEvaluations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgViewMemberEvaluations.BackgroundColor = System.Drawing.Color.White;
            this.dgViewMemberEvaluations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgViewMemberEvaluations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgViewMemberEvaluations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMemberEvaluations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMemberEvaluations.ColumnHeadersHeight = 35;
            this.dgViewMemberEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewMemberEvaluations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Member_Name,
            this.MyCurrentScore,
            this.AverageScore,
            this.ReceivedRatingsCount,
            this.PotentialRatingsCount,
            this.RatingStatus});
            this.dgViewMemberEvaluations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgViewMemberEvaluations.EnableHeadersVisualStyles = false;
            this.dgViewMemberEvaluations.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMemberEvaluations.Location = new System.Drawing.Point(15, 152);
            this.dgViewMemberEvaluations.MultiSelect = false;
            this.dgViewMemberEvaluations.Name = "dgViewMemberEvaluations";
            this.dgViewMemberEvaluations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewMemberEvaluations.RowHeadersVisible = false;
            this.dgViewMemberEvaluations.RowHeadersWidth = 51;
            this.dgViewMemberEvaluations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMemberEvaluations.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewMemberEvaluations.RowTemplate.Height = 35;
            this.dgViewMemberEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgViewMemberEvaluations.Size = new System.Drawing.Size(772, 463);
            this.dgViewMemberEvaluations.TabIndex = 17;
            // 
            // btnSaveEvaluations
            // 
            this.btnSaveEvaluations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEvaluations.ButtonText = "Save Evaluations";
            this.btnSaveEvaluations.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSaveEvaluations.CheckedForeColor = System.Drawing.Color.White;
            this.btnSaveEvaluations.CheckedImageTint = System.Drawing.Color.White;
            this.btnSaveEvaluations.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSaveEvaluations.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveEvaluations.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEvaluations.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSaveEvaluations.HoverForeColor = System.Drawing.Color.White;
            this.btnSaveEvaluations.HoverImage = null;
            this.btnSaveEvaluations.HoverImageTint = System.Drawing.Color.White;
            this.btnSaveEvaluations.HoverOutline = System.Drawing.Color.Empty;
            this.btnSaveEvaluations.Image = global::CollaboRate.Properties.Resources.home;
            this.btnSaveEvaluations.ImageAutoCenter = false;
            this.btnSaveEvaluations.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSaveEvaluations.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSaveEvaluations.ImageTint = System.Drawing.Color.White;
            this.btnSaveEvaluations.IsToggleButton = false;
            this.btnSaveEvaluations.IsToggled = false;
            this.btnSaveEvaluations.Location = new System.Drawing.Point(557, 27);
            this.btnSaveEvaluations.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveEvaluations.Name = "btnSaveEvaluations";
            this.btnSaveEvaluations.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSaveEvaluations.NormalForeColor = System.Drawing.Color.White;
            this.btnSaveEvaluations.NormalOutline = System.Drawing.Color.Empty;
            this.btnSaveEvaluations.OutlineThickness = 2F;
            this.btnSaveEvaluations.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSaveEvaluations.PressedForeColor = System.Drawing.Color.White;
            this.btnSaveEvaluations.PressedImageTint = System.Drawing.Color.White;
            this.btnSaveEvaluations.PressedOutline = System.Drawing.Color.Empty;
            this.btnSaveEvaluations.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSaveEvaluations.Size = new System.Drawing.Size(235, 35);
            this.btnSaveEvaluations.TabIndex = 16;
            this.btnSaveEvaluations.TextAutoCenter = false;
            this.btnSaveEvaluations.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSaveEvaluations.Click += new System.EventHandler(this.btnEvaluateAllMembers_Click);
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.BackColor = System.Drawing.SystemColors.Control;
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(389, 300);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 54;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "Member ID";
            this.User_ID.MinimumWidth = 6;
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Visible = false;
            this.User_ID.Width = 80;
            // 
            // Member_Name
            // 
            this.Member_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Member_Name.DataPropertyName = "Username";
            this.Member_Name.HeaderText = "Member Name";
            this.Member_Name.MinimumWidth = 6;
            this.Member_Name.Name = "Member_Name";
            this.Member_Name.ReadOnly = true;
            // 
            // MyCurrentScore
            // 
            this.MyCurrentScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MyCurrentScore.DataPropertyName = "MyCurrentScore";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.MyCurrentScore.DefaultCellStyle = dataGridViewCellStyle2;
            this.MyCurrentScore.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.MyCurrentScore.FillWeight = 75F;
            this.MyCurrentScore.HeaderText = "Member Score";
            this.MyCurrentScore.MinimumWidth = 6;
            this.MyCurrentScore.Name = "MyCurrentScore";
            this.MyCurrentScore.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // AverageScore
            // 
            this.AverageScore.DataPropertyName = "AverageScore";
            this.AverageScore.HeaderText = "Average";
            this.AverageScore.MinimumWidth = 6;
            this.AverageScore.Name = "AverageScore";
            this.AverageScore.ReadOnly = true;
            this.AverageScore.Width = 80;
            // 
            // ReceivedRatingsCount
            // 
            this.ReceivedRatingsCount.DataPropertyName = "ReceivedRatingsCount";
            this.ReceivedRatingsCount.HeaderText = "Actual Ratings";
            this.ReceivedRatingsCount.MinimumWidth = 6;
            this.ReceivedRatingsCount.Name = "ReceivedRatingsCount";
            this.ReceivedRatingsCount.ReadOnly = true;
            this.ReceivedRatingsCount.Width = 135;
            // 
            // PotentialRatingsCount
            // 
            this.PotentialRatingsCount.DataPropertyName = "PotentialRatingsCount";
            this.PotentialRatingsCount.HeaderText = "Needed Ratings";
            this.PotentialRatingsCount.MinimumWidth = 6;
            this.PotentialRatingsCount.Name = "PotentialRatingsCount";
            this.PotentialRatingsCount.ReadOnly = true;
            this.PotentialRatingsCount.Width = 150;
            // 
            // RatingStatus
            // 
            this.RatingStatus.DataPropertyName = "RatingStatus";
            this.RatingStatus.HeaderText = "Progress";
            this.RatingStatus.MinimumWidth = 6;
            this.RatingStatus.Name = "RatingStatus";
            this.RatingStatus.ReadOnly = true;
            this.RatingStatus.Width = 80;
            // 
            // frmMemberEvaluations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.btnSaveEvaluations);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtSearchMemberName);
            this.Controls.Add(this.dgViewMemberEvaluations);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMemberEvaluations";
            this.Load += new System.EventHandler(this.frmMemberEvaluations_Load);
            this.Resize += new System.EventHandler(this.frmMemberEvaluations_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameworkTest.SATAButton btnSaveEvaluations;
        private System.Windows.Forms.Label lblHeading;
        private SATATextBox txtSearchMemberName;
        private System.Windows.Forms.DataGridView dgViewMemberEvaluations;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn MyCurrentScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn AverageScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedRatingsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PotentialRatingsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RatingStatus;
    }
}