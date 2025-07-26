using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollaboRate
{
    public partial class frmUpdateMemberEvaluation : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        public int ratee_ID = 0;

        public frmUpdateMemberEvaluation()
        {
            InitializeComponent();
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            if (ratee_ID <= 0)
            {
                MessageBox.Show("An unexpected error occured", "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return hasError;
        }

        // Method to update member rating
        public async Task<bool> UpdateRatingAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnSaveChanges.Enabled = false;

                if (InputValidation() == false)
                {
                    string value = cmbxScore.SelectedItem.ToString();

                    int score = int.Parse(value[0].ToString());

                    var updateDto = new UpdateRatingDto
                    {
                        Group_ID = CurrentGroup.Group_ID,
                        Rater_ID = CurrentUser.User_ID,
                        Ratee_ID = ratee_ID,
                        Score = (byte)score
                    };

                    string url = "https://localhost:7287/api/Ratings/ratings";

                    var json = JsonSerializer.Serialize(updateDto);

                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        pbLoadingSpinner.Visible = false;
                        btnSaveChanges.Enabled = true;

                        MessageBox.Show("Rating updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var memberEvaluationsForm = Application.OpenForms.OfType<frmMemberEvaluations>().FirstOrDefault();
                        if (memberEvaluationsForm != null)
                        {
                            await memberEvaluationsForm.DisplayRatingsAsync(CurrentGroup.Group_ID, CurrentUser.User_ID);
                        }

                        this.Close();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();

                        pbLoadingSpinner.Visible = false;
                        btnSaveChanges.Enabled = true;

                        MessageBox.Show($"Failed to update rating.\nStatus: {response.StatusCode}\n{error}", "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                return true;
            }
            catch (HttpRequestException httpEx)
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;

                MessageBox.Show("Request error: " + httpEx.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                btnSaveChanges.Enabled = true;

                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void frmUpdateMemberEvaluation_Load(object sender, EventArgs e)
        {
            
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            await UpdateRatingAsync();
        }
    }
}
