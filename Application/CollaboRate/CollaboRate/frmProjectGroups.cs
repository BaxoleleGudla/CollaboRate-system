using CollaboRate.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmProjectGroups : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource pendingUsersBindingSource = new BindingSource();
        private BindingSource groupsBindingSource = new BindingSource();
        private AcceptedGroupUsersDto _currentGroupDetails;

        // SignalR fields
        private HubConnection _connection;

        public frmProjectGroups()
        {
            InitializeComponent();

            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    btnEditGroup.Visible = true;

                    if (dgViewJoinRequests.Rows.Count > 0)
                    {
                        pnlMiddle.Visible = true;
                    }
                }
            }
        }

        // Initialize SignalR connection
        private async void InitializeSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://collaborateapi.runasp.net/chathub")
                .WithAutomaticReconnect()
                .Build();

            // Listen for updates from the server
            _connection.On<List<PendingUserDto>>("RefreshPendingList", (newList) =>
            {
                this.Invoke(new Action(() => {
                    // 1. Refresh the data source
                    pendingUsersBindingSource.DataSource = newList;
                    dgViewJoinRequests.DataSource = pendingUsersBindingSource;

                    // 2. IMPORTANT: Force the panel visibility based on the new list
                    // and check if the user is an admin before showing it
                    bool isAdmin = CurrentUser.Group_Role != null && CurrentUser.Group_Role.Contains("Admin");
                    pnlMiddle.Visible = (isAdmin && newList.Count > 0);
                }));
            });

            try
            {
                await _connection.StartAsync();

                // Subscribe to the group that was JUST selected in the frmMain ComboBox
                if (CurrentGroup.Group_ID > 0)
                {
                    await _connection.InvokeAsync("SubscribeToGroupUpdates", CurrentGroup.Group_ID);
                }
            }
            catch (Exception ex)
            {
                // Fallback: If SignalR fails, the user still sees the initial data from the standard Load method
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while establishing real-time connection.", Properties.Resources.Error_Icon);
            }
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
                MessageBox.Show(ex.Message, "Warinng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCreateNewGroup_Click(object sender, EventArgs e)
        {
            frmCreateNewGroup createNewGroupForm = new frmCreateNewGroup();
            createNewGroupForm.ShowDialog();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            var editGroupForm = new frmEditGroup(_currentGroupDetails);
            editGroupForm.ShowDialog();
        }

        // Method to get group details
        public async Task<AcceptedGroupUsersDto> GetGroupDetailsAsync(int groupId)
        {
            string apiUrl = $"https://collaborateapi.runasp.net/api/groups/{groupId}/details-with-accepted-users";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var groupDetails = JsonSerializer.Deserialize<AcceptedGroupUsersDto>(jsonString, options);

                return groupDetails;
            }
            catch (TaskCanceledException ex) when (!ex.CancellationToken.IsCancellationRequested)
            {
                // Timeout occurred
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Timeout", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
                return null;
            }
            catch (HttpRequestException ex)
            {
                // Network or HTTP error
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "A network error occurred while loading group details.", Properties.Resources.Error_Icon);
                return null;
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading group details.", Properties.Resources.Error_Icon);
                return null;
            }
        }

        // Method to get users with a pending join request
        public async Task<List<PendingUserDto>> GetPendingUsersAsync(int groupId)
        {
            string apiUrl = $"https://collaborateapi.runasp.net/api/groups/{groupId}/pending-users";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var pendingUsers = JsonSerializer.Deserialize<List<PendingUserDto>>(jsonString, options);

                return pendingUsers;
            }
            catch (HttpRequestException ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while getting pending join requests.", Properties.Resources.Error_Icon);
                return null;
            }
            catch (TaskCanceledException)
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Timeout", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
                return null;
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while getting pending join requests.", Properties.Resources.Error_Icon);
                return null;
            }
        }

        // Method to get groups
        public async Task<List<GroupWithRequestStatusDto>> GetAvailableGroupsForUserAsync(int userId, string keyword = null)
        {
            string apiUrl = $"https://collaborateapi.runasp.net/api/groups/available-groups?userId={userId}&keyword={keyword}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                return JsonSerializer.Deserialize<List<GroupWithRequestStatusDto>>(jsonString, options);
            }
            catch (HttpRequestException httpEx)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "A network error occurred while loading groups.", Properties.Resources.Error_Icon);
            }
            catch (TaskCanceledException)
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Timeout", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading groups.", Properties.Resources.Error_Icon);
            }

            return null;
        }

        // Method to display the group details
        public async Task LoadGroupDetailsAsync()
        {
            if (CurrentGroup.Group_ID >= 1)
            {
                pbLoadingSpinner.Visible = true;

                try
                {
                    _currentGroupDetails = await GetGroupDetailsAsync(CurrentGroup.Group_ID);

                    if (_currentGroupDetails != null)
                    {
                        lblGroupName.Text = _currentGroupDetails.Group_Name;
                        lblNumOfMembers.Text = _currentGroupDetails.Accepted_User_Count.ToString() + " Member(s)";

                        if (string.IsNullOrEmpty(_currentGroupDetails.Group_Description) == true)
                        {
                            lblGroupDescription.Text = "No description.";
                        }
                        else
                        {
                            lblGroupDescription.Text = _currentGroupDetails.Group_Description;
                        }
                    }
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying group details.", Properties.Resources.Error_Icon);
                }
                finally
                {
                    pbLoadingSpinner.Visible = false;
                }
            }
            else
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "No group selected.", Properties.Resources.Warning_Icon);
            }
        }

        // Method to dsplay join requests (with signalR)
        public async Task LoadJoinRequetsAsync()
        {
            if (CurrentGroup.Group_ID >= 1)
            {
                var pendingUsersTask = GetPendingUsersAsync(CurrentGroup.Group_ID);

                try
                {
                    var pendingUsers = await pendingUsersTask;

                    if (pendingUsers != null)
                    {
                        // Bind the list to the binding source
                        pendingUsersBindingSource.DataSource = pendingUsers;

                        // Set the BindingSource as teh datagridview's datasource
                        dgViewJoinRequests.DataSource = pendingUsersBindingSource;
                    }
                }
                catch (Exception ex)
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying join requests.", Properties.Resources.Error_Icon);
                }
            }
            else
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "No group selected.", Properties.Resources.Warning_Icon);
            }
        }

        // Method to display groups in a datagridview
        public async Task LoadGroupsAsync(int userId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewProjectGroups.Enabled = false;

                var groups = await GetAvailableGroupsForUserAsync(userId, keyword);

                if (groups != null)
                {
                    groupsBindingSource.DataSource = groups;
                    dgViewProjectGroups.AutoGenerateColumns = false;
                    dgViewProjectGroups.DataSource = groupsBindingSource;
                }
                else
                {
                    groupsBindingSource.DataSource = null;
                    dgViewProjectGroups.DataSource = groupsBindingSource;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying groups.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
            }
        }

        // Form load event
        private async void frmProjectGroups_Load(object sender, EventArgs e)
        {
            InitializeSignalR();

            // Display data
            var groupDetailsTask = LoadGroupDetailsAsync();
            var joinRequestsTask = LoadJoinRequetsAsync();
            var groupsTask = LoadGroupsAsync(CurrentUser.User_ID);

            await Task.WhenAll(groupDetailsTask, joinRequestsTask, groupsTask);

            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    btnEditGroup.Visible = true;

                    if (dgViewJoinRequests.Rows.Count > 0)
                    {
                        pnlMiddle.Visible = true;
                    }
                }
            }
        }

        private void dgViewProjectGroups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgViewProjectGroups.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                var group = dgViewProjectGroups.Rows[e.RowIndex].DataBoundItem as GroupWithRequestStatusDto;

                if (group != null)
                {
                    string buttonText = group.HasPendingRequest ? "Cancel Request" : "Request To Join";
                    e.Value = buttonText;
                    e.FormattingApplied = true;
                }
            }
        }

        // Method to send a join request
        private async Task<bool> SendJoinRequestAsync(int groupId, int userId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewProjectGroups.Enabled = false;

                string url = $"https://collaborateapi.runasp.net/api/Groups/{groupId}/join-requests/{userId}";

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                string error = await response.Content.ReadAsStringAsync();
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to send join request.", Properties.Resources.Error_Icon);

                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while sending join request.", Properties.Resources.Error_Icon);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
            }
        }

        // Method to cancel a join request
        private async Task<bool> CancelJoinRequestAsync(int groupId, int userId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewProjectGroups.Enabled = false;

                string url = $"https://collaborateapi.runasp.net/api/Groups/{groupId}/join-requests/{userId}";

                // Send DELETE request
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                string error = await response.Content.ReadAsStringAsync();
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to cancel join request.", Properties.Resources.Error_Icon);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while cancelling join request.", Properties.Resources.Error_Icon);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
            }
        }

        private async void dgViewProjectGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;

            // Validate indexes and check if button column is clicked
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }


            if (dgViewProjectGroups.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Get the bound data item for the clicked row
                var group = dgv.Rows[e.RowIndex].DataBoundItem as GroupWithRequestStatusDto;

                if (group == null)
                {
                    return;
                }

                if (group.HasPendingRequest)
                {
                    bool success = await CancelJoinRequestAsync(group.Group_ID, CurrentUser.User_ID);

                    if (success)
                    {
                        //group.HasPendingRequest = false;
                        //dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        await LoadGroupsAsync(CurrentUser.User_ID);
                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Join request cancelled.", Properties.Resources.Success_Icon);
                    }
                }
                else
                {
                    bool success = await SendJoinRequestAsync(group.Group_ID, CurrentUser.User_ID);

                    if (success)
                    {
                        //group.HasPendingRequest = true;
                        //dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        await LoadGroupsAsync(CurrentUser.User_ID);
                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Join request sent.", Properties.Resources.Success_Icon);
                    }
                }
            }
        }

        // Method to accept a user to a group
        private async Task<bool> AcceptUserToGroup(int groupId, int userId)
        {
            try
            {
                string url = $"https://collaborateapi.runasp.net/api/Groups/{groupId}/members/{userId}/accept";
                var response = await client.PutAsync(url, null);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while accepting member.", Properties.Resources.Error_Icon);
            }
            catch (TaskCanceledException)
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Timeout", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while accepting member.", Properties.Resources.Error_Icon);
            }

            return false;
        }

        // Method to reject a user from joining the group
        private async Task<bool> RejectUserFromGroup(int groupId, int userId)
        {
            try
            {
                string url = $"https://collaborateapi.runasp.net/api/Groups/{groupId}/members/{userId}/reject";
                var response = await client.DeleteAsync(url);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while rejecting member.", Properties.Resources.Error_Icon);
            }
            catch (TaskCanceledException)
            {
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occorred while rejecting member.", Properties.Resources.Error_Icon);
            }
            return false;
        }

        private async void dgViewJoinRequests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewJoinRequests.Enabled = false;

                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return; // Ignore header clicks
                }

                var dgv = sender as DataGridView;

                // Check if clicked column is Accept or Reject button column
                var column = dgv.Columns[e.ColumnIndex];

                // Get the user ID from the clicked row
                int userId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["User_ID"].Value);
                int groupId = CurrentGroup.Group_ID;

                try
                {
                    if (column.Name == "AcceptRequest")
                    {
                        bool success = await AcceptUserToGroup(groupId, userId);

                        // Refresh group details with new user count
                        await LoadGroupDetailsAsync();

                        if (success == true)
                        {
                            //await LoadJoinRequetsAsync();
                            pbLoadingSpinner.Visible = false;
                            dgViewJoinRequests.Enabled = true;
                            AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "User accepted.", Properties.Resources.Success_Icon);
                        }
                    }
                    else if (column.Name == "RejectRequest")
                    {
                        bool success = await RejectUserFromGroup(groupId, userId);

                        if (success == true)
                        {
                            //await LoadJoinRequetsAsync();
                            pbLoadingSpinner.Visible = false;
                            dgViewJoinRequests.Enabled = true;
                            AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "User rejected.", Properties.Resources.Success_Icon);
                        }
                    }
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    dgViewJoinRequests.Enabled = true;
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "An unexpected error occurred.", Properties.Resources.Error_Icon);
                }
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewJoinRequests.Enabled = true;
            }
        }

        private async void txtSearchGroup__TextChanged(object sender, EventArgs e)
        {
            await LoadGroupsAsync(CurrentUser.User_ID, txtSearchGroup.Texts);
        }

        private async void frmProjectGroups_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_connection != null)
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
        }

        private void frmProjectGroups_Resize(object sender, EventArgs e)
        {
            // Force specific controls to redraw
            pnlTop.Invalidate();
            pnlMiddle.Invalidate();
            pnlBottom.Invalidate();
            pnlCurrentGroup.Invalidate();
            txtSearchGroup.Invalidate();

            if (pbLoadingSpinner != null)
            {
                // Calculate center: (Parent Width / 2) - (Control Width / 2)
                int x = (this.ClientSize.Width - pbLoadingSpinner.Width) / 2;
                int y = (this.ClientSize.Height - pbLoadingSpinner.Height) / 2;

                pbLoadingSpinner.Location = new Point(x, y);
            }
        }
    }
}
