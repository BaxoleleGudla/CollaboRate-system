namespace CollaboRate
{
    partial class frmGroupChats
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
            this.lblHeading = new System.Windows.Forms.Label();
            this.txtSearchMessage = new SATATextBox();
            this.lstChats = new System.Windows.Forms.ListBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSendMessage = new FrameworkTest.SATAButton();
            this.txtMessage = new SATATextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(10, 31);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(76, 27);
            this.lblHeading.TabIndex = 28;
            this.lblHeading.Text = "Chats";
            // 
            // txtSearchMessage
            // 
            this.txtSearchMessage.BackColor = System.Drawing.Color.White;
            this.txtSearchMessage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.txtSearchMessage.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.txtSearchMessage.BorderRadius = 5;
            this.txtSearchMessage.BorderSize = 1;
            this.txtSearchMessage.Icon = null;
            this.txtSearchMessage.IconSize = new System.Drawing.Size(20, 20);
            this.txtSearchMessage.Location = new System.Drawing.Point(440, 27);
            this.txtSearchMessage.Multiline = false;
            this.txtSearchMessage.Name = "txtSearchMessage";
            this.txtSearchMessage.PasswordChar = false;
            this.txtSearchMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtSearchMessage.PlaceholderText = "Search message";
            this.txtSearchMessage.Size = new System.Drawing.Size(355, 39);
            this.txtSearchMessage.TabIndex = 29;
            this.txtSearchMessage.Texts = "";
            this.txtSearchMessage.UnderlinedStyle = false;
            // 
            // lstChats
            // 
            this.lstChats.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstChats.FormattingEnabled = true;
            this.lstChats.ItemHeight = 21;
            this.lstChats.Location = new System.Drawing.Point(15, 93);
            this.lstChats.Name = "lstChats";
            this.lstChats.Size = new System.Drawing.Size(780, 483);
            this.lstChats.TabIndex = 30;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnSendMessage);
            this.pnlBottom.Controls.Add(this.txtMessage);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 580);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(810, 47);
            this.pnlBottom.TabIndex = 31;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.ButtonText = "";
            this.btnSendMessage.CheckedBackground = System.Drawing.Color.DodgerBlue;
            this.btnSendMessage.CheckedForeColor = System.Drawing.Color.White;
            this.btnSendMessage.CheckedImageTint = System.Drawing.Color.White;
            this.btnSendMessage.CheckedOutline = System.Drawing.Color.DodgerBlue;
            this.btnSendMessage.CustomDialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSendMessage.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMessage.HoverBackground = System.Drawing.Color.RoyalBlue;
            this.btnSendMessage.HoverForeColor = System.Drawing.Color.White;
            this.btnSendMessage.HoverImage = null;
            this.btnSendMessage.HoverImageTint = System.Drawing.Color.White;
            this.btnSendMessage.HoverOutline = System.Drawing.Color.Empty;
            this.btnSendMessage.Image = global::CollaboRate.Properties.Resources.home;
            this.btnSendMessage.ImageAutoCenter = false;
            this.btnSendMessage.ImageExpand = new System.Drawing.Point(0, 0);
            this.btnSendMessage.ImageOffset = new System.Drawing.Point(20, 0);
            this.btnSendMessage.ImageTint = System.Drawing.Color.White;
            this.btnSendMessage.IsToggleButton = false;
            this.btnSendMessage.IsToggled = false;
            this.btnSendMessage.Location = new System.Drawing.Point(735, 6);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.NormalBackground = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(152)))), ((int)(((byte)(186)))));
            this.btnSendMessage.NormalForeColor = System.Drawing.Color.White;
            this.btnSendMessage.NormalOutline = System.Drawing.Color.Empty;
            this.btnSendMessage.OutlineThickness = 2F;
            this.btnSendMessage.PressedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.btnSendMessage.PressedForeColor = System.Drawing.Color.White;
            this.btnSendMessage.PressedImageTint = System.Drawing.Color.White;
            this.btnSendMessage.PressedOutline = System.Drawing.Color.Empty;
            this.btnSendMessage.Rounding = new System.Windows.Forms.Padding(5);
            this.btnSendMessage.Size = new System.Drawing.Size(60, 35);
            this.btnSendMessage.TabIndex = 33;
            this.btnSendMessage.TextAutoCenter = false;
            this.btnSendMessage.TextOffset = new System.Drawing.Point(0, 0);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessage.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessage.BorderFocusColor = System.Drawing.Color.WhiteSmoke;
            this.txtMessage.BorderRadius = 5;
            this.txtMessage.BorderSize = 1;
            this.txtMessage.Icon = null;
            this.txtMessage.IconSize = new System.Drawing.Size(20, 20);
            this.txtMessage.Location = new System.Drawing.Point(1, 4);
            this.txtMessage.Multiline = false;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = false;
            this.txtMessage.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.txtMessage.PlaceholderText = "Type a message";
            this.txtMessage.Size = new System.Drawing.Size(722, 39);
            this.txtMessage.TabIndex = 32;
            this.txtMessage.Texts = "";
            this.txtMessage.UnderlinedStyle = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGroupChats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 627);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.lstChats);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.txtSearchMessage);
            this.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGroupChats";
            this.Text = "frmGroupChats";
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private SATATextBox txtSearchMessage;
        private System.Windows.Forms.ListBox lstChats;
        private System.Windows.Forms.Panel pnlBottom;
        private SATATextBox txtMessage;
        private FrameworkTest.SATAButton btnSendMessage;
        private System.Windows.Forms.Button button1;
    }
}