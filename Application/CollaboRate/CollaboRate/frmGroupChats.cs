using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace CollaboRate
{
    public partial class frmGroupChats : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };
        private HubConnection _connection;

        public frmGroupChats()
        {
            InitializeComponent();

            _connection = new HubConnectionBuilder()
                .WithUrl($"{ApiBaseUrl}/chathub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string, string, DateTime>("ReceiveMessage", (senderUsername, messageText, createdAt) =>
            {
                this.Invoke((Action)(() =>
                {
                    lstChats.BeginUpdate();
                    lstChats.Items.Add($"{senderUsername} {createdAt:yyyy/MM/dd} {createdAt:HH:mm}");
                    lstChats.Items.Add(string.IsNullOrEmpty(messageText) ? "[No message]" : messageText);
                    lstChats.Items.Add("");
                    lstChats.EndUpdate();

                    lstChats.SelectedIndex = lstChats.Items.Count - 1;
                    lstChats.SelectedIndex = -1;
                }));
            });
        }

        // Method to get messages
        public async Task<List<MessageDto>> GetMessagesAsync(int groupId, int pageNumber = 1, int pageSize = 50, string keyword = null)
        {
            try
            {
                string url = $"{ApiBaseUrl}/api/GroupMessages/messages?groupId={groupId}&pageNumber={pageNumber}&pageSize={pageSize}&keyword={keyword}";

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Failed to load messages: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<MessageDto>();
                }

                string json = await response.Content.ReadAsStringAsync();
                using (var doc = JsonDocument.Parse(json))
                {
                    if (!doc.RootElement.TryGetProperty("messages", out var messagesElement))
                    {
                        MessageBox.Show("Response JSON does not contain 'Messages' property.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<MessageDto>();
                    }

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var messages = JsonSerializer.Deserialize<List<MessageDto>>(messagesElement.GetRawText(), options);

                    return messages?.OrderBy(m => m.Created_At).ToList() ?? new List<MessageDto>();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MessageDto>();
            }
        }

        // Method to display the messages
        public async Task DisplayMessages(int groupId, int pageNumber = 1, int pageSize = 50, string keyword = null)
        {
            try
            {
                pbLoadingSpinner.Visible = true;

                lstChats.BeginUpdate();
                lstChats.Items.Clear();

                var messages = await GetMessagesAsync(groupId, pageNumber, pageSize, keyword);

                foreach (var msg in messages)
                {
                    lstChats.Items.Add($"{msg.SenderUsername} {msg.Created_At:yyyy/MM/dd} {msg.Created_At:HH:mm}");
                    lstChats.Items.Add(string.IsNullOrEmpty(msg.Message_Text) ? "[No message]" : msg.Message_Text);
                    lstChats.Items.Add("");
                }

                lstChats.EndUpdate();

                // Scroll to bottom to show the latest message
                if (lstChats.Items.Count > 0)
                {
                    lstChats.SelectedIndex = lstChats.Items.Count - 1;
                    lstChats.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false;
            }
        }

        private async void frmGroupChats_Load(object sender, EventArgs e)
        {
            await _connection.StartAsync();
            await DisplayMessages(CurrentGroup.Group_ID);
        }

        // Method to send a message
        public async Task<bool> SendGroupMessageAsync()
        {
            try
            {
                pbLoadingSpinner.Visible = true;
                btnSendMessage.Enabled = false;

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
                    btnSendMessage.Enabled = true;
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

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Texts) == false)
            {
                await SendGroupMessageAsync();
            }
        }

        private void lstChats_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            string itemText = lstChats.Items[e.Index].ToString();

            // If this is an item where senderName is shown (e.g. every third item mod 3 == 0)
            bool isSenderLine = e.Index % 3 == 0;

            Font font = isSenderLine
                ? new Font(e.Font, FontStyle.Bold)
                : e.Font;

            TextRenderer.DrawText(e.Graphics, itemText, font, e.Bounds, e.ForeColor, TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }

        private CancellationTokenSource _cts = null;

        private async void txtSearchMessage__TextChanged(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                await Task.Delay(300, _cts.Token); // Wait 300ms for pauses in typing
                await DisplayMessages(CurrentGroup.Group_ID, 1, 50, txtSearchMessage.Texts);
            }
            catch (TaskCanceledException) { }
        }

        // Dispose connection on form close
        protected override async void OnFormClosing(FormClosingEventArgs e)
        { 
            if (_connection != null)
            {
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
            base.OnFormClosing(e);
        }
    }
}
