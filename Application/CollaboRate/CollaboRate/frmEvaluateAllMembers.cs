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
using System.Web;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CollaboRate
{
    public partial class frmEvaluateAllMembers : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource usersBindingSource = new BindingSource();

        public frmEvaluateAllMembers()
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

        // Method to check if all members have ratings
        private bool AllMembersRated()
        {
            try
            {
                // Commit any pending edits
                dgViewUsers.EndEdit();

                foreach (DataGridViewRow row in dgViewUsers.Rows)
                {
                    var cell = row.Cells["User_Score"] as DataGridViewComboBoxCell;

                    if (cell == null)
                    {
                        continue;
                    }

                    // Check if cell value is null or not set
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        // Found at least one member with no rating
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while checking evaluations.", Properties.Resources.Error_Icon);
                return false;
            }

            return true;
        }

        // Method to evaluate members
        private async Task<bool> SubmitRatingsAsync()
        {
            try
            {
                dgViewUsers.EndEdit();

                pbLoadingSpinner.Visible = true;
                btnSubmitEvaluations.Enabled = false;

                if (AllMembersRated() == true)
                {
                    var ratings = new List<RatingDto>();

                    foreach (DataGridViewRow row in dgViewUsers.Rows)
                    {
                        // Get ratee ID
                        if (!int.TryParse(row.Cells["User_ID"].Value?.ToString(), out int rateeId))
                        {
                            continue; // Skip invalid rows
                        }

                        var val = row.Cells["User_Score"].Value?.ToString();

                        if (string.IsNullOrEmpty(val) || !int.TryParse(val[0].ToString(), out int score) || score < 1 || score > 5)
                        {
                            pbLoadingSpinner.Visible = false;
                            btnSubmitEvaluations.Enabled = true;

                            AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Please select a rating (1-5) for all members.", Properties.Resources.Warning_Icon);
                            return false;
                        }

                        ratings.Add(new RatingDto
                        {
                            Group_ID = CurrentGroup.Group_ID,
                            Rater_ID = CurrentUser.User_ID,
                            Ratee_ID = rateeId,
                            Score = (byte)score
                        });
                    }

                    if (ratings.Count == 0)
                    {
                        pbLoadingSpinner.Visible = false;
                        btnSubmitEvaluations.Enabled = true;

                        AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "No ratings to submit.", Properties.Resources.Warning_Icon);
                        return false;
                    }

                    var json = JsonSerializer.Serialize(ratings);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"https://collaborateapi.runasp.net/api/Ratings/ratings";

                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        pbLoadingSpinner.Visible = false;
                        btnSubmitEvaluations.Enabled = true;

                        AlertBox(Color.LightGreen, Color.SeaGreen, "Success", "Evaluations submitted successfully.", Properties.Resources.Success_Icon);

                        var memberEvaluationsForm = Application.OpenForms.OfType<frmMemberEvaluations>().FirstOrDefault();
                        if (memberEvaluationsForm != null)
                        {
                            await memberEvaluationsForm.DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID);
                        }
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();

                        pbLoadingSpinner.Visible = false;
                        btnSubmitEvaluations.Enabled = true;

                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Failed to sumbit evaluations.", Properties.Resources.Error_Icon);
                        return false;
                    }
                }
                else
                {
                    pbLoadingSpinner.Visible = false;
                    btnSubmitEvaluations.Enabled = true;

                    AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Please evaluate all members.", Properties.Resources.Warning_Icon);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnSubmitEvaluations.Enabled = true;

                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Error occurred while submitting evaluations.", Properties.Resources.Error_Icon);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
                btnSubmitEvaluations.Enabled = true;
            }
        }

        private async void btnSubmitEvaluations_Click(object sender, EventArgs e)
        {
            await SubmitRatingsAsync();
        }

        // Method to load group members
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
                    AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading group members.", Properties.Resources.Error_Icon);
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
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Network error occurred while loading members.", Properties.Resources.Error_Icon);
                return null;
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading members.", Properties.Resources.Error_Icon);
                return null;
            }
        }

        // Method to display group members
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
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while displaying members.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmEvaluateAllMembers_Load(object sender, EventArgs e)
        {
            await DisplayMembersAsync(CurrentGroup.Group_ID);
        }

        private async void txtSearchUsername__TextChanged(object sender, EventArgs e)
        {
            await DisplayMembersAsync(CurrentGroup.Group_ID, txtSearchUsername.Texts);
        }
    }
}
