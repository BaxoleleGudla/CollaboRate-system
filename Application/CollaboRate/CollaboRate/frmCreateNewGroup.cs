using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmCreateNewGroup : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource usersBindingSource = new BindingSource();

        public frmCreateNewGroup()
        {
            InitializeComponent();
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

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Username validation
            if (string.IsNullOrWhiteSpace(txtGroupName.Texts))
            {
                if (!lblGroupNameError.Visible)
                    lblGroupNameError.Visible = true;

                lblGroupNameError.Text = "Please enter group name";

                if (txtGroupName.BorderColor != Color.Red)
                    txtGroupName.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblGroupNameError.Visible)
                    lblGroupNameError.Visible = false;

                if (txtGroupName.BorderColor != Color.DimGray)
                    txtGroupName.BorderColor = Color.DimGray;
            }

            return hasError;
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

        // Method to deselect users
        private void DeselectUsers()
        {
            dgViewUsers.SuspendLayout();

            foreach (DataGridViewRow row in this.dgViewUsers.Rows)
            {
                row.Cells["Action"].Value = false; 
            }

            dgViewUsers.Refresh();
        }

        // Method to create a group
        private async Task<int?> CreateGroupAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnCreateGroup.Enabled = false;

                if (InputValidation() == false)
                {
                    var newGroup = new CreateGroupRequest
                    {
                        Group_Name = txtGroupName.Texts,
                        Group_Description = txtGroupDescription.Texts,
                        Creator = CurrentUser.User_ID,
                        Member_User_IDs = GetSelectedUserIds()
                    };

                    // Serialize object
                    var json = JsonSerializer.Serialize(newGroup);

                    // Prepare http content
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // API endpoint URL for adding users
                    string apiUrl = ApiBaseUrl + "/api/Groups/groups";

                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var groupResponse = JsonSerializer.Deserialize<CreateGroupResponse>(responseBody, options);

                    if (groupResponse != null)
                    {
                        var mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                        if (mainForm != null)
                        {
                            await mainForm.LoadUserGroupsAsync(CurrentUser.User_ID);
                        }

                        pbLoadingSpinner.Visible = false;
                        btnCreateGroup.Enabled = true;

                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Group created successfully.", Properties.Resources.Success_Icon);

                        txtGroupDescription.Texts = "";
                        txtGroupName.Texts = "";
                        DeselectUsers();
                        txtGroupName.Focus();

                        return groupResponse.Group_ID;
                    }
                    else
                    {
                        pbLoadingSpinner.Visible = false;
                        btnCreateGroup.Enabled = true;

                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Unexpected response format from server.", Properties.Resources.Error_Icon);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateGroup.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while creating group.", Properties.Resources.Error_Icon);
            }
            catch (TaskCanceledException)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateGroup.Enabled = true;

                AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Request timed out. Please try again later.", Properties.Resources.Warning_Icon);
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateGroup.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while creating group.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnCreateGroup.Enabled = true;
            }

            return null;
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            await CreateGroupAsync();
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
        private async Task<List<UserDto>> GetUsersAsync(int userId, string keyword = null)
        {
            string url = $"https://collaborateapi.runasp.net/api/Users/users?currentUserId={userId}&keyword={keyword}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<UserDto>>(json, options);
        }

        // Method to display users
        private async Task DisplayUsersAsync(int userId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                
                var users = await GetUsersAsync(userId, keyword);

                if (users != null)
                {
                    usersBindingSource.DataSource = users;
                    dgViewUsers.AutoGenerateColumns = false;
                    dgViewUsers.DataSource = usersBindingSource;
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
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while loading users.", Properties.Resources.Error_Icon);
            }
            catch (JsonException ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An internal error occurred while displaying users.", Properties.Resources.Error_Icon);
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying users.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmCreateNewGroup_Load(object sender, EventArgs e)
        {
            await DisplayUsersAsync(CurrentUser.User_ID);
        }

        private async void txtSearchUsername__TextChanged(object sender, EventArgs e)
        {
            await DisplayUsersAsync(CurrentUser.User_ID, txtSearchUsername.Texts);
        }
    }
}
