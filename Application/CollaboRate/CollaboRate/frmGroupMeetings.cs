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
        }

        private void btnScheduleNewMeeting_Click(object sender, EventArgs e)
        {
            frmScheduleUpdateMeeting scheduleMeetingForm = new frmScheduleUpdateMeeting();
            scheduleMeetingForm.btnScheduleUpdateMeeting.ButtonText = "Schedule Meeting";
            scheduleMeetingForm.txtMeetingTitle.PlaceholderText = "Enter meeting title";
            scheduleMeetingForm.txtMeetingDescription.PlaceholderText = "Enter meeting description";
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
            await DisplayMeetingsAsync(CurrentGroup.Group_ID);
        }

        private async void txtSearchMeeting__TextChanged(object sender, EventArgs e)
        {
            await DisplayMeetingsAsync(CurrentGroup.Group_ID, txtSearchMeeting.Texts);
        }

        private void dgViewMeetings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmScheduleUpdateMeeting updateMeetingForm = new frmScheduleUpdateMeeting();

                updateMeetingForm.btnScheduleUpdateMeeting.ButtonText = "Save Changes";


                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dgViewMeetings.Rows[e.RowIndex];

                    updateMeetingForm.meeting_ID = int.Parse(row.Cells["Meeting_ID"].Value.ToString());
                    updateMeetingForm.txtMeetingTitle.Texts = (row.Cells["Meeting_Title"].Value).ToString();
                    updateMeetingForm.txtMeetingDescription.Texts = (row.Cells["Meeting_Description"].Value.ToString());
                    updateMeetingForm.dtpMeetingDate.Value = DateTime.Parse((row.Cells["Meeting_Date"].Value.ToString()));

                    updateMeetingForm.btnCancelMeeting.Enabled = true;

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
