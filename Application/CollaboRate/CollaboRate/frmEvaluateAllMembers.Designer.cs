namespace CollaboRate
{
    partial class frmEvaluateAllMembers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgViewUsers = new System.Windows.Forms.DataGridView();
            this.txtSearchUsername = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnSubmitEvaluations = new FrameworkTest.SATAButton();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Score = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pbLoadingSpinner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).BeginInit();
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgViewUsers.ColumnHeadersHeight = 28;
            this.dgViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Name,
            this.User_Score});
            this.dgViewUsers.EnableHeadersVisualStyles = false;
            this.dgViewUsers.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewUsers.Location = new System.Drawing.Point(34, 107);
            this.dgViewUsers.Name = "dgViewUsers";
            this.dgViewUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewUsers.RowHeadersVisible = false;
            this.dgViewUsers.RowHeadersWidth = 51;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewUsers.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgViewUsers.RowTemplate.Height = 28;
            this.dgViewUsers.Size = new System.Drawing.Size(344, 405);
            this.dgViewUsers.TabIndex = 45;
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
            this.txtSearchUsername.Location = new System.Drawing.Point(34, 54);
            this.txtSearchUsername.Multiline = false;
            this.txtSearchUsername.Name = "txtSearchUsername";
            this.txtSearchUsername.PasswordChar = false;
            this.txtSearchUsername.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchUsername.PlaceholderText = "Search username";
            this.txtSearchUsername.Size = new System.Drawing.Size(344, 39);
            this.txtSearchUsername.TabIndex = 44;
            this.txtSearchUsername.Texts = "";
            this.txtSearchUsername.UnderlinedStyle = false;
            this.txtSearchUsername._TextChanged += new System.EventHandler(this.txtSearchUsername__TextChanged);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(91, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(221, 23);
            this.lblHeading.TabIndex = 37;
            this.lblHeading.Text = "Evaluate All Members";
            // 
            // btnSubmitEvaluations
            // 
            this.btnSubmitEvaluations.ButtonText = "Submit Evaluations";
            this.btnSubmitEvaluations.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSubmitEvaluations.CheckedForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluations.CheckedImageTint = System.Drawing.Color.White;
            this.btnSubmitEvaluations.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSubmitEvaluations.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSubmitEvaluations.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitEvaluations.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSubmitEvaluations.HoverForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluations.HoverImage = null;
            this.btnSubmitEvaluations.HoverImageTint = System.Drawing.Color.White;
            this.btnSubmitEvaluations.HoverOutline = System.Drawing.Color.Empty;
            this.btnSubmitEvaluations.Image = null;
            this.btnSubmitEvaluations.ImageAutoCenter = false;
            this.btnSubmitEvaluations.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSubmitEvaluations.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSubmitEvaluations.ImageTint = System.Drawing.Color.White;
            this.btnSubmitEvaluations.IsToggleButton = false;
            this.btnSubmitEvaluations.IsToggled = false;
            this.btnSubmitEvaluations.Location = new System.Drawing.Point(34, 560);
            this.btnSubmitEvaluations.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSubmitEvaluations.Name = "btnSubmitEvaluations";
            this.btnSubmitEvaluations.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSubmitEvaluations.NormalForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluations.NormalOutline = System.Drawing.Color.Empty;
            this.btnSubmitEvaluations.OutlineThickness = 2F;
            this.btnSubmitEvaluations.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSubmitEvaluations.PressedForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluations.PressedImageTint = System.Drawing.Color.White;
            this.btnSubmitEvaluations.PressedOutline = System.Drawing.Color.Empty;
            this.btnSubmitEvaluations.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSubmitEvaluations.Size = new System.Drawing.Size(344, 35);
            this.btnSubmitEvaluations.TabIndex = 46;
            this.btnSubmitEvaluations.TextAutoCenter = true;
            this.btnSubmitEvaluations.TextOffset = new System.Drawing.Point(0, 0);
            this.btnSubmitEvaluations.Click += new System.EventHandler(this.btnSubmitEvaluations_Click);
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
            // User_Name
            // 
            this.User_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_Name.DataPropertyName = "Username";
            this.User_Name.HeaderText = "Username";
            this.User_Name.MinimumWidth = 6;
            this.User_Name.Name = "User_Name";
            this.User_Name.ReadOnly = true;
            // 
            // User_Score
            // 
            this.User_Score.DataPropertyName = "Score";
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.User_Score.DefaultCellStyle = dataGridViewCellStyle14;
            this.User_Score.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.User_Score.FillWeight = 75F;
            this.User_Score.HeaderText = "Score";
            this.User_Score.Items.AddRange(new object[] {
            "1. Unsatisfactory",
            "2",
            "3",
            "4",
            "5. Excellent"});
            this.User_Score.MinimumWidth = 6;
            this.User_Score.Name = "User_Score";
            this.User_Score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.User_Score.Width = 125;
            // 
            // pbLoadingSpinner
            // 
            this.pbLoadingSpinner.BackColor = System.Drawing.SystemColors.Control;
            this.pbLoadingSpinner.Image = global::CollaboRate.Properties.Resources.Loading_Gif;
            this.pbLoadingSpinner.Location = new System.Drawing.Point(189, 292);
            this.pbLoadingSpinner.Name = "pbLoadingSpinner";
            this.pbLoadingSpinner.Size = new System.Drawing.Size(32, 26);
            this.pbLoadingSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingSpinner.TabIndex = 55;
            this.pbLoadingSpinner.TabStop = false;
            this.pbLoadingSpinner.Visible = false;
            // 
            // frmEvaluateAllMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 611);
            this.Controls.Add(this.pbLoadingSpinner);
            this.Controls.Add(this.dgViewUsers);
            this.Controls.Add(this.txtSearchUsername);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnSubmitEvaluations);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEvaluateAllMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEvaluateAllMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgViewUsers;
        private SATATextBox txtSearchUsername;
        private System.Windows.Forms.Label lblHeading;
        private FrameworkTest.SATAButton btnSubmitEvaluations;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn User_Score;
        private System.Windows.Forms.PictureBox pbLoadingSpinner;
    }
}