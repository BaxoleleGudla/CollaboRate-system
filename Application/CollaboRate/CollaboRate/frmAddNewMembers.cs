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
    public partial class frmAddNewMembers : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource usersBindingSource = new BindingSource();

        public frmAddNewMembers()
        {
            InitializeComponent();
        }

        // Method to get selected users
        private List<int> GetSelectedUserIds()
        {
            var checkedUserIds = new List<int>();

            foreach (DataGridViewRow row in dgViewUsers.Rows)
            {
                // Check if the checkbox cell is checked
                var isCheckedObj = row.Cells["Action"].Value;
                bool isChecked = isCheckedObj != null && Convert.ToBoolean(isCheckedObj);

                if (isChecked == true)
                {
                    // Safely parse User_ID cell value
                    var userIdObj = row.Cells["User_ID"].Value;
                    if (userIdObj != null && int.TryParse(userIdObj.ToString(), out int userId))
                    {
                        checkedUserIds.Add(userId);
                    }
                }
            }

            return checkedUserIds;
        }

        // Method to add users
        private async Task AddUsersToGroupAsync(int groupId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnAddMembers.Enabled = false;

                var selectedUserIds = GetSelectedUserIds();

                if (!GetSelectedUserIds().Any())
                {
                    MessageBox.Show("Please select at least one user to add.", "No Users Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var request = new AddUsersToGroupRequest
                {
                    Group_ID = groupId,
                    User_IDs = selectedUserIds
                };

                string json = JsonSerializer.Serialize(request);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = ApiBaseUrl + "/api/Groups/add-users";

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();

                    pbLoadingSpinner.Visible = false;
                    btnAddMembers.Enabled = true;

                    MessageBox.Show("User(s) added successfully:\n" + result, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await DisplayUsersNotInGroupAsync(CurrentGroup.Group_ID);

                    var projectGroupForm = Application.OpenForms.OfType<frmProjectGroups>().FirstOrDefault();
                    if (projectGroupForm != null)
                    {
                        _ = projectGroupForm.LoadGroupDetailsAsync();
                    }

                    // Update frmEdit group with new members
                }
                else
                {
                    pbLoadingSpinner.Visible = false;
                    btnAddMembers.Enabled = true;

                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Failed to add users: " + error, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnAddMembers.Enabled = true;
                MessageBox.Show("Error adding users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnAddMembers.Enabled = true;
            }
        }

        private async void btnAddMembers_Click(object sender, EventArgs e)
        {
            await AddUsersToGroupAsync(CurrentGroup.Group_ID);
        }

        private void dgViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // If user clicks anywhere on the row (except the checkbox cell), toggle checkbox
                if (e.ColumnIndex != 0)
                {
                    bool currentValue = Convert.ToBoolean(dgViewUsers.Rows[e.RowIndex].Cells[2].Value);
                    dgViewUsers.Rows[e.RowIndex].Cells[2].Value = !currentValue;
                }
            }
        }

        private void dgViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Commit the edit so the checkbox value changes immediately
                dgViewUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgViewUsers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgViewUsers.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgViewUsers.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Method to get users
        private async Task<List<UserDto>> GetUsersNotInGroupAsync(int currentGroupId, string keyword = null)
        {
            try
            {
                string url = $"https://localhost:7287/api/Users/not-in-group/{currentGroupId}?currentUserId={CurrentUser.User_ID}&keyword={keyword}";

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = JsonSerializer.Deserialize<List<UserDto>>(json, options);

                return users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<UserDto>();
            }
        }

        // Method to display users
        private async Task DisplayUsersNotInGroupAsync(int currentGroupId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var users = await GetUsersNotInGroupAsync(currentGroupId, keyword);

                if (users != null)
                {
                    usersBindingSource.DataSource = users;
                    dgViewUsers.AutoGenerateColumns = false;
                    dgViewUsers.DataSource = usersBindingSource;

                    dgViewUsers.Refresh();
                }
                else
                {
                    usersBindingSource.DataSource = null;
                    dgViewUsers.DataSource = usersBindingSource;
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show("Network error while loading users: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (JsonException ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show("Data format error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private async void frmAddNewMembers_Load(object sender, EventArgs e)
        {
            await DisplayUsersNotInGroupAsync(CurrentGroup.Group_ID);
        }

        private async void txtSearchUsername__TextChanged(object sender, EventArgs e)
        {
            await DisplayUsersNotInGroupAsync(CurrentGroup.Group_ID, txtSearchUsername.Texts);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
