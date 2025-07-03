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

namespace CollaboRate
{
    public partial class frmLogin : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient();

        public frmLogin()
        {
            InitializeComponent();
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
                lblGeneralError.Visible = false;

                if (InputValidation() == false)
                {
                    btnLogin.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;

                    pbLoadingSpinner.Visible = true;
                    pbLoadingSpinner.Refresh();
                    Application.DoEvents();

                    // Run the HTTP call on a background thread to keep UI responsive
                    var loginResult = await Task.Run(async () =>
                    {
                        //using var client = new HttpClient();
                        var loginData = new LoginRequest
                        {
                            Username = txtUsername.Texts.Trim(),
                            Password = txtPassword.Texts
                        };

                        string json = JsonSerializer.Serialize(loginData);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        string apiUrl = ApiBaseUrl + "/login";

                        return await client.PostAsync(apiUrl, content);
                    });

                    if (loginResult.IsSuccessStatusCode)
                    {
                        // Optionally read response content if needed
                        string responseBody = await loginResult.Content.ReadAsStringAsync();

                        // Deserialize and use user info if necessary
                        var user = JsonSerializer.Deserialize<LoginSuccessResponse>(responseBody);

                        pbLoadingSpinner.Visible = false;

                        // Store user information
                        CurrentUser.User_ID = user.User_ID;
                        CurrentUser.Username = user.Username;
                        CurrentUser.Email = user.Email;

                        MessageBox.Show("Login successful!" + "User ID: " + CurrentUser.User_ID + CurrentUser.Username + CurrentUser.Email, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMain mainForm = new frmMain();
                        mainForm.Show();
                        this.Close();
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.Unauthorized)  // 401
                    {
                        // Unauthorized - Invalid credentials
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        lblGeneralError.Text = "Invalid username or password";
                        lblGeneralError.Visible = true;
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.BadRequest)  // 400
                    {
                        // Bad Request - Usually validation errors or missing data
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        MessageBox.Show(errorMessage, "Login Failed - Bad Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.Forbidden)  // 403
                    {
                        // Forbidden - User does not have permission
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        MessageBox.Show(errorMessage, "Login Failed - Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (loginResult.StatusCode == System.Net.HttpStatusCode.InternalServerError)  // 500
                    {
                        // Internal Server Error - Something went wrong on the server
                        MessageBox.Show("Server error occurred. Please try again later.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Other unexpected status codes
                        string errorMessage = await loginResult.Content.ReadAsStringAsync();
                        MessageBox.Show($"Login failed. Server returned status code {(int)loginResult.StatusCode}: {errorMessage}", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
