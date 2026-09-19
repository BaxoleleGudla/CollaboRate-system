using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollaboRate.Dtos;
using CollaboRate.Services;

namespace CollaboRate
{
    public partial class frmLogin : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient();

        public frmLogin()
        {
            InitializeComponent();
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

        // Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hIImd, int wMsg, int wParam, int lParam);

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Username validation
            if (string.IsNullOrWhiteSpace(txtUsername.Texts))
            {
                if (!lblUsernameError.Visible)
                    lblUsernameError.Visible = true;

                lblUsernameError.Text = "Please enter username";

                if (txtUsername.BorderColor != Color.Red)
                    txtUsername.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblUsernameError.Visible)
                    lblUsernameError.Visible = false;

                if (txtUsername.BorderColor != Color.DimGray)
                    txtUsername.BorderColor = Color.DimGray;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(txtPassword.Texts))
            {
                if (!lblPasswordError.Visible)
                    lblPasswordError.Visible = true;

                lblPasswordError.Text = "Please enter the password";

                if (txtPassword.BorderColor != Color.Red)
                    txtPassword.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblPasswordError.Visible)
                    lblPasswordError.Visible = false;

                if (txtPassword.BorderColor != Color.DimGray)
                    txtPassword.BorderColor = Color.DimGray;
            }

            return hasError;
        }

        // Login method
        public async Task Login()
        {
            try
            {
                if (InputValidation() == false)
                {
                    btnLogin.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;

                    pbLoadingSpinner.Visible = true;
                    pbLoadingSpinner.Refresh();
                    Application.DoEvents();

                    var loginData = new LoginRequest
                    {
                        Username = txtUsername.Texts.Trim(),
                        Password = txtPassword.Texts
                    };

                    string json = JsonSerializer.Serialize(loginData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    string apiUrl = ApiBaseUrl + "/api/auth/login";

                    var loginResult = await client.PostAsync(apiUrl, content);

                    if (loginResult.IsSuccessStatusCode)
                    {
                        string responseBody = await loginResult.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        var user = JsonSerializer.Deserialize<LoginSuccessResponse>(responseBody, options);

                        pbLoadingSpinner.Visible = false;

                        // Set active session state
                        CurrentUser.User_ID = user.User_ID;
                        CurrentUser.Username = user.Username;
                        CurrentUser.Email = user.Email;

                        // Save encrypted 
                        var session = new UserSessionData
                        {
                            UserId = user.User_ID,
                            Username = user.Username,
                            Email = user.Email,
                            RefreshToken = user.RefreshToken,
                            LastGroupId = 0,
                            LastGroupName = ""
                        };
                        SecureStorageService.SaveSession(session);

                        // SignalR for real time notifications
                        await SignalRService.Instance.InitializeAsync(CurrentUser.User_ID);

                        frmMain mainForm = new frmMain();
                        mainForm.Show();
                        this.Hide();
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)  // 401
                    {
                        // Unauthorized - Invalid credentials
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        AlertBox(Color.LightGoldenrodYellow, Color.Goldenrod, "Warning", "Invalid username or password.", Properties.Resources.Warning_Icon);
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.BadRequest)  // 400
                    {
                        // Bad Request - Usually validation errors or missing data
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Login Failed - Bad Request.", Properties.Resources.Error_Icon);
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.Forbidden)  // 403
                    {
                        // Forbidden - User does not have permission
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Login Failed - Forbidden.", Properties.Resources.Error_Icon);
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.InternalServerError)  // 500
                    {
                        // Internal Server Error - Something went wrong on the server
                        MessageBox.Show("Internal server error c");
                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Server error occurred.", Properties.Resources.Error_Icon);
                    }
                    else
                    {
                        // Other unexpected status codes
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        AlertBox(Color.LightPink, Color.DarkRed, "Error", "Login failed. Try again later.", Properties.Resources.Error_Icon);
                    }
                } 
            }
            catch (Exception ex)
            {
                AlertBox(Color.LightPink, Color.DarkRed, "Error", "Login error occurred.", Properties.Resources.Error_Icon);
            }
            finally
            {
                pbLoadingSpinner.Visible = false; // Hide the spinner
                btnLogin.Enabled = true;       // Re-enable the login button
                txtUsername.Enabled = true;    // Re-enable username input
                txtPassword.Enabled = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await Login();
        }

        private void cbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowPassword.Checked == true)
            {
                txtPassword.PasswordChar = false;
            }
            else
            {
                txtPassword.PasswordChar = true;
            }    
        }

        private void linklblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            registerForm.Show();
            this.Hide();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
