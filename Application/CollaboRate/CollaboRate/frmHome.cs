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

        public frmHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMemberEvaluations.Rows.Add(1, "Mia", 4.5);
            dgViewTasks.Rows.Add(1, "Design GUI", "Due on Monday 6/11/2025");
            dgViewMeetings.Rows.Add(1, "Discuss Progress", "7/11/2025 18:30");
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

        private async void frmHome_Load(object sender, EventArgs e)
        {
            await LoadGroupMembersAsync();
            await DisplayUpcomingMeetingsAsync(CurrentGroup.Group_ID);
        }
    }
}
