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
    public partial class frmScheduleUpdateMeeting : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        public int meeting_ID = 0;

        public frmScheduleUpdateMeeting()
        {
            InitializeComponent();
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Meeting title validation
            if (string.IsNullOrWhiteSpace(txtMeetingTitle.Texts))
            {
                if (!lblMeetingTitleError.Visible)
                    lblMeetingTitleError.Visible = true;

                lblMeetingTitleError.Text = "Please enter meeting title";

                if (this.txtMeetingTitle.BorderColor != Color.Red)
                {
                    this.txtMeetingTitle.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblMeetingTitleError.Visible)
                    lblMeetingTitleError.Visible = false;

                if (txtMeetingTitle.BorderColor != Color.DimGray)
                    txtMeetingTitle.BorderColor = Color.DimGray;
            }

            // Meeting date validation
            if (dtpMeetingDate.Value == null)
            {
                if (!lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = true;

                lblMeetingDateError.Text = "Please select meeting date";

                if (this.dtpMeetingDate.BorderColor != Color.Red)
                {
                    this.dtpMeetingDate.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else if (dtpMeetingDate.Value <= DateTime.Now)
            {
                if (!lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = true;

                lblMeetingDateError.Text = "Meeting date must be in the future.";

                if (this.dtpMeetingDate.BorderColor != Color.Red)
                {
                    this.dtpMeetingDate.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblMeetingDateError.Visible)
                    lblMeetingDateError.Visible = false;

                if (dtpMeetingDate.BorderColor != Color.LightGray)
                    dtpMeetingDate.BorderColor = Color.LightGray;
            }

            return hasError;
        }

        // Method to schedule a meeting
        private async Task<bool> CreateMeetingAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnScheduleUpdateMeeting.Enabled = false;

                if (InputValidation() == false)
                {
                    var newMeeting = new CreateMeetingDto
                    {
                        Group_ID = CurrentGroup.Group_ID,
                        Meeting_Title = txtMeetingTitle.Texts,
                        Meeting_Description = txtMeetingDescription.Texts,
                        Meeting_Date = dtpMeetingDate.Value
                    };

                    // Serialize object
                    var json = JsonSerializer.Serialize(newMeeting);

                    // Prepare http content
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // API endpoint URL for adding users
                    string apiUrl = ApiBaseUrl + "/api/Meetings";

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    response.EnsureSuccessStatusCode();

                    pbLoadingSpinner.Visible = false;
                    btnScheduleUpdateMeeting.Enabled = true;

                    MessageBox.Show("Meeting sheduled successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMeetingTitle.Texts = "";
                    txtMeetingDescription.Texts = "";
                    dtpMeetingDate.Value = DateTime.Now;
                    txtMeetingTitle.Focus();

                    var groupMeetinForm = Application.OpenForms.OfType<frmGroupMeetings>().FirstOrDefault();
                    if (groupMeetinForm != null)
                    {
                        _ = groupMeetinForm.DisplayMeetingsAsync(CurrentGroup.Group_ID);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                btnScheduleUpdateMeeting.Enabled = true;

                MessageBox.Show("Request error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnScheduleUpdateMeeting.Enabled = true;

                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnScheduleUpdateMeeting.Enabled = true;
            }
        }

        private async void btnScheduleUpdateMeeting_Click(object sender, EventArgs e)
        {
            if (btnScheduleUpdateMeeting.ButtonText.Contains("Schedule Meeting") == true)
            {
                await CreateMeetingAsync();
            }
        }
    }
}
