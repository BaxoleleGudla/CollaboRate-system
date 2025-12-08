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
        private const string ApiBaseUrl = "https://localhost:7287";
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
            if (CurrentUser.Group_Role.Contains("Admin"))
            {
                dgViewMembers.Columns["RemoveMember"].Visible = true;
            }
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

        // Method to get meetings
        private async Task<List<MeetingDto>> GetMeetingsAsync(int groupId, string keyword = null)
        {
            string url = $"https://localhost:7287/api/Meetings/group/{groupId}";

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
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string url = $"https://localhost:7287/api/Tasks/tasks/by-group?{queryString}";

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
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        // Method to load ratings
        private async Task<List<RatedMemberDto>> GetRatingsAsync(int groupId, int userId, string keyword = null)
        {
            string url = $"https://localhost:7287/api/Ratings/group/{groupId}/rater/{userId}/rated-members";

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
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmHome_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Group_Role.Contains("Admin"))
            {
                dgViewMembers.Columns["RemoveMember"].Visible = true;
            }

            var loadGroupMembersTask = LoadGroupMembersAsync();
            var displayUpcomingMeetingsTask = DisplayUpcomingMeetingsAsync(CurrentGroup.Group_ID);
            var displayUpcomingTasksTask = DisplayUpcomingTasksAsync(CurrentGroup.Group_ID);
            var displayRatingsTask = DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID);

            await Task.WhenAll(loadGroupMembersTask, displayUpcomingMeetingsTask, displayUpcomingTasksTask, displayRatingsTask);
        }
    }
}
