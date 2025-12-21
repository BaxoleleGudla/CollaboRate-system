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
using CollaboRate.Dtos;

namespace CollaboRate
{
    public partial class frmMain : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient();

        public frmMain()
        {
            InitializeComponent();
            openChildForm(new frmHome());
        }

        // Method to load groups
        public async Task LoadUserGroupsAsync(int userId)
        {
            try
            {
                string apiUrl = $"https://collaborateapi.runasp.net/api/Groups/user/{userId}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var groups = JsonSerializer.Deserialize<List<GroupDto>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                 
                    if (groups != null && groups.Count > 0)
                    {
                        // Save the currently selected groups's ID (if any)
                        var selectedGroupId = cmbxCurrentGroup.SelectedValue;

                        // Temporarily unsubscribe from the SelectedIndexChanged event
                        cmbxCurrentGroup.SelectedIndexChanged -= cmbxCurrentGroup_SelectedIndexChanged;

                        cmbxCurrentGroup.DataSource = groups;
                        cmbxCurrentGroup.DisplayMember = "Group_Name";
                        cmbxCurrentGroup.ValueMember = "Group_ID";

                        // Try to restore the previous selection
                        if (selectedGroupId != null && groups.Any(g => g.Group_ID.Equals(selectedGroupId)))
                        {
                            cmbxCurrentGroup.SelectedValue = selectedGroupId;
                        }
                        else
                        {
                            cmbxCurrentGroup.SelectedIndex = -1;
                        }

                        // Re-subscribe to the event 
                        cmbxCurrentGroup.SelectedIndexChanged += cmbxCurrentGroup_SelectedIndexChanged;
                    }
                    else
                    {
                        MessageBox.Show("You do not belong to any groups", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbxCurrentGroup.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Failed to load groups", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading groups: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Form activeForm = null;

        // Method to open a form
        private void openChildForm(Form childForm)
        {
            try
            {
                // If the active form is the same type as the requested form, do nothing
                if (activeForm != null && activeForm.GetType() == childForm.GetType())
                {
                    activeForm.BringToFront();
                    return;
                }

                // Close and dispose the current active form if any
                if (activeForm != null)
                {
                    activeForm.Close();
                    activeForm.Dispose();
                }

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.Dock = DockStyle.Fill;

                pnlMain.Controls.Clear();
                pnlMain.Controls.Add(childForm);
                pnlMain.Tag = childForm;

                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new frmHome());
        }

        private void btnProjectGroups_Click(object sender, EventArgs e)
        {
            openChildForm(new frmProjectGroups());
        }

        private void btnMemberEvaluations_Click(object sender, EventArgs e)
        {
            openChildForm(new frmMemberEvaluations());
        }

        private void btnGroupTasks_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupTasks());
        }

        private void btnGroupMeetings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmGroupMeetings());
        }

        private void btnGroupChats_Click(object sender, EventArgs e)
        {
            frmGroupChats groupChatsForm = new frmGroupChats();
            groupChatsForm.txtMessage.PlaceholderText = "Type a message";
            openChildForm(groupChatsForm);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            openChildForm(new frmSettings());
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await LoadUserGroupsAsync(CurrentUser.User_ID);
            openChildForm(new frmHome());
        }

        // Method to get the role of a user
        public async Task<string> GetUserGroupRoleAsync(int userId, int groupId)
        {
            try
            {
                string url = $"{ApiBaseUrl}/api/Groups/users/{userId}/groups/{groupId}/role";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<UserRoleResponseDto>(
                json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return result?.User_Role ?? "NoRole";
                }

                return "NoRole";
            }
            catch (Exception ex)
            {
                return "Error getting user role";
            }
        }

        // Method to refresh data on the form when the group is changed
        public async Task RefreshDisplayedFormData()
        {
            // Store teh type fo the active form
            Type activeFormType = activeForm?.GetType();

            if (activeForm != null && activeFormType != typeof(frmSettings))
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

            // Instantiate and open a brand new form of the same type
            Form formToOpen = null;

            if (activeFormType == typeof(frmHome))
            {
                formToOpen = new frmHome();
            }
            else if (activeFormType == typeof(frmProjectGroups))
            {
                formToOpen = new frmProjectGroups();
            }
            else if (activeFormType == typeof(frmMemberEvaluations))
            {
                formToOpen = new frmMemberEvaluations();
            }
            else if (activeFormType == typeof(frmGroupTasks))
            {
                formToOpen = new frmGroupTasks();
            }
            else if (activeFormType == typeof(frmGroupMeetings))
            {
                formToOpen = new frmGroupMeetings();
            }
            else if (activeFormType == typeof(frmGroupChats))
            {
                formToOpen = new frmGroupChats();
            }

            // Open the new form instance
            if (formToOpen != null)
            {
                openChildForm(formToOpen);
            }
        }

        private async void cmbxCurrentGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((cmbxCurrentGroup.SelectedIndex == -1))
                {
                    MessageBox.Show("No group selected");
                }
                else
                {
                    CurrentGroup.Group_ID = Convert.ToInt32(cmbxCurrentGroup.SelectedValue.ToString());
                    CurrentGroup.Group_Name = cmbxCurrentGroup.Text;
                    CurrentUser.Group_Role = await GetUserGroupRoleAsync(CurrentUser.User_ID, CurrentGroup.Group_ID);

                    await RefreshDisplayedFormData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentGroup.Group_ID = 0;
            CurrentGroup.Group_Name = null;
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
