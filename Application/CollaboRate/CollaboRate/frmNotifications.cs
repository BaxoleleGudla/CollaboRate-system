using CollaboRate.Dtos;
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
                            var item = new cntlNotificationItem();
                            item.SetNotificationData(notif);

                            // Adjust width to account for the scrollbar
                            item.Width = flpNotifications.Width - 25;

                            flpNotifications.Controls.Add(item);
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

        // Helper method to show a clean empty message
        private void ShowEmptyState(string message)
        {
            try
            {
                // UI updates should happen on the UI thread
                this.Invoke((MethodInvoker)delegate {
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
                });
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
