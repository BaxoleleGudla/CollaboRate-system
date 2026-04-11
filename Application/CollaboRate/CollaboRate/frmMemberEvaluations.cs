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

        private void button1_Click(object sender, EventArgs e)
        {
            frmUpdateMemberEvaluation updateMemberEvaluationForm = new frmUpdateMemberEvaluation();
            updateMemberEvaluationForm.ShowDialog();
        }

        private void btnEvaluateAllMembers_Click(object sender, EventArgs e)
        {
            frmEvaluateAllMembers evaluateAllMembersForm = new frmEvaluateAllMembers();
            evaluateAllMembersForm.ShowDialog();
        }

        // Method to load ratings
        private async Task<List<RatedMemberDto>> GetRatingsAsync(int groupId, int userId, string keyword = null)
        {
            string url = $"https://collaborateapi.runasp.net/api/Ratings/group/{groupId}/rater/{userId}/rated-members";

            if (string.IsNullOrWhiteSpace(keyword) == false)
            {
                url += $"?keyword={Uri.EscapeDataString(keyword)}";
            }

            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<RatedMemberDto>();
            }

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };


            var ratings = JsonSerializer.Deserialize<List<RatedMemberDto>>(json, options);

            return ratings ?? new List<RatedMemberDto>();
        }

        // Method to display ratings
        public async Task DisplayRatingsAsync(int groupId, int userId, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                var ratings = await GetRatingsAsync(groupId, userId, keyword);

                if (ratings != null)
                {
                    ratingsBindingSource.DataSource = ratings;
                    dgViewMemberEvaluations.AutoGenerateColumns = false;
                    dgViewMemberEvaluations.DataSource = ratingsBindingSource;
                }
                else
                {
                    ratingsBindingSource.DataSource = null;
                    dgViewMemberEvaluations.DataSource = ratingsBindingSource;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading evaluations.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmMemberEvaluations_Load(object sender, EventArgs e)
        {
            await DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID);
        }

        private async void txtSearchMemberName__TextChanged(object sender, EventArgs e)
        {
            await DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID, txtSearchMemberName.Texts);
        }

        private void dgViewMemberEvaluations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    frmUpdateMemberEvaluation updateMemberEvaluationForm = new frmUpdateMemberEvaluation();

                    DataGridViewRow row = this.dgViewMemberEvaluations.Rows[e.RowIndex];

                    updateMemberEvaluationForm.ratee_ID = int.Parse(row.Cells["Member_ID"].Value.ToString());
                    updateMemberEvaluationForm.txtMemberName.Texts = (row.Cells["Member_Name"].Value).ToString();
                    updateMemberEvaluationForm.cmbxScore.SelectedIndex = int.Parse((row.Cells["Member_Score"].Value.ToString())) - 1;
                    updateMemberEvaluationForm.txtAverageScore.Texts = (row.Cells["Score_Average"].Value.ToString());

                    updateMemberEvaluationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "An error occurred while loading evaluation details.", Properties.Resources.Error_Icon);
            }
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
