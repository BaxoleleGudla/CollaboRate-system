using CollaboRate.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
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
using System.Windows.Forms.VisualStyles;

namespace CollaboRate
{
    public partial class frmMemberEvaluations : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource ratingsBindingSource = new BindingSource();

        private HubConnection _evaluationsConnection;
        private string _joinedEvaluationRoom;

        public frmMemberEvaluations()
        {
            InitializeComponent();

            try
            {
                // Code to map the ratings scores
                var ratingOptions = new[] {
                new { Text = "1. Unsatisfactory", Value = (byte)1 },
                new { Text = "2", Value = (byte)2 },
                new { Text = "3", Value = (byte)3 },
                new { Text = "4", Value = (byte)4 },
                new { Text = "5. Excellent", Value = (byte)5 }
                };

                DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgViewMemberEvaluations.Columns["MyCurrentScore"];
                col.DataSource = ratingOptions;
                col.DisplayMember = "Text"; // What the user sees
                col.ValueMember = "Value";   // What the code saves
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while initializing ratings.", Properties.Resources.Error_Icon); AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while updating group.", Properties.Resources.Error_Icon);
            }
        }

        private async Task InitializeSignalRAsync()
        {
            try
            {
                _evaluationsConnection = new HubConnectionBuilder()
                    .WithUrl("https://collaborateapi.runasp.net/hubs/evaluations")
                    .WithAutomaticReconnect()
                    .Build();

                // Sent by RatingsController.BatchUpsert
                _evaluationsConnection.On<int>("RefreshEvaluations", (raterId) =>
                {
                    // The person who saved already reloads in SaveEvaluations, so skip our own event
                    if (raterId == CurrentUser.User_ID)
                    {
                        return;
                    }

                    if (this.IsDisposed || !this.IsHandleCreated)
                    {
                        return;
                    }

                    this.BeginInvoke(new Action(async () => await RefreshFromRealTimeAsync()));
                });

                // Join again after serer has forgotten our room
                _evaluationsConnection.Reconnected += async (connectionId) =>
                {
                    _joinedEvaluationRoom = null;
                    await JoinCurrentGroupRoomAsync();

                    if (!this.IsDisposed && this.IsHandleCreated)
                    {
                        this.BeginInvoke(new Action(async () => await RefreshFromRealTimeAsync()));
                    }
                };

                await _evaluationsConnection.StartAsync();
                await JoinCurrentGroupRoomAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Real-time connection error occurred.", Properties.Resources.Error_Icon);
            }
        }

        // Reloads the grid because of a real-time event
        private async Task RefreshFromRealTimeAsync()
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (dgViewMemberEvaluations.IsCurrentCellInEditMode)
            {
                return;
            }

            // Keep the current search text so a filtered list stays filtered
            await LoadDataAsync(txtSearchMemberName.Texts);
        }

        // Joins the SignalR room for CurrentGroup
        private async Task JoinCurrentGroupRoomAsync()
        {
            if (_evaluationsConnection == null || _evaluationsConnection.State != HubConnectionState.Connected)
            {
                return;
            }

            string newRoom = $"Evaluations_{CurrentGroup.Group_ID}";

            if (_joinedEvaluationRoom == newRoom)
            {
                return;
            }

            // Leave the previous room first (when the group was switched
            if (_joinedEvaluationRoom != null)
            {
                await _evaluationsConnection.InvokeAsync("LeaveEvaluationRoom", _joinedEvaluationRoom);
            }

            await _evaluationsConnection.InvokeAsync("JoinEvaluationRoom", newRoom);
            _joinedEvaluationRoom = newRoom;
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

        // Method to save evaluations
        private async Task SaveEvaluations()
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                // Commit any pending edits
                dgViewMemberEvaluations.EndEdit();

                var updates = new List<RatingUpdateDto>();
                foreach (DataGridViewRow row in dgViewMemberEvaluations.Rows)
                {
                    if (row.Cells["MyCurrentScore"].Value != null)
                    {
                        updates.Add(new RatingUpdateDto
                        {
                            Group_ID = CurrentGroup.Group_ID,
                            Rater_ID = CurrentUser.User_ID,
                            Ratee_ID = (int)row.Cells["User_ID"].Value,
                            Score = (byte)row.Cells["MyCurrentScore"].Value
                        });
                    }
                }

                var response = await client.PostAsync("https://collaborateapi.runasp.net/api/Ratings/batch-upsert", new StringContent(JsonSerializer.Serialize(updates), Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    await LoadDataAsync();
                    pbLoadingSpinner.Visible = false;
                    dgViewMemberEvaluations.ClearSelection();
                    dgViewMemberEvaluations.CurrentCell = null;
                    AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Group evaluations saved successfully.", Properties.Resources.Success_Icon);
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                dgViewMemberEvaluations.ClearSelection();
                dgViewMemberEvaluations.CurrentCell = null;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occured while saving evaluations.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void btnEvaluateAllMembers_Click(object sender, EventArgs e)
        {
            await SaveEvaluations();
        }

        // New method to load data
        private async Task LoadDataAsync(string keyword = "")
        {
            try
            {
                dgViewMemberEvaluations.ClearSelection();
                dgViewMemberEvaluations.CurrentCell = null;

                pbLoadingSpinner.Visible = true;

                // Construct the URL with an optional search keyword
                string url = $"{ApiBaseUrl}/api/Ratings/group/{CurrentGroup.Group_ID}/status-for/{CurrentUser.User_ID}";

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    url += $"?keyword={Uri.EscapeDataString(keyword)}";
                }

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<List<RatedMemberDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    // Prevent the grid from deleting your custom GUI columns
                    dgViewMemberEvaluations.AutoGenerateColumns = false;

                    dgViewMemberEvaluations.DataSource = data;

                    // Re-apply colors
                    SetupRobustGrid();
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading evaluations.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        // Method to setup data grid view styling
        public void SetupRobustGrid()
        {
            try
            {
                // Heatmap Styling
                // Ensure we actually have rows to style
                if (dgViewMemberEvaluations.Rows.Count == 0) return;

                foreach (DataGridViewRow row in dgViewMemberEvaluations.Rows)
                {
                    // Get the data object for accuracy
                    var item = row.DataBoundItem as RatedMemberDto;
                    if (item == null) continue;

                    // 1. Bright Heatmap for Average Score
                    if (item.AverageScore >= 4.0)
                    {
                        row.Cells["AverageScore"].Style.ForeColor = Color.ForestGreen;
                        row.Cells["AverageScore"].Style.Font = new Font(dgViewMemberEvaluations.Font, FontStyle.Bold);
                    }
                    else if (item.AverageScore > 0 && item.AverageScore < 2.5)
                    {
                        row.Cells["AverageScore"].Style.ForeColor = Color.Red;
                        row.Cells["AverageScore"].Style.Font = new Font(dgViewMemberEvaluations.Font, FontStyle.Bold);
                    }

                    // 2. Balanced Participation Status (Sophisticated Visibility)
                    // We use a calm yellow for 'Incomplete' and a professional green for 'Complete'
                    if (item.ReceivedRatingsCount < item.PotentialRatingsCount)
                    {
                        // A soft, recognizable gold/yellow that doesn't "glow"
                        row.Cells["RatingStatus"].Style.BackColor = Color.Khaki;
                        row.Cells["RatingStatus"].Style.ForeColor = Color.DarkSlateGray; // Darker text for better contrast
                    }
                    else
                    {
                        // A professional, sea-toned green that feels stable
                        row.Cells["RatingStatus"].Style.BackColor = Color.MediumSeaGreen;
                        row.Cells["RatingStatus"].Style.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to heatmap.", Properties.Resources.Error_Icon);
            }
        }

        private async void frmMemberEvaluations_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Apartment state: " + System.Threading.Thread.CurrentThread.GetApartmentState());
            await LoadDataAsync();
            await InitializeSignalRAsync();
        }

        private async void txtSearchMemberName__TextChanged(object sender, EventArgs e)
        {
            await LoadDataAsync(txtSearchMemberName.Texts);
        }

        private void frmMemberEvaluations_Resize(object sender, EventArgs e)
        {
            if (pbLoadingSpinner != null)
            {
                // Calculate center: (Parent Width / 2) - (Control Width / 2)
                int x = (this.ClientSize.Width - pbLoadingSpinner.Width) / 2;
                int y = (this.ClientSize.Height - pbLoadingSpinner.Height) / 2;

                pbLoadingSpinner.Location = new Point(x, y);
            }
        }

        private async void frmMemberEvaluations_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_evaluationsConnection != null)
            {
                try
                {
                    if (_joinedEvaluationRoom != null && _evaluationsConnection.State == HubConnectionState.Connected)
                    {
                        await _evaluationsConnection.InvokeAsync("LeaveEvaluationRoom", _joinedEvaluationRoom);
                    }

                    await _evaluationsConnection.StopAsync();
                    await _evaluationsConnection.DisposeAsync();
                }
                catch (Exception)
                {
                    // Ignore
                }
            }
        }
    }
}
