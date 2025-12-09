using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmGroupMeetings : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource meetingsBindingSource = new BindingSource();

        public frmGroupMeetings()
        {
            InitializeComponent();
            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    btnScheduleNewMeeting.Visible = true;
                    dgViewMeetings.Columns["CancelMeeting"].Visible = true;
                }
            }
        }

        private void btnScheduleNewMeeting_Click(object sender, EventArgs e)
        {
            frmScheduleUpdateMeeting scheduleMeetingForm = new frmScheduleUpdateMeeting();
            scheduleMeetingForm.btnScheduleUpdateMeeting.ButtonText = "Schedule Meeting";
            scheduleMeetingForm.txtMeetingTitle.PlaceholderText = "Enter meeting title";
            scheduleMeetingForm.txtMeetingDescription.PlaceholderText = "Enter meeting description";
            scheduleMeetingForm.btnCancelMeeting.Visible = false;
            scheduleMeetingForm.btnScheduleUpdateMeeting.Size = new Size(344, 35);
            scheduleMeetingForm.btnScheduleUpdateMeeting.Location = new Point(35, 408);
            scheduleMeetingForm.ShowDialog();
        }

        // Method to load meetings
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

        // Method to display meetings
        public async Task DisplayMeetingsAsync(int groupId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var meetings = await GetMeetingsAsync(groupId, keyword);

                if (meetings != null)
                {
                    meetingsBindingSource.DataSource = meetings;
                    dgViewMeetings.AutoGenerateColumns = false;
                    dgViewMeetings.DataSource = meetingsBindingSource;
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

        private async void frmGroupMeetings_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Group_Role != null)
            {
                if (CurrentUser.Group_Role.Contains("Admin"))
                {
                    btnScheduleNewMeeting.Visible = true;
                    dgViewMeetings.Columns["CancelMeeting"].Visible = true;
                }
            }
            await DisplayMeetingsAsync(CurrentGroup.Group_ID);
        }

        private async void txtSearchMeeting__TextChanged(object sender, EventArgs e)
        {
            await DisplayMeetingsAsync(CurrentGroup.Group_ID, txtSearchMeeting.Texts);
        }

        // Method to cancel a meeting
        private async Task CancelMeetingAsync(int meetingId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewMeetings.Enabled = false;

                string url = $"https://localhost:7287/api/Meetings/cancel/{meetingId}";

                // Send DELETE request
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    pbLoadingSpinner.Visible = false;
                    dgViewMeetings.Enabled = true;

                    MessageBox.Show("Meeting cancelled successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    pbLoadingSpinner.Visible = false;
                    dgViewMeetings.Enabled = true;

                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to cancel a meeting: " + error, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewMeetings.Enabled = true;
                MessageBox.Show("Could not cancel meeting: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewMeetings.Enabled = true;
            }
        }

        private async void dgViewMeetings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmScheduleUpdateMeeting updateMeetingForm = new frmScheduleUpdateMeeting();

                updateMeetingForm.btnScheduleUpdateMeeting.ButtonText = "Save Changes";

                if (e.RowIndex < 0)
                {
                    return;
                }

                // Check if the clicked column is a button column
                if (dgViewMeetings.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    if (MessageBox.Show("Are you sure you want to cancel the meeting?", "Cancel Meeting", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataGridViewRow row = this.dgViewMeetings.Rows[e.RowIndex];

                        int meeting_ID = int.Parse(row.Cells["Meeting_ID"].Value.ToString());
                        await CancelMeetingAsync(meeting_ID);

                        await DisplayMeetingsAsync(CurrentGroup.Group_ID);
                    }
                }
                else
                {
                    DataGridViewRow row = this.dgViewMeetings.Rows[e.RowIndex];

                    updateMeetingForm.lblHeading.Text = "Update Meeting";

                    updateMeetingForm.meeting_ID = int.Parse(row.Cells["Meeting_ID"].Value.ToString());
                    updateMeetingForm.txtMeetingTitle.Texts = (row.Cells["Meeting_Title"].Value).ToString();
                    updateMeetingForm.txtMeetingDescription.Texts = (row.Cells["Meeting_Description"].Value.ToString());
                    updateMeetingForm.dtpMeetingDate.Value = DateTime.Parse((row.Cells["Meeting_Date"].Value.ToString()));

                    updateMeetingForm.btnCancelMeeting.Enabled = true;

                    if (CurrentUser.Group_Role != null)
                    {
                        if (CurrentUser.Group_Role.Contains("Member"))
                        {
                            updateMeetingForm.lblHeading.Text = "Meeting Details";
                            updateMeetingForm.txtMeetingTitle.Enabled = false;
                            updateMeetingForm.txtMeetingDescription.Enabled = false;
                            updateMeetingForm.btnCancelMeeting.Visible = false;
                            updateMeetingForm.btnScheduleUpdateMeeting.Visible = false;
                            updateMeetingForm.dtpMeetingDate.Enabled = false;
                            updateMeetingForm.Size = new System.Drawing.Size(429, 428);
                        }
                    }

                    updateMeetingForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
