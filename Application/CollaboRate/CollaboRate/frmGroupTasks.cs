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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmGroupTasks : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource tasksBindingSource = new BindingSource();

        public frmGroupTasks()
        {
            InitializeComponent();
        }

        private void btnCreateNewTask_Click(object sender, EventArgs e)
        {
            frmCreateUpdateTask createTaskForm = new frmCreateUpdateTask();
            createTaskForm.btnCreateUpdateTask.ButtonText = "Create Task";
            createTaskForm.lblHeading.Text = "Create New Task";
            createTaskForm.txtTaskTitle.PlaceholderText = "Enter task title";
            createTaskForm.txtTaskDescription.PlaceholderText = "Enter task description";
            createTaskForm.ckbTaskCompleted.Visible = false;
            createTaskForm.dtpTaskDeadline.Size = new System.Drawing.Size(377, 28);
            createTaskForm.dtpTaskDeadline.Location = new System.Drawing.Point(35, 303);
            createTaskForm.ShowDialog();
        }

        // Method to load tasks
        private async Task<List<TaskWithUsersDto>> GetTasksAsync(int groupId, int? userId = null, string keyword = null)
        {
            var queryParams = new List<string>();

            queryParams.Add($"group_ID={groupId}");

            if (userId.HasValue && userId.Value > 0)
            {
                queryParams.Add($"user_ID={userId.Value}");
            }

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                queryParams.Add($"keyword={Uri.EscapeDataString(keyword)}");
            }

            string queryString = string.Join("&", queryParams);

            string url = $"https://localhost:7287/api/Tasks/tasks/by-group?{queryString}";

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<TaskWithUsersDto>();
            }

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var tasks = JsonSerializer.Deserialize<List<TaskWithUsersDto>>(json, options);

            return tasks ?? new List<TaskWithUsersDto>();
        }

        // Method to display tasks
        public async Task DisplayTasksAsync(int groupId, int? userId = null, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var tasks = await GetTasksAsync(groupId, userId, keyword);

                if (tasks != null)
                {
                    tasksBindingSource.DataSource = tasks;
                    dgViewTasks.AutoGenerateColumns = false;
                    dgViewTasks.DataSource = tasksBindingSource;
                }
                else
                {
                    tasksBindingSource.DataSource = null;
                    dgViewTasks.DataSource = tasksBindingSource;
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

        private async void frmGroupTasks_Load(object sender, EventArgs e)
        {
            await DisplayTasksAsync(CurrentGroup.Group_ID);
        }

        private async void txtSearchTask__TextChanged(object sender, EventArgs e)
        {
            await DisplayTasksAsync(CurrentGroup.Group_ID, null, txtSearchTask.Texts);
        }

        // Method to change task status
        private async Task<bool> ChangeTaskStatusAsync(int taskId, bool status)
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                dgViewTasks.Enabled = false;

                string url = $"https://localhost:7287/api/Tasks/tasks/{taskId}/change-status?isCompleted={status}";

                var response = await client.PutAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                pbLoadingSpinner.Visible = false;
                dgViewTasks.Enabled = true;
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Failed to change task status: " + error, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewTasks.Enabled = true;
                MessageBox.Show("Could not change task status: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                dgViewTasks.Enabled = true;
            }
        }

        private async void dgViewTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmCreateUpdateTask updateTaskForm = new frmCreateUpdateTask();

                updateTaskForm.btnCreateUpdateTask.ButtonText = "Save Changes";

                if (e.RowIndex < 0)
                {
                    return;
                }

                // Check if the clicked column is a button column
                if (dgViewTasks.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Get the bound data item for the clicked row
                    var task = dgViewTasks.Rows[e.RowIndex].DataBoundItem as TaskWithUsersDto;

                    if (task == null)
                    {
                        return;
                    }

                    var dgv = sender as DataGridView;

                    // Get the task ID from the clicked row
                    int task_ID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Task_ID"].Value);

                    if (task.Status == "Completed")
                    {
                        bool success = await ChangeTaskStatusAsync(task_ID, false);

                        if (success)
                        {
                            //group.HasPendingRequest = false;
                            //dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                            await DisplayTasksAsync(CurrentGroup.Group_ID);
                            MessageBox.Show("Task marked as incomplete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (task.Status == "Not Completed")
                    {
                        bool success = await ChangeTaskStatusAsync(task_ID, true);

                        if (success)
                        {
                            //group.HasPendingRequest = true;
                            //dgViewProjectGroups.InvalidateCell(e.ColumnIndex, e.RowIndex);
                            await DisplayTasksAsync(CurrentGroup.Group_ID);
                            MessageBox.Show("Task marked as completed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    DataGridViewRow row = this.dgViewTasks.Rows[e.RowIndex];

                    updateTaskForm.lblHeading.Text = "Update Task";
                    updateTaskForm.task_ID = int.Parse(row.Cells["Task_ID"].Value.ToString());
                    updateTaskForm.txtTaskTitle.Texts = (row.Cells["Task_Title"].Value).ToString();
                    updateTaskForm.txtTaskDescription.Texts = (row.Cells["Task_Description"].Value.ToString());
                    updateTaskForm.dtpTaskDeadline.Value = DateTime.Parse((row.Cells["Task_Deadline"].Value.ToString()));

                    string status = (row.Cells["Task_Status"].Value).ToString();

                    if (status.Equals("Completed"))
                    {
                        updateTaskForm.ckbTaskCompleted.Checked = true;
                    }
                    else
                    {
                        updateTaskForm.ckbTaskCompleted.Checked = false;
                    }

                    //updateTaskForm.btnDeleteTask.Enabled = true;

                    updateTaskForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgViewTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgViewTasks.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                var task = dgViewTasks.Rows[e.RowIndex].DataBoundItem as TaskWithUsersDto;

                if (task != null)
                {
                    string buttonText = "";

                    if (task.Status == "Completed")
                    {
                        buttonText = "Mark as incomplete";
                    }
                    else if (task.Status == "Not Completed")
                    {
                        buttonText = "Mark as completed";
                    }
                    
                    e.Value = buttonText;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
