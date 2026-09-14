using CollaboRate.Dtos;
using CollaboRate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmNotifications : Form
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string ApiBaseUrl = "https://collaborateapi.runasp.net";

        public frmNotifications()
        {
            InitializeComponent();
            // Close the dropdown if the user clicks anywhere else
            this.Deactivate += (s, e) => this.Close();

            // Wire up the Form Load and Form Closed events
            this.Load += frmNotifications_Load;
            this.FormClosed += frmNotifications_FormClosed;
        }

        private void frmNotifications_Load(object sender, EventArgs e)
        {
            // Subscribe to real-time events when form opens
            SignalRService.Instance.OnNotificationReceived += HandleRealTimeNotification;
        }

        private void frmNotifications_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Unsubscribe when form closes to prevent memory leaks
            SignalRService.Instance.OnNotificationReceived -= HandleRealTimeNotification;
        }

        public async Task InitializeNotificationsAsync(int userId, int groupId)
        {
            try
            {
                // If user has not selected any group
                if (groupId <= 0)
                {
                    pbLoadingSpinner.Visible = false;
                    ShowEmptyState("Please select a group to view notifications.");
                    return;
                }

                // Start Loading
                pbLoadingSpinner.Visible = true;
                flpNotifications.Controls.Clear();

                // Fetch Data
                string url = $"{ApiBaseUrl}/api/Notifications/user/{userId}/group/{groupId}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var notifications = JsonSerializer.Deserialize<List<NotificationDto>>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    // Clear the FlowLayoutPanel
                    flpNotifications.Controls.Clear();
                    pbLoadingSpinner.Visible = false;

                    // Dynamically add User Controls
                    if (notifications?.Any() == true)
                    {
                        foreach (var notif in notifications)
                        {
                            AddNotificationControl(notif, appendToTop: false);
                        }

                        // Mark all as read now that they are displayed
                        await MarkNotificationsAsReadAsync(userId, groupId);
                    }
                    else
                    {
                        ShowEmptyState("You're all caught up! No notifications for this group.");
                    }
                }
                else
                {
                    pbLoadingSpinner.Visible = false;
                    ShowEmptyState("Could not load notifications. Pleae try again later.");
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                ShowEmptyState("An error occurred while fetching notifications.");
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        // Method triggered whenever a real-time SignalR message arrives
        private void HandleRealTimeNotification(NotificationDto notif)
        {
            // Ensure UI thread execution
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleRealTimeNotification(notif)));
                return;
            }

            // Remove empty state label if present
            var emptyLabel = flpNotifications.Controls.OfType<Label>().FirstOrDefault();
            if (emptyLabel != null)
            {
                flpNotifications.Controls.Remove(emptyLabel);
            }

            // Prepend new real-time notification to the top of the list
            AddNotificationControl(notif, appendToTop: true);
        }

        private void AddNotificationControl(NotificationDto notif, bool appendToTop)
        {
            var item = new cntlNotificationItem();
            item.SetNotificationData(notif);
            item.Width = flpNotifications.Width - 25;

            flpNotifications.Controls.Add(item);

            if (appendToTop)
            {
                flpNotifications.Controls.SetChildIndex(item, 0);
            }
        }

        // Helper method to show a clean empty message
        private void ShowEmptyState(string message)
        {
            try
            {
                // UI updates should happen on the UI thread
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate { ShowEmptyState(message); });
                    return;
                }

                flpNotifications.Controls.Clear();

                Label lblEmpty = new Label
                {
                    Text = message,
                    ForeColor = Color.Gray,
                    Font = new Font("Century Gothic", 10, FontStyle.Italic),
                    TextAlign = ContentAlignment.MiddleCenter,

                    Width = flpNotifications.Width - 10,
                    Height = 150,
                    Margin = new Padding(0, 50, 0, 0)
                };

                flpNotifications.Controls.Add(lblEmpty);
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private async Task MarkNotificationsAsReadAsync(int userId, int groupId)
        {
            try
            {
                string url = $"{ApiBaseUrl}/api/Notifications/mark-all-read/user/{userId}/group/{groupId}";
                await client.PutAsync(url, null);
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void frmNotifications_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.Clear(Color.White);

                using (Pen p = new Pen(Color.FromArgb(0, 120, 140), 2))
                {
                    e.Graphics.DrawRectangle(p, 1, 1, this.Width - 3, this.Height - 3);
                }
            }
            catch (Exception ex)
            {
                ;
            } 
        }
    }
}
