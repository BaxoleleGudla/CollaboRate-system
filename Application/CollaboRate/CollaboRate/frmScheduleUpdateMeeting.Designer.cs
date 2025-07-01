namespace CollaboRate
{
    partial class frmScheduleUpdateMeeting
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
            this.lblMeetingDescriptionError = new System.Windows.Forms.Label();
            this.lblMeetingTitleError = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeetingDescription = new SATATextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeetingTitle = new SATATextBox();
            this.lblHeading = new System.Windows.Forms.Label();
            this.btnScheduleUpdateMeeting = new FrameworkTest.SATAButton();
            this.sataDateTimePicker1 = new SATAUiFramework.Controls.SATADateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMeetingDateError = new System.Windows.Forms.Label();
            this.btnCancelMeeting = new FrameworkTest.SATAButton();
            this.SuspendLayout();
            // 
            // lblMeetingDescriptionError
            // 
            this.lblMeetingDescriptionError.AutoSize = true;
            this.lblMeetingDescriptionError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingDescriptionError.ForeColor = System.Drawing.Color.Red;
            this.lblMeetingDescriptionError.Location = new System.Drawing.Point(33, 265);
            this.lblMeetingDescriptionError.Name = "lblMeetingDescriptionError";
            this.lblMeetingDescriptionError.Size = new System.Drawing.Size(35, 16);
            this.lblMeetingDescriptionError.TabIndex = 31;
            this.lblMeetingDescriptionError.Text = "Error";
            this.lblMeetingDescriptionError.Visible = false;
            // 
            // lblMeetingTitleError
            // 
            this.lblMeetingTitleError.AutoSize = true;
            this.lblMeetingTitleError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingTitleError.ForeColor = System.Drawing.Color.Red;
            this.lblMeetingTitleError.Location = new System.Drawing.Point(34, 125);
            this.lblMeetingTitleError.Name = "lblMeetingTitleError";
            this.lblMeetingTitleError.Size = new System.Drawing.Size(35, 16);
            this.lblMeetingTitleError.TabIndex = 30;
            this.lblMeetingTitleError.Text = "Error";
            this.lblMeetingTitleError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 21);
            this.label2.TabIndex = 29;
            this.label2.Text = "Meeting Description";
            // 
            // txtMeetingDescription
            // 
            this.txtMeetingDescription.BackColor = System.Drawing.Color.White;
            this.txtMeetingDescription.BorderColor = System.Drawing.Color.DimGray;
            this.txtMeetingDescription.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtMeetingDescription.BorderRadius = 5;
            this.txtMeetingDescription.BorderSize = 1;
            this.txtMeetingDescription.Icon = null;
            this.txtMeetingDescription.IconSize = new System.Drawing.Size(20, 20);
            this.txtMeetingDescription.Location = new System.Drawing.Point(34, 168);
            this.txtMeetingDescription.Multiline = true;
            this.txtMeetingDescription.Name = "txtMeetingDescription";
            this.txtMeetingDescription.PasswordChar = false;
            this.txtMeetingDescription.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMeetingDescription.PlaceholderText = "Enter meeting description";
            this.txtMeetingDescription.Size = new System.Drawing.Size(344, 94);
            this.txtMeetingDescription.TabIndex = 28;
            this.txtMeetingDescription.Texts = "";
            this.txtMeetingDescription.UnderlinedStyle = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Meeting Title";
            // 
            // txtMeetingTitle
            // 
            this.txtMeetingTitle.BackColor = System.Drawing.Color.White;
            this.txtMeetingTitle.BorderColor = System.Drawing.Color.DimGray;
            this.txtMeetingTitle.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtMeetingTitle.BorderRadius = 5;
            this.txtMeetingTitle.BorderSize = 1;
            this.txtMeetingTitle.Icon = null;
            this.txtMeetingTitle.IconSize = new System.Drawing.Size(20, 20);
            this.txtMeetingTitle.Location = new System.Drawing.Point(35, 84);
            this.txtMeetingTitle.Multiline = false;
            this.txtMeetingTitle.Name = "txtMeetingTitle";
            this.txtMeetingTitle.PasswordChar = false;
            this.txtMeetingTitle.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMeetingTitle.PlaceholderText = "Enter meeting title";
            this.txtMeetingTitle.Size = new System.Drawing.Size(344, 39);
            this.txtMeetingTitle.TabIndex = 26;
            this.txtMeetingTitle.Texts = "";
            this.txtMeetingTitle.UnderlinedStyle = false;
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(88, 3);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(237, 23);
            this.lblHeading.TabIndex = 25;
            this.lblHeading.Text = "Schedule New Meeting";
            // 
            // btnScheduleUpdateMeeting
            // 
            this.btnScheduleUpdateMeeting.ButtonText = "Schedule Meeting";
            this.btnScheduleUpdateMeeting.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnScheduleUpdateMeeting.CheckedForeColor = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.CheckedImageTint = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnScheduleUpdateMeeting.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnScheduleUpdateMeeting.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScheduleUpdateMeeting.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnScheduleUpdateMeeting.HoverForeColor = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.HoverImage = null;
            this.btnScheduleUpdateMeeting.HoverImageTint = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.HoverOutline = System.Drawing.Color.Empty;
            this.btnScheduleUpdateMeeting.Image = null;
            this.btnScheduleUpdateMeeting.ImageAutoCenter = false;
            this.btnScheduleUpdateMeeting.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnScheduleUpdateMeeting.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnScheduleUpdateMeeting.ImageTint = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.IsToggleButton = false;
            this.btnScheduleUpdateMeeting.IsToggled = false;
            this.btnScheduleUpdateMeeting.Location = new System.Drawing.Point(210, 408);
            this.btnScheduleUpdateMeeting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnScheduleUpdateMeeting.Name = "btnScheduleUpdateMeeting";
            this.btnScheduleUpdateMeeting.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnScheduleUpdateMeeting.NormalForeColor = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.NormalOutline = System.Drawing.Color.Empty;
            this.btnScheduleUpdateMeeting.OutlineThickness = 2F;
            this.btnScheduleUpdateMeeting.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnScheduleUpdateMeeting.PressedForeColor = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.PressedImageTint = System.Drawing.Color.White;
            this.btnScheduleUpdateMeeting.PressedOutline = System.Drawing.Color.Empty;
            this.btnScheduleUpdateMeeting.Rounding = new System.Windows.Forms.Padding(5);
            this.btnScheduleUpdateMeeting.Size = new System.Drawing.Size(169, 35);
            this.btnScheduleUpdateMeeting.TabIndex = 34;
            this.btnScheduleUpdateMeeting.TextAutoCenter = true;
            this.btnScheduleUpdateMeeting.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // sataDateTimePicker1
            // 
            this.sataDateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.sataDateTimePicker1.BackgroundColor = System.Drawing.Color.White;
            this.sataDateTimePicker1.BorderColor = System.Drawing.Color.LightGray;
            this.sataDateTimePicker1.BorderThickness = 1;
            this.sataDateTimePicker1.CornerRadius = 5;
            this.sataDateTimePicker1.Location = new System.Drawing.Point(35, 311);
            this.sataDateTimePicker1.Name = "sataDateTimePicker1";
            this.sataDateTimePicker1.Size = new System.Drawing.Size(343, 28);
            this.sataDateTimePicker1.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Meeting Date";
            // 
            // lblMeetingDateError
            // 
            this.lblMeetingDateError.AutoSize = true;
            this.lblMeetingDateError.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingDateError.ForeColor = System.Drawing.Color.Red;
            this.lblMeetingDateError.Location = new System.Drawing.Point(34, 342);
            this.lblMeetingDateError.Name = "lblMeetingDateError";
            this.lblMeetingDateError.Size = new System.Drawing.Size(35, 16);
            this.lblMeetingDateError.TabIndex = 37;
            this.lblMeetingDateError.Text = "Error";
            this.lblMeetingDateError.Visible = false;
            // 
            // btnCancelMeeting
            // 
            this.btnCancelMeeting.ButtonText = "Cancel Meeting";
            this.btnCancelMeeting.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnCancelMeeting.CheckedForeColor = System.Drawing.Color.White;
            this.btnCancelMeeting.CheckedImageTint = System.Drawing.Color.White;
            this.btnCancelMeeting.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnCancelMeeting.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancelMeeting.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelMeeting.HoverBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnCancelMeeting.HoverForeColor = System.Drawing.Color.White;
            this.btnCancelMeeting.HoverImage = null;
            this.btnCancelMeeting.HoverImageTint = System.Drawing.Color.White;
            this.btnCancelMeeting.HoverOutline = System.Drawing.Color.Empty;
            this.btnCancelMeeting.Image = null;
            this.btnCancelMeeting.ImageAutoCenter = false;
            this.btnCancelMeeting.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnCancelMeeting.ImageOffset = new System.Drawing.Point(17, 0);
            this.btnCancelMeeting.ImageTint = System.Drawing.Color.White;
            this.btnCancelMeeting.IsToggleButton = false;
            this.btnCancelMeeting.IsToggled = false;
            this.btnCancelMeeting.Location = new System.Drawing.Point(34, 408);
            this.btnCancelMeeting.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnCancelMeeting.Name = "btnCancelMeeting";
            this.btnCancelMeeting.NormalBackground = System.Drawing.Color.Red;
            this.btnCancelMeeting.NormalForeColor = System.Drawing.Color.White;
            this.btnCancelMeeting.NormalOutline = System.Drawing.Color.Empty;
            this.btnCancelMeeting.OutlineThickness = 2F;
            this.btnCancelMeeting.PressedBackground = System.Drawing.Color.Red;
            this.btnCancelMeeting.PressedForeColor = System.Drawing.Color.White;
            this.btnCancelMeeting.PressedImageTint = System.Drawing.Color.White;
            this.btnCancelMeeting.PressedOutline = System.Drawing.Color.Empty;
            this.btnCancelMeeting.Rounding = new System.Windows.Forms.Padding(5);
            this.btnCancelMeeting.Size = new System.Drawing.Size(169, 35);
            this.btnCancelMeeting.TabIndex = 38;
            this.btnCancelMeeting.TextAutoCenter = true;
            this.btnCancelMeeting.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // frmScheduleUpdateMeeting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 463);
            this.Controls.Add(this.btnCancelMeeting);
            this.Controls.Add(this.lblMeetingDateError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sataDateTimePicker1);
            this.Controls.Add(this.lblMeetingDescriptionError);
            this.Controls.Add(this.lblMeetingTitleError);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeetingDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMeetingTitle);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.btnScheduleUpdateMeeting);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmScheduleUpdateMeeting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMeetingDescriptionError;
        private System.Windows.Forms.Label lblMeetingTitleError;
        private System.Windows.Forms.Label label2;
        private SATATextBox txtMeetingDescription;
        private System.Windows.Forms.Label label1;
        private SATATextBox txtMeetingTitle;
        private System.Windows.Forms.Label lblHeading;
        private FrameworkTest.SATAButton btnScheduleUpdateMeeting;
        private SATAUiFramework.Controls.SATADateTimePicker sataDateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMeetingDateError;
        private FrameworkTest.SATAButton btnCancelMeeting;
    }
}