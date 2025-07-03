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
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient();

        public frmMain()
        {
            InitializeComponent();
        }

        // Method to load groups
        public async Task LoadUserGroupsAsync(int userId)
        {
            try
            {
                string apiUrl = $"https://localhost:7287/api/Groups/user/{userId}";

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
                        // Temporarily unsubscribe from the SelectedIndexChanged event
                        cmbxCurrentGroup.SelectedIndexChanged -= cmbxCurrentGroup_SelectedIndexChanged;

                        cmbxCurrentGroup.DataSource = groups;
                        cmbxCurrentGroup.DisplayMember = "Group_Name";
                        cmbxCurrentGroup.ValueMember = "Group_ID";

                        // Reset combobox selection
                        cmbxCurrentGroup.SelectedIndex = -1;

                        // Re-subscribe to the event 
                        cmbxCurrentGroup.SelectedIndexChanged += cmbxCurrentGroup_SelectedIndexChanged;

                        // Choose the first group
                        cmbxCurrentGroup.SelectedIndex = 0;
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmHome());
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
            openChildForm(new frmGroupChats());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //openChildForm(new frmSettings());
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            await LoadUserGroupsAsync(CurrentUser.User_ID);
        }

        private void cmbxCurrentGroup_SelectedIndexChanged(object sender, EventArgs e)
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

                    MessageBox.Show("The static class: " + CurrentGroup.Group_ID + " " + CurrentGroup.Group_Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Close();
        }
    }
}
