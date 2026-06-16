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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CollaboRate
{
    public partial class frmEditGroup : Form
    {
        // Field to store reference to add members form
        private frmAddNewMembers _addMembersForm;

        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        private AcceptedGroupUsersDto _groupDetails;

        // List to store all users for filtering
        private List<GroupUserDto> _allUsers;

        public frmEditGroup(AcceptedGroupUsersDto groupDetails)
        {
            InitializeComponent();
            _groupDetails = groupDetails;
        }

        // Method for the toast form
        public void AlertBox(Color backColor, Color color, string title, string text, Image icon)
        {
            try
            {
                frmAlertBox alertBoxForm = new frmAlertBox();
                alertBoxForm.BackColor = backColor;
                alertBoxForm.ColorAlertBox = color;
                alertBoxForm.TitleAlertBox = title;
                alertBoxForm.TextAlertBox = text;
                alertBoxForm.IconAlertBox = icon;

                alertBoxForm.Show(this);
            }
            catch (Exception ex)
            {
                // Do nothing
                ;
            }
        }

        private void btnAddNewMembers_Click(object sender, EventArgs e)
        {
            using (frmAddNewMembers addMembersForm = new frmAddNewMembers())
            {
                addMembersForm.EditParentForm = this;
                addMembersForm.StartPosition = FormStartPosition.CenterParent;

                try
                {
                    this.Enabled = false;

                    // This keeps the chain: frmMain -> frmManage -> frmAdd
                    addMembersForm.ShowDialog(this);
                }
                finally
                {
                    // Re-enable the form when the dialog is closed
                    this.Enabled = true;
                    this.BringToFront();
                    this.Focus();
                }
            }
        }

        private void BindUsersToGrid(List<GroupUserDto> users)
        {
            dgViewUsers.DataSource = new BindingList<GroupUserDto>(users);
        }

        // Method to refresh group details
        public async Task RefreshGroupDetailsAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                // Fetch fresh data from the API to get the new members
                string apiUrl = $"{ApiBaseUrl}/api/groups/{_groupDetails.Group_ID}/details-with-accepted-users";
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                    var freshDetails = JsonSerializer.Deserialize<AcceptedGroupUsersDto>(jsonString, options);

                    if (freshDetails?.Accepted_Users != null)
                    {
                        // Update the fields and list reference
                        _groupDetails = freshDetails;
                        _allUsers = _groupDetails.Accepted_Users.ToList();

                        // Re-bind to the DataGridView
                        BindUsersToGrid(_allUsers);
                    }
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while fetching group details.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private void frmEditGroup_Load(object sender, EventArgs e)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnSaveChanges.Enabled = false;

                txtGroupName.Texts = _groupDetails.Group_Name;
                txtGroupDescription.Texts = _groupDetails.Group_Description;

                // Store full user list for filtering
                _allUsers = _groupDetails.Accepted_Users.ToList();

                dgViewUsers.DataSource = new BindingList<GroupUserDto>(_allUsers);
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying group details.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;
            }
        }

        private void txtSearchUsername__TextChanged(object sender, EventArgs e)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                string searchText = txtSearchUsername.Texts.Trim().ToLower();

                if (string.IsNullOrEmpty(searchText))
                {
                    pbLoadingSpinner.Visible = false;
                    // Show all users
                    BindUsersToGrid(_allUsers);
                }
                else
                {
                    // Filter users by username
                    var filteredUsers = _allUsers
                        .Where(u => !string.IsNullOrEmpty(u.Username) && u.Username.ToLower().Contains(searchText)).ToList();

                    pbLoadingSpinner.Visible = false;
                    BindUsersToGrid(filteredUsers);
                }
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

                if (this.txtGroupName.BorderColor != Color.Red)
                {
                    this.txtGroupName.BorderColor = Color.Red;
                }

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

        // Method to update group
        private async Task<bool> UpdateGroupAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnSaveChanges.Enabled = false;

                if (InputValidation() == false)
                {
                    var updateRequest = new UpdateGroupRequest
                    {
                        Group_ID = _groupDetails.Group_ID,
                        Group_Name = txtGroupName.Texts,
                        Group_Description = txtGroupDescription.Texts,
                        Members = new List<UpdateGroupMemberRoleDto>()
                    };

                    // Commit any pending edits
                    dgViewUsers.EndEdit();

                    // Collect user roles from DataGridView rows
                    foreach (DataGridViewRow row in dgViewUsers.Rows)
                    {
                        if (row.DataBoundItem is GroupUserDto user)
                        {
                            var roleCell = row.Cells["User_Role"];

                            string role = "";

                            if (roleCell.Value == null)
                            {
                                role = user.User_Role;
                            }
                            else
                            {
                                role = roleCell.Value.ToString();
                            }

                            updateRequest.Members.Add(new UpdateGroupMemberRoleDto
                            {
                                User_ID = user.User_ID,
                                User_Role = role
                            });
                        }
                    }

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    // Serialized DTO to Json
                    string json = JsonSerializer.Serialize(updateRequest, options);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = ApiBaseUrl + "/api/Groups/update-group";

                    // Send put request
                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        pbLoadingSpinner.Visible = false;
                        btnSaveChanges.Enabled = true;

                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Group updated successfully.", Properties.Resources.Success_Icon);

                        var mainForm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
                        if (mainForm != null)
                        {
                            _ = mainForm.LoadUserGroupsAsync(CurrentUser.User_ID);
                        }

                        var projectGroupForm = Application.OpenForms.OfType<frmProjectGroups>().FirstOrDefault();
                        if (projectGroupForm != null)
                        {
                            _ = projectGroupForm.LoadGroupDetailsAsync();
                        }

                        return true;
                    }
                    else if (response.StatusCode == (System.Net.HttpStatusCode)422)
                    {
                        // Catch last admin removal error
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "The group must have at least one Admin.", Properties.Resources.Warning_Icon);
                        return false;
                    }
                    else
                    {
                        pbLoadingSpinner.Visible = false;
                        btnSaveChanges.Enabled = true;

                        string error = await response.Content.ReadAsStringAsync();
                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to update group.", Properties.Resources.Error_Icon);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while updating group.", Properties.Resources.Error_Icon);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while updating group.", Properties.Resources.Error_Icon);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            await UpdateGroupAsync();
        }
    }
}
