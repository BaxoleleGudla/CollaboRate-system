using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmProjectGroups : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient();

        public frmProjectGroups()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewJoinRequests.Rows.Add(1, "Mia");
            dgViewProjectGroups.Rows.Add(1, "Mia");
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

        public async Task<AcceptedGroupUsersDto> GetGroupDetailsAsync(int groupId)
        {
            string apiUrl = $"https://localhost:7287/api/groups/{groupId}/details-with-accepted-users";

            client.Timeout = TimeSpan.FromSeconds(30); // Set 30 seconds timeout

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

        private async void frmProjectGroups_Load(object sender, EventArgs e)
        {
            var groupDetails = await GetGroupDetailsAsync(CurrentGroup.Group_ID);

            try
            {
                if (groupDetails != null)
                {
                    lblGroupName.Text = groupDetails.Group_Name;
                    lblGroupDescription.Text = groupDetails.Group_Description;
                    lblNumOfMembers.Text = groupDetails.Accepted_User_Count.ToString() + " Member(s)";

                    foreach (var user in groupDetails.Accepted_Users)
                    {
                        MessageBox.Show(user.User_ID + " " + user.Username + " " + user.User_Role);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ;
            }
        }
    }
}
