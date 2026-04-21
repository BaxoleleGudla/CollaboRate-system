using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class cntlNotificationItem : UserControl
    {
        private bool _isRead;

        public cntlNotificationItem()
        {
            InitializeComponent();

            // Make the control feel interactive
            this.Cursor = Cursors.Hand;

            // Route label events to the UserControl events
            lblMessage.MouseEnter += (s, e) => cntlNotificationItem_MouseEnter(s, e);
            lblMessage.MouseLeave += (s, e) => cntlNotificationItem_MouseLeave(s, e);
            lblTime.MouseEnter += (s, e) => cntlNotificationItem_MouseEnter(s, e);
            lblTime.MouseLeave += (s, e) => cntlNotificationItem_MouseLeave(s, e);
        }

        public void SetNotificationData(NotificationDto data)
        {
            lblMessage.Text = data.Message;
            lblTime.Text = FormatTimeAgo(data.Created_At);

            _isRead = data.IsRead;

            UpdateBackgroundColor();
        }

        private void UpdateBackgroundColor()
        {
            // Use the stored _isRead field
            this.BackColor = _isRead ? Color.White : Color.FromArgb(242, 252, 255);
        }

        private string FormatTimeAgo(DateTime date)
        {
            // Using UtcNow because DB uses SYSUTCDATETIME()
            var span = DateTime.UtcNow - date;

            if (span.TotalSeconds < 60)
                return "Just now";

            if (span.TotalMinutes < 60)
                return $"{(int)span.TotalMinutes}m ago";

            if (span.TotalHours < 24)
                return $"{(int)span.TotalHours}h ago";

            if (span.TotalDays < 7)
                return $"{(int)span.TotalDays}d ago";

            if (span.TotalDays < 30)
            {
                int weeks = (int)(span.TotalDays / 7);
                return $"{weeks}w ago";
            }

            if (span.TotalDays < 365)
            {
                int months = (int)(span.TotalDays / 30);
                return $"{months}mo ago";
            }

            int years = (int)(span.TotalDays / 365);
            return $"{years}y ago";
        }

        private void cntlNotificationItem_Paint(object sender, PaintEventArgs e)
        {
            // Draw the Teal Bar in the 5px padding 
            using (SolidBrush tealBrush = new SolidBrush(Color.FromArgb(0, 150, 170)))
            {
                // Draw it exactly 4 pixels wide
                e.Graphics.FillRectangle(tealBrush, 0, 0, 4, this.Height);
            }

            // Draw the separator line in the 1px bottom padding
            using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
            {
                e.Graphics.DrawLine(pen, 5, this.Height - 1, this.Width, this.Height - 1);
            }
        }

        private void cntlNotificationItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(245, 245, 245); // Light hover gray
        }

        private void cntlNotificationItem_MouseLeave(object sender, EventArgs e)
        {
            UpdateBackgroundColor();
        }
    }
}
