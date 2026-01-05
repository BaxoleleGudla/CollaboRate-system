using CollaboRate.Dtos;
using CollaboRate.Properties;
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
    public partial class frmHome : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource pendingUsersBindingSource = new BindingSource();
        private BindingSource groupsBindingSource = new BindingSource();
        private AcceptedGroupUsersDto _currentGroupDetails;

        // List to store all users
        private List<GroupUserDto> _allUsers;

        private BindingSource meetingsBindingSource = new BindingSource();
        private BindingSource tasksBindingSource = new BindingSource();
        private BindingSource ratingsBindingSource = new BindingSource();

        public frmHome()
        {
            InitializeComponent();

            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    dgViewMembers.Columns["RemoveMember"].Visible = true;
                }
            }
        }

        // Method for the toast form
        public void AlertBox(Color backColor, Color color, string title, string text, Image icon)
        {
            frmAlertBox alertBoxForm = new frmAlertBox();
            alertBoxForm.BackColor = backColor;
            alertBoxForm.ColorAlertBox = color;
            alertBoxForm.TitleAlertBox = title;
            alertBoxForm.TextAlertBox = text;
            alertBoxForm.IconAlertBox = icon;

            alertBoxForm.Show(this);
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

        // Method to display the group members
        public async Task LoadGroupMembersAsync()
        {
            if (CurrentGroup.Group_ID >= 1)
            {
                pbLoadingSpinner.Visible = true;

                try
                {
                    _currentGroupDetails = await GetGroupDetailsAsync(CurrentGroup.Group_ID);

                    if (_currentGroupDetails != null)
                    {
                        // Store full user list for filtering
                        _allUsers = _currentGroupDetails.Accepted_Users.ToList();

                        dgViewMembers.AutoGenerateColumns = false;

                        lblProjectGroupName.Text = _currentGroupDetails.Group_Name + " (" + _currentGroupDetails.Accepted_User_Count + " members)";

                        dgViewMembers.DataSource = new BindingList<GroupUserDto>(_allUsers);
                    }
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading group members.", Properties.Resources.Error_Icon);
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

        // Method to get meetings
        private async Task<List<MeetingDto>> GetMeetingsAsync(int groupId, string keyword = null)
        {
            string url = $"https://collaborateapi.runasp.net/api/Meetings/group/{groupId}";

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                url += $"?keyword={Uri.EscapeDataString(keyword)}";
            }

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<MeetingDto>();
            }

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var meetings = JsonSerializer.Deserialize<List<MeetingDto>>(json, options);

            return meetings ?? new List<MeetingDto>();
        }

        // Method to display upcoming meetings
        public async Task DisplayUpcomingMeetingsAsync(int groupId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var meetings = await GetMeetingsAsync(groupId, keyword);

                if (meetings != null)
                {
                    // Filter to only upcoming meetings
                    var upcomingMeetings = meetings.Where(m => m.Meeting_Date > DateTime.Now).ToList();

                    if (upcomingMeetings.Count > 0)
                    {
                        lblUpcomingMeetings.Visible = false;
                        meetingsBindingSource.DataSource = upcomingMeetings;
                        dgViewMeetings.AutoGenerateColumns = false;
                        dgViewMeetings.DataSource = meetingsBindingSource;
                    }
                    else
                    {
                        lblUpcomingMeetings.Visible = true;
                    }
                }
                else
                {
                    meetingsBindingSource.DataSource = null;
                    dgViewMeetings.DataSource = meetingsBindingSource;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading meetings.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        // Method to load tasks
        private async Task<List<TaskWithUsersDto>> GetTasksAsync(int groupId, int? userId = null, string keyword = null)
        {
            var queryParams = new List<string>();

            queryParams.Add($"group_ID={groupId}");

            if (userId.HasValue && userId.Value > 0)
            {
                queryParams.Add($"user_ID={userId.Value}");
            }

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                queryParams.Add($"keyword={Uri.EscapeDataString(keyword)}");
            }

            string queryString = string.Join("&", queryParams);

            string url = $"https://collaborateapi.runasp.net/api/Tasks/tasks/by-group?{queryString}";

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<TaskWithUsersDto>();
            }

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var tasks = JsonSerializer.Deserialize<List<TaskWithUsersDto>>(json, options);

            return tasks ?? new List<TaskWithUsersDto>();
        }

        // Method to display upcoming tasks
        public async Task DisplayUpcomingTasksAsync(int groupId, int? userId = null, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var tasks = await GetTasksAsync(groupId);

                if (tasks != null)
                {
                    // Filter to only upcoming tasks
                    var upcomingTasks = tasks.Where(t => t.Deadline > DateTime.Now).ToList();

                    if (upcomingTasks.Count > 0)
                    {
                        lblUpcomingTasks.Visible = false;
                        tasksBindingSource.DataSource = upcomingTasks;
                        dgViewTasks.AutoGenerateColumns = false;
                        dgViewTasks.DataSource = tasksBindingSource;
                    }
                    else
                    {
                        lblUpcomingTasks.Visible = true;
                    }
                }
                else
                {
                    tasksBindingSource.DataSource = null;
                    dgViewTasks.DataSource = tasksBindingSource;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading tasks.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        // Method to load ratings
        private async Task<List<RatedMemberDto>> GetRatingsAsync(int groupId, int userId, string keyword = null)
        {
            string url = $"https://collaborateapi.runasp.net/api/Ratings/group/{groupId}/rater/{userId}/rated-members";

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                url += $"?keyword={Uri.EscapeDataString(keyword)}";
            }

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<RatedMemberDto>();
            }

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var ratings = JsonSerializer.Deserialize<List<RatedMemberDto>>(json, options);

            return ratings ?? new List<RatedMemberDto>();
        }

        // Method to display meetings
        public async Task DisplayRatingsAsync(int groupId, int userId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var ratings = await GetRatingsAsync(groupId, userId, keyword);

                if (ratings != null)
                {
                    if (ratings.Count <= 0)
                    {
                        lblMemberEvaluations.Visible = true;
                    }
                    else
                    {
                        ratingsBindingSource.DataSource = ratings;
                        dgViewMemberEvaluations.AutoGenerateColumns = false;
                        dgViewMemberEvaluations.DataSource = ratingsBindingSource;
                    }   
                }
                else
                {
                    ratingsBindingSource.DataSource = null;
                    dgViewMemberEvaluations.DataSource = ratingsBindingSource;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading evaluations.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmHome_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    dgViewMembers.Columns["RemoveMember"].Visible = true;
                }
            }

            var loadGroupMembersTask = LoadGroupMembersAsync();
            var displayUpcomingMeetingsTask = DisplayUpcomingMeetingsAsync(CurrentGroup.Group_ID);
            var displayUpcomingTasksTask = DisplayUpcomingTasksAsync(CurrentGroup.Group_ID);
            var displayRatingsTask = DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID);

            await Task.WhenAll(loadGroupMembersTask, displayUpcomingMeetingsTask, displayUpcomingTasksTask, displayRatingsTask);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMembers.Rows.Add(1, "Mia");
            dgViewMeetings.Rows.Add(1, "Meet up now", "17 June 2025");
            dgViewTasks.Rows.Add(1, "Finish app design", "18 December 2025");
            dgViewMemberEvaluations.Rows.Add(1, "Roy", "4.5");
        }

        // Method to remove a user from the group
        private async Task<bool> RemoveUserFromGroupAsync(int groupId, int userId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewMembers.Enabled = false;

                string url = $"https://collaborateapi.runasp.net/api/groups/{groupId}/members/{userId}";

                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                string error = await response.Content.ReadAsStringAsync();
                pbLoadingSpinner.Visible = false;

                if (error.Contains("Cannot remove the las"))
                {
                    AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Cannot remove the last admin.", Properties.Resources.Warning_Icon);
                }
                else
                {
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", error + " An error occurred while removing a member.", Properties.Resources.Error_Icon);
                }
                    
                return false;
            }
            catch (TaskCanceledException)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Timeout", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while removing a member.", Properties.Resources.Error_Icon);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewMembers.Enabled = true;
            }
        }


        private async void dgViewMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validate indexes and check if button column is clicked
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            var dgView = sender as DataGridView;
            var column = dgView.Columns[e.ColumnIndex];

            if (dgViewMembers.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int userId = Convert.ToInt32(dgView.Rows[e.RowIndex].Cells["User_ID"].Value);
                int groupId = CurrentGroup.Group_ID;

                if (MessageBox.Show("Are you sure you want to remove this member from the group?", "Remove member", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool success = await RemoveUserFromGroupAsync(groupId, userId);

                    if (success)
                    {
                        await LoadGroupMembersAsync();

                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Member removed successfully.", Properties.Resources.Success_Icon);
                    }
                }
            }
        }

        private void frmHome_Resize(object sender, EventArgs e)
        {
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
