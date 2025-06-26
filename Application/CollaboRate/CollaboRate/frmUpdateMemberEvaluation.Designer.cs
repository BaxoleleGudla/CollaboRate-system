namespace CollaboRate
{
    partial class frmUpdateMemberEvaluation
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
            this.lblMemberNameError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMemberName = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnSaveChanges = new FrameworkTest.SATAButton();
            this.cmbxScore = new SATAComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAverageScore = new SATATextBox();
            this.SuspendLayout();
            // 
            // lblMemberNameError
            // 
            this.lblMemberNameError.AutoSize = true;
            this.lblMemberNameError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberNameError.ForeColor = System.Drawing.Color.Red;
            this.lblMemberNameError.Location = new System.Drawing.Point(34, 125);
            this.lblMemberNameError.Name = "lblMemberNameError";
            this.lblMemberNameError.Size = new System.Drawing.Size(35, 16);
            this.lblMemberNameError.TabIndex = 30;
            this.lblMemberNameError.Text = "Error";
            this.lblMemberNameError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Score";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Member name";
            // 
            // txtMemberName
            // 
            this.txtMemberName.BackColor = System.Drawing.Color.White;
            this.txtMemberName.BorderColor = System.Drawing.Color.DimGray;
            this.txtMemberName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtMemberName.BorderRadius = 5;
            this.txtMemberName.BorderSize = 1;
            this.txtMemberName.Icon = null;
            this.txtMemberName.IconSize = new System.Drawing.Size(20, 20);
            this.txtMemberName.Location = new System.Drawing.Point(35, 84);
            this.txtMemberName.Multiline = false;
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.PasswordChar = false;
            this.txtMemberName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMemberName.PlaceholderText = "";
            this.txtMemberName.Size = new System.Drawing.Size(344, 39);
            this.txtMemberName.TabIndex = 26;
            this.txtMemberName.Texts = "";
            this.txtMemberName.UnderlinedStyle = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(69, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(275, 23);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Update Member Evaluation";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.ButtonText = "Save Changes";
            this.btnSaveChanges.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.CheckedForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.CheckedImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSaveChanges.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveChanges.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanges.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSaveChanges.HoverForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.HoverImage = null;
            this.btnSaveChanges.HoverImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.HoverOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.Image = null;
            this.btnSaveChanges.ImageAutoCenter = false;
            this.btnSaveChanges.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSaveChanges.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnSaveChanges.ImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.IsToggleButton = false;
            this.btnSaveChanges.IsToggled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(34, 388);
            this.btnSaveChanges.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSaveChanges.NormalForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.NormalOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.OutlineThickness = 2F;
            this.btnSaveChanges.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSaveChanges.PressedForeColor = System.Drawing.Color.White;
            this.btnSaveChanges.PressedImageTint = System.Drawing.Color.White;
            this.btnSaveChanges.PressedOutline = System.Drawing.Color.Empty;
            this.btnSaveChanges.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSaveChanges.Size = new System.Drawing.Size(344, 35);
            this.btnSaveChanges.TabIndex = 34;
            this.btnSaveChanges.TextAutoCenter = true;
            this.btnSaveChanges.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // cmbxScore
            // 
            this.cmbxScore.BackColor = System.Drawing.Color.Transparent;
            this.cmbxScore.BackgroundColor = System.Drawing.Color.White;
            this.cmbxScore.BorderColor = System.Drawing.Color.LightGray;
            this.cmbxScore.BorderThickness = 1;
            this.cmbxScore.CornerRadius = 5;
            this.cmbxScore.Items = new string[] {
        "1. Unsatisfactory",
        "2",
        "3",
        "4",
        "5. Excellent"};
            this.cmbxScore.Keys = null;
            this.cmbxScore.Location = new System.Drawing.Point(36, 178);
            this.cmbxScore.Name = "cmbxScore";
            this.cmbxScore.SelectedIndex = -1;
            this.cmbxScore.Size = new System.Drawing.Size(343, 51);
            this.cmbxScore.TabIndex = 36;
            this.cmbxScore.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.cmbxScore.TextOffset = new System.Windows.Forms.Padding(0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Average score";
            // 
            // txtAverageScore
            // 
            this.txtAverageScore.BackColor = System.Drawing.Color.White;
            this.txtAverageScore.BorderColor = System.Drawing.Color.DimGray;
            this.txtAverageScore.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtAverageScore.BorderRadius = 5;
            this.txtAverageScore.BorderSize = 1;
            this.txtAverageScore.Icon = null;
            this.txtAverageScore.IconSize = new System.Drawing.Size(20, 20);
            this.txtAverageScore.Location = new System.Drawing.Point(37, 273);
            this.txtAverageScore.Multiline = false;
            this.txtAverageScore.Name = "txtAverageScore";
            this.txtAverageScore.PasswordChar = false;
            this.txtAverageScore.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtAverageScore.PlaceholderText = "";
            this.txtAverageScore.Size = new System.Drawing.Size(344, 39);
            this.txtAverageScore.TabIndex = 37;
            this.txtAverageScore.Texts = "";
            this.txtAverageScore.UnderlinedStyle = false;
            // 
            // frmUpdateMemberEvaluation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAverageScore);
            this.Controls.Add(this.cmbxScore);
            this.Controls.Add(this.lblMemberNameError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMemberName);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnSaveChanges);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmUpdateMemberEvaluation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMemberNameError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private SATATextBox txtMemberName;
        private System.Windows.Forms.Label lblHeading;
        private FrameworkTest.SATAButton btnSaveChanges;
        private SATAComboBox cmbxScore;
        private System.Windows.Forms.Label label4;
        private SATATextBox txtAverageScore;
    }
}