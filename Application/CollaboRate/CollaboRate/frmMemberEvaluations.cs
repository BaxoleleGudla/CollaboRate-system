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
    public partial class frmMemberEvaluations : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource ratingsBindingSource = new BindingSource();

        public frmMemberEvaluations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgViewMemberEvaluations.Rows.Add("Mia", "5", "20", "Yes");
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
            string url = $"https://localhost:7287/api/Ratings/group/{groupId}/rater/{userId}/rated-members";

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

        // Method to display meetings
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
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    updateMemberEvaluationForm.cmbxScore.Text = (row.Cells["Member_Score"].Value.ToString());
                    updateMemberEvaluationForm.txtAverageScore.Text = (row.Cells["Score_Average"].Value.ToString());

                    updateMemberEvaluationForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occured", "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
