using CollaboRate.Dtos;
using CollaboRate.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmMain : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient();

        public frmMain()
        {
            InitializeComponent();
            openChildForm(new frmHome());
        }

        // Method for the toast form
        public void AlertBox(Color backColor, Color color, string title, string text, Image icon)
        {
            try
            {
                frmAlertBox alertBoxForm = new frmAlertBox();
                alertBoxForm.BackColor = backColor;
                alertBoxForm.ColorAlertBox = color;
                alertBoxForm.TitleAlertBox = title;
                alertBoxForm.TextAlertBox = text;
                alertBoxForm.IconAlertBox = icon;

                alertBoxForm.Show(this);
            }
            catch (Exception ex)
            {
                // Do nothing
                ;
            }
        }

        // Method to load groups
        public async Task LoadUserGroupsAsync(int userId)
        {
            try
            {
                string apiUrl = $"https://collaborateapi.runasp.net/api/Groups/user/{userId}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var groups = JsonSerializer.Deserialize<List<GroupDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                 
                    if (groups != null && groups.Count > 0)
                    {
                        // Save the currently selected groups's ID (if any)
                        var selectedGroupId = cmbxCurrentGroup.SelectedValue;

                        // Temporarily unsubscribe from the SelectedIndexChanged event
                        cmbxCurrentGroup.SelectedIndexChanged -= cmbxCurrentGroup_SelectedIndexChanged;

                        cmbxCurrentGroup.DataSource = groups;
                        cmbxCurrentGroup.DisplayMember = "Group_Name";
                        cmbxCurrentGroup.ValueMember = "Group_ID";

                        // Try to restore the previous selection
                        if (selectedGroupId != null && groups.Any(g => g.Group_ID.Equals(selectedGroupId)))
                        {
                            cmbxCurrentGroup.SelectedValue = selectedGroupId;
                        }
                        else
                        {
                            cmbxCurrentGroup.SelectedIndex = -1;
                        }

                        // Re-subscribe to the event 
                        cmbxCurrentGroup.SelectedIndexChanged += cmbxCurrentGroup_SelectedIndexChanged;
                    }
                    else
                    {
                        AlertBox(Color.LightBlue, Color.DodgerBlue, "Information", "You do not belong to any groups.", Properties.Resources.Information_Icon);
                        cmbxCurrentGroup.DataSource = null;
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // New user, do nothing
                }
                else
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to load groups.", Properties.Resources.Error_Icon);
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while loading groups.", Properties.Resources.Error_Icon);
            }
        }

        private Form activeForm = null;

        // Method to open a form
        private void openChildForm(Form childForm)
        {
            try
            {
                // If the active form is the same type as the requested form, do nothing
                if (activeForm != null && activeForm.GetType() == childForm.GetType())
                {
                    activeForm.BringToFront();
                    return;
                }

                // Close and dispose the current active form if any
                if (activeForm != null)
                {
                    activeForm.Close();
                    activeForm.Dispose();
                }

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.Dock = DockStyle.Fill;

                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(childForm);
                pnlMain.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while opening chiled form.", Properties.Resources.Error_Icon);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHome());
        }

        private void btnProjectGroups_Click(object sender, EventArgs e)
        {
            openChildForm(new frmProjectGroups());
        }

        private void btnMemberEvaluations_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMemberEvaluations());
        }

        private void btnGroupTasks_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupTasks());
        }

        private void btnGroupMeetings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupMeetings());
        }

        private void btnGroupChats_Click(object sender, EventArgs e)
        {
            frmGroupChats groupChatsForm = new frmGroupChats();
            groupChatsForm.txtMessage.PlaceholderText = "Type a message";
            openChildForm(groupChatsForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSettings());
        }

        // Method to load notification preferences from API
        public async Task<bool> LoadUserSettingsAsync(int userId)
        {
            try
            {
                string url = $"{ApiBaseUrl}/api/UserSettings/{userId}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStreamAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var settings = JsonSerializer.Deserialize<UserSettingsDto>(json, options);

                    if (settings != null)
                    {
                        UserSettings.Enable_Push_Notifications = settings.Enable_Push_Notifications;
                        UserSettings.Enable_Email_Notifications = settings.Enable_Email_Notifications;
                    }
                    return true;
                }
                else
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to load notification settings.", Properties.Resources.Error_Icon);
                    return false;
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while loading settings.", Properties.Resources.Error_Icon);
                return false;
            }
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await LoadUserGroupsAsync(CurrentUser.User_ID);
            openChildForm(new frmHome());

            var session = SecureStorageService.LoadSession();
            if (session != null && session.LastGroupId > 0)
            {
                // Restore selected group UI state
                cmbxCurrentGroup.SelectedValue = session.LastGroupId;
            }

            // Subscribe main form to real-time notifications
            SignalRService.Instance.OnNotificationReceived += HandleRealTimeNotificationOnMain;

            // Check unread status on startup
            await CheckUnreadNotificationsAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);

            // Load user notification preferences from API
            await LoadUserSettingsAsync(CurrentUser.User_ID);
        }

        // Method to get the role of a user
        public async Task<string> GetUserGroupRoleAsync(int userId, int groupId)
        {
            try
            {
                string url = $"{ApiBaseUrl}/api/Groups/users/{userId}/groups/{groupId}/role";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<UserRoleResponseDto>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return result?.User_Role ?? "NoRole";
                }

                return "NoRole";
            }
            catch (Exception ex)
            {
                return "Error getting user role";
            }
        }

        // Method to refresh data on the form when the group is changed
        public async Task RefreshDisplayedFormData()
        {
            // Store teh type fo the active form
            Type activeFormType = activeForm?.GetType();

            if (activeForm != null && activeFormType != typeof(frmSettings))
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

            // Instantiate and open a brand new form of the same type
            Form formToOpen = null;

            if (activeFormType == typeof(frmHome))
            {
                formToOpen = new frmHome();
            }
            else if (activeFormType == typeof(frmProjectGroups))
            {
                formToOpen = new frmProjectGroups();
            }
            else if (activeFormType == typeof(frmMemberEvaluations))
            {
                formToOpen = new frmMemberEvaluations();
            }
            else if (activeFormType == typeof(frmGroupTasks))
            {
                formToOpen = new frmGroupTasks();
            }
            else if (activeFormType == typeof(frmGroupMeetings))
            {
                formToOpen = new frmGroupMeetings();
            }
            else if (activeFormType == typeof(frmGroupChats))
            {
                formToOpen = new frmGroupChats();
            }

            // Open the new form instance
            if (formToOpen != null)
            {
                openChildForm(formToOpen);
            }
        }

        private async void cmbxCurrentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((cmbxCurrentGroup.SelectedIndex == -1))
                {
                    AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "No group selected.", Properties.Resources.Warning_Icon);
                }
                else
                {
                    CurrentGroup.Group_ID = Convert.ToInt32(cmbxCurrentGroup.SelectedValue.ToString());
                    CurrentGroup.Group_Name = cmbxCurrentGroup.Text;
                    CurrentUser.Group_Role = await GetUserGroupRoleAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);

                    await RefreshDisplayedFormData();

                    // Refresh unread indicator for the selected group
                    await CheckUnreadNotificationsAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while changing groups.", Properties.Resources.Error_Icon);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Cleare local encrypted storage
            SecureStorageService.ClearSession();

            CurrentGroup.Group_ID = 0;
            CurrentGroup.Group_Name = null;
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hIImd, int wMsg, int wParam, int lParam);

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pnlLogo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void btnNotification_Click(object sender, EventArgs e)
        {
            frmNotifications notifForm = new frmNotifications();

            // Set StartPosition to Manual so our coordinates are respected
            notifForm.StartPosition = FormStartPosition.Manual;

            // Calculate the screen location of the notification button
            // PointToScreen(Point.Empty) gets the top-left corner of the button
            Point screenPoint = btnNotification.PointToScreen(Point.Empty);

            // 3. Align the RIGHT edge of the form with the RIGHT edge of the button
            // This prevents the form from bleeding off the left side of the screen
            int x = screenPoint.X + btnNotification.Width - notifForm.Width;
            int y = screenPoint.Y + btnNotification.Height + 2;

            notifForm.Location = new Point(x, y);

            // Reset the main form icon once the notification window closes (after reading)
            notifForm.FormClosed += async (s, args) =>
            {
                await CheckUnreadNotificationsAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);
            };

            notifForm.Show();

            // Load data dynamically
            await notifForm.InitializeNotificationsAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            btnNotification.Image = Properties.Resources.Notifications_icon__with_notifications_;
            AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Operation completed successfully.", Properties.Resources.Success_Icon);
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            AlertBox(Color.LightPink, Color.DarkRed, "Error", "Operation encountered a problem.", Properties.Resources.Error_Icon);
        }

        private void btnWarning_Click(object sender, EventArgs e)
        {
            AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Are you confident in the operation.", Properties.Resources.Warning_Icon);
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            AlertBox(Color.LightBlue, Color.DodgerBlue, "Information", "Operation is in progress.", Properties.Resources.Information_Icon);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Unsubsribe to prevent memory leaks
            SignalRService.Instance.OnNotificationReceived -= HandleRealTimeNotificationOnMain;
        }

        // Method to check for unread notifications
        public async Task CheckUnreadNotificationsAsync(int userId, int groupId)
        {
            if (groupId <= 0)
            {
                btnNotification.Image = Properties.Resources.Notifications_icon__no_notifications_;
                return;
            }

            try
            {
                string url = $"{ApiBaseUrl}/api/Notifications/unread-count/user/{userId}/group/{groupId}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    using (var doc = JsonDocument.Parse(json))
                    {
                        bool hasUnread = doc.RootElement.GetProperty("hasUnread").GetBoolean();

                        UpdateNotificationIcon(hasUnread);
                    }
                }
            }
            catch (Exception ex)
            {
                // Fallback to default icon on failure
                UpdateNotificationIcon(false);
            }
        }

        // Dynamic update when real-time SignalR messages lands
        private void HandleRealTimeNotificationOnMain(NotificationDto notif)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HandleRealTimeNotificationOnMain(notif)));
                return;
            }

            // Immediately change icon when a new push notification arrives
            UpdateNotificationIcon(hasUnread: true);
        }

        // Method to toggle notification icon states
        private void UpdateNotificationIcon(bool hasUnread)
        {
            if (hasUnread)
            {
                btnNotification.Image = Properties.Resources.Notifications_icon__with_notifications_;
            }
            else
            {
                btnNotification.Image = Properties.Resources.Notifications_icon__no_notifications_;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Persist active group on exit
            var session = SecureStorageService.LoadSession();
            if (session != null)
            {
                session.LastGroupId = CurrentGroup.Group_ID;
                session.LastGroupName = CurrentGroup.Group_Name;
                SecureStorageService.SaveSession(session);
            }
        }
    }
}
