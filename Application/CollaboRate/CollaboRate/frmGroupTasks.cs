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

        private void dgViewTasks_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    // Mark the task as completed
                    /*
                    DataGridViewRow row = this.dgViewMeetings.Rows[e.RowIndex];

                    int meeting_ID = int.Parse(row.Cells["Meeting_ID"].Value.ToString());
                    await CancelMeetingAsync(meeting_ID);

                    await DisplayMeetingsAsync(CurrentGroup.Group_ID);*/
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
    }
}
