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
    public partial class frmGroupChats : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private BindingSource ratingsBindingSource = new BindingSource();

        public frmGroupChats()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstChats.Items.Add("Mia Jones" + "  " + "2025/06/17 10:12AM");
            lstChats.Items.Add("When are we going to start with the project guys?");
            lstChats.Items.Add("");
        }

        private void frmGroupChats_Load(object sender, EventArgs e)
        {

        }

        // Method to send a message
        public async Task<bool> SendGroupMessageAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                GroupMessageDto newMessage = new GroupMessageDto
                {
                    Sender_ID = CurrentUser.User_ID,
                    Group_ID = CurrentGroup.Group_ID,
                    Message_Text = txtMessage.Texts,
                    Created_At = DateTime.Now
                };

                var json = JsonSerializer.Serialize(newMessage);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"{ApiBaseUrl}/api/GroupMessages/messages";

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    pbLoadingSpinner.Visible = false;
                    txtMessage.Texts = "";
                    txtMessage.Focus();
                    return true;
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    pbLoadingSpinner.Visible = false;
                    MessageBox.Show($"Failed to send message: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (HttpRequestException ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show($"Network error: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (TaskCanceledException)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show("Request timed out.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Texts) == false)
            {
                SendGroupMessageAsync();
            }
        }
    }
}
