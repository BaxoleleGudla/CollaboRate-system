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
            this.Member_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member_Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rated_At = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score_Average = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEvaluateAllMembers = new FrameworkTest.SATAButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).BeginInit();
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
            this.txtSearchMemberName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchMemberName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
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
            this.txtSearchMemberName.Size = new System.Drawing.Size(772, 39);
            this.txtSearchMemberName.TabIndex = 18;
            this.txtSearchMemberName.Texts = "";
            this.txtSearchMemberName.UnderlinedStyle = false;
            // 
            // dgViewMemberEvaluations
            // 
            this.dgViewMemberEvaluations.AllowUserToAddRows = false;
            this.dgViewMemberEvaluations.AllowUserToDeleteRows = false;
            this.dgViewMemberEvaluations.AllowUserToResizeColumns = false;
            this.dgViewMemberEvaluations.AllowUserToResizeRows = false;
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
            this.Member_ID,
            this.Member_Name,
            this.Member_Score,
            this.Rated_At,
            this.Score_Average});
            this.dgViewMemberEvaluations.EnableHeadersVisualStyles = false;
            this.dgViewMemberEvaluations.GridColor = System.Drawing.SystemColors.Control;
            this.dgViewMemberEvaluations.Location = new System.Drawing.Point(15, 152);
            this.dgViewMemberEvaluations.MultiSelect = false;
            this.dgViewMemberEvaluations.Name = "dgViewMemberEvaluations";
            this.dgViewMemberEvaluations.ReadOnly = true;
            this.dgViewMemberEvaluations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgViewMemberEvaluations.RowHeadersVisible = false;
            this.dgViewMemberEvaluations.RowHeadersWidth = 51;
            this.dgViewMemberEvaluations.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgViewMemberEvaluations.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgViewMemberEvaluations.RowTemplate.Height = 35;
            this.dgViewMemberEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewMemberEvaluations.Size = new System.Drawing.Size(772, 463);
            this.dgViewMemberEvaluations.TabIndex = 17;
            // 
            // Member_ID
            // 
            this.Member_ID.HeaderText = "Member ID";
            this.Member_ID.MinimumWidth = 6;
            this.Member_ID.Name = "Member_ID";
            this.Member_ID.ReadOnly = true;
            this.Member_ID.Visible = false;
            this.Member_ID.Width = 125;
            // 
            // Member_Name
            // 
            this.Member_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Member_Name.HeaderText = "Member Name";
            this.Member_Name.MinimumWidth = 6;
            this.Member_Name.Name = "Member_Name";
            this.Member_Name.ReadOnly = true;
            // 
            // Member_Score
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.Member_Score.DefaultCellStyle = dataGridViewCellStyle2;
            this.Member_Score.FillWeight = 75F;
            this.Member_Score.HeaderText = "Member Score";
            this.Member_Score.MinimumWidth = 6;
            this.Member_Score.Name = "Member_Score";
            this.Member_Score.ReadOnly = true;
            this.Member_Score.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Member_Score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Member_Score.Width = 235;
            // 
            // Rated_At
            // 
            this.Rated_At.HeaderText = "Rated At";
            this.Rated_At.MinimumWidth = 6;
            this.Rated_At.Name = "Rated_At";
            this.Rated_At.ReadOnly = true;
            this.Rated_At.Width = 125;
            // 
            // Score_Average
            // 
            this.Score_Average.HeaderText = "Average";
            this.Score_Average.MinimumWidth = 6;
            this.Score_Average.Name = "Score_Average";
            this.Score_Average.ReadOnly = true;
            this.Score_Average.Width = 125;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEvaluateAllMembers
            // 
            this.btnEvaluateAllMembers.ButtonText = "Evaluate All Members";
            this.btnEvaluateAllMembers.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnEvaluateAllMembers.CheckedForeColor = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.CheckedImageTint = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnEvaluateAllMembers.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEvaluateAllMembers.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvaluateAllMembers.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnEvaluateAllMembers.HoverForeColor = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.HoverImage = null;
            this.btnEvaluateAllMembers.HoverImageTint = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.HoverOutline = System.Drawing.Color.Empty;
            this.btnEvaluateAllMembers.Image = global::CollaboRate.Properties.Resources.home;
            this.btnEvaluateAllMembers.ImageAutoCenter = false;
            this.btnEvaluateAllMembers.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnEvaluateAllMembers.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnEvaluateAllMembers.ImageTint = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.IsToggleButton = false;
            this.btnEvaluateAllMembers.IsToggled = false;
            this.btnEvaluateAllMembers.Location = new System.Drawing.Point(557, 27);
            this.btnEvaluateAllMembers.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnEvaluateAllMembers.Name = "btnEvaluateAllMembers";
            this.btnEvaluateAllMembers.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnEvaluateAllMembers.NormalForeColor = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.NormalOutline = System.Drawing.Color.Empty;
            this.btnEvaluateAllMembers.OutlineThickness = 2F;
            this.btnEvaluateAllMembers.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnEvaluateAllMembers.PressedForeColor = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.PressedImageTint = System.Drawing.Color.White;
            this.btnEvaluateAllMembers.PressedOutline = System.Drawing.Color.Empty;
            this.btnEvaluateAllMembers.Rounding = new System.Windows.Forms.Padding(5);
            this.btnEvaluateAllMembers.Size = new System.Drawing.Size(235, 35);
            this.btnEvaluateAllMembers.TabIndex = 16;
            this.btnEvaluateAllMembers.TextAutoCenter = false;
            this.btnEvaluateAllMembers.TextOffset = new System.Drawing.Point(0, 0);
            this.btnEvaluateAllMembers.Click += new System.EventHandler(this.btnEvaluateAllMembers_Click);
            // 
            // frmMemberEvaluations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnEvaluateAllMembers);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtSearchMemberName);
            this.Controls.Add(this.dgViewMemberEvaluations);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMemberEvaluations";
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMemberEvaluations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FrameworkTest.SATAButton btnEvaluateAllMembers;
        private System.Windows.Forms.Label lblHeading;
        private SATATextBox txtSearchMemberName;
        private System.Windows.Forms.DataGridView dgViewMemberEvaluations;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member_Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rated_At;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score_Average;
    }
}