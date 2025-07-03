using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource pendingUsersBindingSource = new BindingSource();
        private BindingSource groupsBindingSource = new BindingSource();

        public frmProjectGroups()
        {
            InitializeComponent();
        }

        private void btnCreateNewGroup_Click(object sender, EventArgs e)
        {
            frmCreateNewGroup createNewGroupForm = new frmCreateNewGroup();
            createNewGroupForm.ShowDialog();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            frmEditGroup editGroupForm = new frmEditGroup();
            editGroupForm.ShowDialog();
        }

        // Method to get group details
        public async Task<AcceptedGroupUsersDto> GetGroupDetailsAsync(int groupId)
        {
            string apiUrl = $"https://localhost:7287/api/groups/{groupId}/details-with-accepted-users";

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
                MessageBox.Show("The request timed out. Please try again later.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (HttpRequestException ex)
            {
                // Network or HTTP error
                MessageBox.Show("Request failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Method to get users with a pending join request
        public async Task<List<PendingUserDto>> GetPendingUsersAsync(int groupId)
        {
            string apiUrl = $"https://localhost:7287/api/groups/{groupId}/pending-users";

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
                MessageBox.Show("Network error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out. Please try again.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Method to get groups
        private async Task<List<GroupWithRequestStatusDto>> GetAvailableGroupsForUserAsync(int userId)
        {
            string apiUrl = $"https://localhost:7287/api/groups/available-groups?userId={userId}";

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
                MessageBox.Show("Network error while fetching groups: " + httpEx.Message, "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out while fetching groups. Please try again.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while fetching groups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        // Method to display the group details
        private async Task LoadGroupDetailsAsync()
        {
            if (CurrentGroup.Group_ID >= 1)
            {
                pbLoadingSpinner.Visible = true;

                var groupDetailsTask = GetGroupDetailsAsync(CurrentGroup.Group_ID);

                try
                {
                    var groupDetails = await groupDetailsTask;

                    if (groupDetails != null)
                    {
                        lblGroupName.Text = groupDetails.Group_Name;
                        lblGroupDescription.Text = groupDetails.Group_Description;
                        lblNumOfMembers.Text = groupDetails.Accepted_User_Count.ToString() + " Member(s)";

                        foreach (var user in groupDetails.Accepted_Users)
                        {
                            //MessageBox.Show(user.User_ID + " " + user.Username + " " + user.User_Role);
                        }
                    }
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    MessageBox.Show("Error: " + ex.Message, "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    pbLoadingSpinner.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("No group selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to dsplay join requests
        private async Task LoadJoinRequetsAsync()
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
                    MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No group selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Method to display groups in a datagridview
        private async Task LoadGroupsAsync(int userId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewProjectGroups.Enabled = false;

                var groups = await GetAvailableGroupsForUserAsync(userId);

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
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Fix spinner logic for these methods
            // Display data
            var groupDetailsTask = LoadGroupDetailsAsync();
            var joinRequestsTask = LoadJoinRequetsAsync();
            var groupsTask = LoadGroupsAsync(CurrentUser.User_ID);

            await Task.WhenAll(groupDetailsTask, joinRequestsTask, groupsTask);
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

                string url = $"https://localhost:7287/api/Groups/{groupId}/join-requests/{userId}";

                // Send POST request
                HttpResponseMessage response = await client.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Failed to send join request: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string url = $"https://localhost:7287/api/Groups/{groupId}/join-requests/{userId}";

                // Send DELETE request
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Failed to cancel join request: " + error, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewProjectGroups.Enabled = true;
                MessageBox.Show("Could not cancel join request: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        group.HasPendingRequest = false;
                        dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        MessageBox.Show("Request cancelled", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    bool success = await SendJoinRequestAsync(group.Group_ID, CurrentUser.User_ID);

                    if (success)
                    {
                        group.HasPendingRequest = true;
                        dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                        MessageBox.Show("Request sent", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // Method to accept a user to a group
        private async Task<bool> AcceptUserToGroup(int groupId, int userId)
        {
            try
            {
                string url = $"https://localhost:7287/api/Groups/{groupId}/members/{userId}/accept";
                var response = await client.PutAsync(url, null);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Network error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out or was canceled.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }

        // Method to reject a user from joining the group
        private async Task<bool> RejectUserFromGroup(int groupId, int userId)
        {
            try
            {
                string url = $"https://localhost:7287/api/Groups/{groupId}/members/{userId}/reject";
                var response = await client.DeleteAsync(url);

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Network error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Request timed out or was canceled.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        if (success == true)
                        {
                            await LoadJoinRequetsAsync();
                            pbLoadingSpinner.Visible = false;
                            dgViewJoinRequests.Enabled = true;
                            MessageBox.Show("User accepted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (column.Name == "RejectRequest")
                    {
                        bool success = await RejectUserFromGroup(groupId, userId);

                        if (success == true)
                        {
                            await LoadJoinRequetsAsync();
                            pbLoadingSpinner.Visible = false;
                            dgViewJoinRequests.Enabled = true;
                            MessageBox.Show("User rejected successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    dgViewJoinRequests.Enabled = true;
                    MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewJoinRequests.Enabled = true;
            }
        }
    }
}
