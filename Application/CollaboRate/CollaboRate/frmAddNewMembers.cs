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
        // Custom property for parent form reference
        public frmEditGroup EditParentForm { get; set; }

        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource usersBindingSource = new BindingSource();

        public frmAddNewMembers()
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
                    AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Please select at least one user to add.", Properties.Resources.Warning_Icon);
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

                    AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "User(s) added successfully.", Properties.Resources.Success_Icon);

                    await DisplayUsersNotInGroupAsync(CurrentGroup.Group_ID);

                    var projectGroupForm = Application.OpenForms.OfType<frmProjectGroups>().FirstOrDefault();
                    if (projectGroupForm != null)
                    {
                        _ = projectGroupForm.LoadGroupDetailsAsync();
                    }
                }
                else
                {
                    pbLoadingSpinner.Visible = false;
                    btnAddMembers.Enabled = true;

                    string error = await response.Content.ReadAsStringAsync();
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to add users.", Properties.Resources.Error_Icon);
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnAddMembers.Enabled = true;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while adding users.", Properties.Resources.Error_Icon);
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
                string url = $"https://collaborateapi.runasp.net/api/Users/not-in-group/{currentGroupId}?currentUserId={CurrentUser.User_ID}&keyword={keyword}";

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
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading users.", Properties.Resources.Error_Icon);
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
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while loading users.", Properties.Resources.Error_Icon);
            }
            catch (JsonException ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An system error occurred while loading users.", Properties.Resources.Error_Icon);
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading users.", Properties.Resources.Error_Icon);
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
            if (EditParentForm != null)
            {
                EditParentForm.Show();
                EditParentForm.BringToFront();
            }
            this.Close();
        }
    }
}
