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
                MessageBox.Show("Error refreshing data: " + ex.Message);
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
            await LoadDataAsync();
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
    }
}
