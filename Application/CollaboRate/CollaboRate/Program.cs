using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollaboRate.Dtos;
using CollaboRate.Services;

namespace CollaboRate
{
    internal static class Program
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";

        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var session = SecureStorageService.LoadSession();

            if (session != null && !string.IsNullOrEmpty(session.RefreshToken))
            {
                bool isAuthenticated = await TryRefreshTokenAsync(session);

                if (isAuthenticated)
                {
                    CurrentUser.User_ID = session.UserId;
                    CurrentUser.Username = session.Username;
                    CurrentUser.Email = session.Email;
                    CurrentGroup.Group_ID = session.LastGroupId;
                    CurrentGroup.Group_Name = session.LastGroupName;

                    try
                    {
                        await SignalRService.Instance.InitializeAsync(CurrentUser.User_ID);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"SignalR init error: {ex.Message}");
                    }

                    Application.Run(new frmMain());
                    return;
                }
            }

            SecureStorageService.ClearSession();
            Application.Run(new frmLogin());
        }

        public static async Task<bool> TryRefreshTokenAsync(UserSessionData session)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var payload = new { RefreshToken = session.RefreshToken, UserId = session.UserId };
                    string json = JsonSerializer.Serialize(payload);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(ApiBaseUrl + "/api/auth/refresh-token", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var tokenResult = JsonSerializer.Deserialize<LoginSuccessResponse>(responseBody, options);

                        session.RefreshToken = tokenResult?.RefreshToken ?? session.RefreshToken;
                        SecureStorageService.SaveSession(session);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Refresh token error: {ex.Message}");
            }

            return false;
        }
    }
}