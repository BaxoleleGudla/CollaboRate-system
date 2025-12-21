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
    public partial class frmCreateUpdateTask : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource usersBindingSource = new BindingSource();
        public int task_ID = 0;

        public frmCreateUpdateTask()
        {
            InitializeComponent();
        }

        // Method to load group members for task creation
        private async Task<List<UserDto>> GetUsersInGroupAsync(int groupId, string keyword = "")
        {
            try
            {
                string url = $"https://collaborateapi.runasp.net/api/Groups/group/{groupId}/users";

                if (string.IsNullOrEmpty(keyword) == false)
                {
                    url += $"?keyword={Uri.EscapeDataString(keyword)}";
                }

                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("An error occured while getting group members", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                var stream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = await JsonSerializer.DeserializeAsync<List<UserDto>>(stream, options);

                return users;
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show("Error: " + httpEx.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Method to display group members for task creation
        private async Task DisplayMembersAsync(int groupId, string keyword = "")
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var users = await GetUsersInGroupAsync(groupId, keyword);

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

        // Method to get users for task update
        public async Task<List<UserWithTaskAssignmentDto>> GetUsersWithAssignedUsersAsync(int groupId, int taskId)
        {
            try
            {
                string url = $"https://collaborateapi.runasp.net/api/Users/group/{groupId}/task/{taskId}/users";

                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var users = JsonSerializer.Deserialize<List<UserWithTaskAssignmentDto>>(json, options);

                return users ?? new List<UserWithTaskAssignmentDto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<UserWithTaskAssignmentDto>();
            }
        }

        // Method to display users for task update
        public async Task DisplayMembersForUpdateAsync(int groupId, int taskId)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnCreateUpdateTask.Enabled = false;

                var users = await GetUsersWithAssignedUsersAsync(groupId, taskId);

                dgViewUsers.DataSource = users;

                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Meeting title validation
            if (string.IsNullOrWhiteSpace(txtTaskTitle.Texts))
            {
                if (!lblTaskTitleError.Visible)
                    lblTaskTitleError.Visible = true;

                lblTaskTitleError.Text = "Please enter task title";

                if (this.txtTaskTitle.BorderColor != Color.Red)
                {
                    this.txtTaskTitle.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblTaskTitleError.Visible)
                    lblTaskTitleError.Visible = false;

                if (txtTaskTitle.BorderColor != Color.DimGray)
                    txtTaskTitle.BorderColor = Color.DimGray;
            }

            // Meeting date validation
            if (dtpTaskDeadline.Value == null)
            {
                if (!lblTaskDeadlineError.Visible)
                    lblTaskDeadlineError.Visible = true;

                lblTaskDeadlineError.Text = "Please select task deadline.";

                if (this.dtpTaskDeadline.BorderColor != Color.Red)
                {
                    this.dtpTaskDeadline.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else if (dtpTaskDeadline.Value <= DateTime.Now)
            {
                if (!lblTaskDeadlineError.Visible)
                    lblTaskDeadlineError.Visible = true;

                lblTaskDeadlineError.Text = "Task deadline must be in the future";

                if (this.dtpTaskDeadline.BorderColor != Color.Red)
                {
                    this.dtpTaskDeadline.BorderColor = Color.Red;
                }

                hasError = true;
            }
            else
            {
                if (lblTaskDeadlineError.Visible)
                    lblTaskDeadlineError.Visible = false;

                if (dtpTaskDeadline.BorderColor != Color.LightGray)
                    dtpTaskDeadline.BorderColor = Color.LightGray;
            }

            return hasError;
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

        // Method to create a new task
        private async Task<bool> CreateTaskAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnCreateUpdateTask.Enabled = false;

                if (InputValidation() == false)
                {
                    var newTask = new CreateTaskDto
                    {
                        Group_ID = CurrentGroup.Group_ID,
                        Task_Title = txtTaskTitle.Texts,
                        Task_Description = txtTaskDescription.Texts,
                        Deadline = dtpTaskDeadline.Value,
                        AssignedUserIds = GetSelectedUserIds()
                    };

                    // Serialize object
                    var json = JsonSerializer.Serialize(newTask);

                    // Prepare http content
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // API endpoint URL for adding tasks
                    string apiUrl = "https://collaborateapi.runasp.net/api/Tasks/tasks";

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
                        var groupTasksForm = Application.OpenForms.OfType<frmGroupTasks>().FirstOrDefault();
                        if (groupTasksForm != null)
                        {
                            await groupTasksForm.DisplayTasksAsync(CurrentGroup.Group_ID);
                        }
                        
                        pbLoadingSpinner.Visible = false;
                        btnCreateUpdateTask.Enabled = true;

                        MessageBox.Show("Task created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtTaskTitle.Texts = "";
                        txtTaskDescription.Texts = "";
                        dtpTaskDeadline.Value = DateTime.Now;
                        DeselectUsers();
                        txtTaskTitle.Focus();
                    }
                    else
                    {
                        pbLoadingSpinner.Visible = false;
                        btnCreateUpdateTask.Enabled = true;

                        MessageBox.Show("Unexpected response format from server.", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show($"Network error: {ex.Message}", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            catch (TaskCanceledException)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show("Request timed out.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;
            }

            return true;
        }

        // Method to update a task
        private async Task UpdateTaskAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnCreateUpdateTask.Enabled = false;

                if (InputValidation() == false)
                {
                    var updateTaskRequest = new UpdateTaskDto
                    {
                        Task_ID = task_ID,
                        Task_Title = txtTaskTitle.Texts,
                        Task_Description = txtTaskDescription.Texts,
                        Deadline = dtpTaskDeadline.Value,
                        AssignedUserIds = GetSelectedUserIds(),
                        Is_Completed = ckbTaskCompleted.Checked
                    };

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    string json = JsonSerializer.Serialize(updateTaskRequest, options);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"https://collaborateapi.runasp.net/api/Tasks/tasks/update";

                    // Send put request
                    HttpResponseMessage response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        pbLoadingSpinner.Visible = false;
                        btnCreateUpdateTask.Enabled = true;

                        MessageBox.Show("Task updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var groupTaskForm = Application.OpenForms.OfType<frmGroupTasks>().FirstOrDefault();
                        if (groupTaskForm != null)
                        {
                            _ = groupTaskForm.DisplayTasksAsync(CurrentGroup.Group_ID);
                        }
                    }
                    else
                    {
                        pbLoadingSpinner.Visible = false;
                        btnCreateUpdateTask.Enabled = true;

                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error: " + error, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show("Error: " + httpEx.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;

                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnCreateUpdateTask.Enabled = true;
            }
        }

        // Method to delete a task
        private async Task<bool> DeleteTaskAsync(int taskId, int deletedByUserId)
        {
            if (MessageBox.Show("Are you sure you want to delete this task?", "Delete Task", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    pbLoadingSpinner.Visible = true; // Show loading indicator

                    if (task_ID > 0)
                    {
                        string url = $"{ApiBaseUrl}/api/Tasks/tasks/{taskId}/delete?deletedByUserId={deletedByUserId}";

                        // Send DELETE request
                        HttpResponseMessage response = await client.DeleteAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            pbLoadingSpinner.Visible = false;
                            string responseBody = await response.Content.ReadAsStringAsync();
                            MessageBox.Show("Task deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            var groupTaskForm = Application.OpenForms.OfType<frmGroupTasks>().FirstOrDefault();
                            if (groupTaskForm != null)
                            {
                                _ = groupTaskForm.DisplayTasksAsync(CurrentGroup.Group_ID);
                            }

                            this.Close();

                            return true;
                        }
                        else
                        {
                            pbLoadingSpinner.Visible = false;
                            string error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Failed to delete task: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        pbLoadingSpinner.Visible = false;
                        MessageBox.Show("Please login to delete a task", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch (HttpRequestException ex)
                {
                    pbLoadingSpinner.Visible = false;
                    MessageBox.Show($"Network error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    pbLoadingSpinner.Visible = false;
                    MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private async void btnCreateUpdateTask_Click(object sender, EventArgs e)
        {
            if (btnCreateUpdateTask.ButtonText.Contains("Create Task") == true)
            {
                await CreateTaskAsync();
            }
            else if (btnCreateUpdateTask.ButtonText.Contains("Save Changes") == true)
            {
                await UpdateTaskAsync();
            }
            else
            {
                MessageBox.Show("Could not create or update task", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private async void frmCreateUpdateTask_Load(object sender, EventArgs e)
        {
            if (btnCreateUpdateTask.ButtonText.Contains("Create Task") == true)
            {
                await DisplayMembersAsync(CurrentGroup.Group_ID);
            }
            else if (btnCreateUpdateTask.ButtonText.Contains("Save Changes") == true)
            {
                await DisplayMembersForUpdateAsync(CurrentGroup.Group_ID, task_ID);
            }
            else
            {
                MessageBox.Show("Could not load group members", "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnDeleteTask_Click(object sender, EventArgs e)
        {
            await DeleteTaskAsync(task_ID, CurrentUser.User_ID);
        }
    }
}
