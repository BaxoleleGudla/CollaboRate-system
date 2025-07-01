using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CollaboRate.Dtos;

namespace CollaboRate
{
    public partial class frmRegister : Form
    {
        private const string ApiBaseUrl = "https://localhost:7287";
        private readonly HttpClient client = new HttpClient();

        public frmRegister()
        {
            InitializeComponent();
        }

        // Method to check email validity
        public bool IsValidEmail(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method to check for errors
        private bool InputValidation()
        {
            bool hasError = false;

            // Email validation
            if (string.IsNullOrWhiteSpace(txtEmail.Texts))
            {
                if (!lblEmailError.Visible)
                    lblEmailError.Visible = true;

                lblEmailError.Text = "Please enter email";

                if (txtEmail.BorderColor != Color.Red)
                    txtEmail.BorderColor = Color.Red;

                hasError = true;
            }
            else if (IsValidEmail(txtEmail.Texts) == false)
            {
                if (!lblEmailError.Visible)
                    lblEmailError.Visible = true;

                lblEmailError.Text = "Invalid email";

                if (txtEmail.BorderColor != Color.Red)
                    txtEmail.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblEmailError.Visible)
                    lblEmailError.Visible = false;

                if (txtEmail.BorderColor != Color.DimGray)
                    txtEmail.BorderColor = Color.DimGray;
            }

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

        // Sign up method
        public async Task signUp()
        {
            try
            {
                lblGeneralError.Visible = false;

                if (InputValidation() == false)
                {
                    btnSignUp.Enabled = false;
                    txtEmail.Enabled = false;
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;

                    pbLoadingSpinner.Visible = true;
                    pbLoadingSpinner.Refresh();
                    Application.DoEvents();

                    //using var client = new HttpClient();
                    var newUser = new User
                    {
                        Username = txtUsername.Texts.Trim(),
                        Email = txtEmail.Texts.Trim(),
                        PasswordHash = txtPassword.Texts,
                        Created_At = DateTime.UtcNow
                    };

                    // Serialize user object to JSON
                    string json = JsonSerializer.Serialize(newUser);

                    // Prepare HTTP content with JSON
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // API endpoint URL for adding users
                    string apiUrl = ApiBaseUrl + "/api/users";

                    // Await the async POST call
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Read response content
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize and use user info
                        var user = JsonSerializer.Deserialize<LoginSuccessResponse>(responseBody);

                        pbLoadingSpinner.Visible = false;

                        // Store user information
                        CurrentUser.User_ID = user.User_ID;
                        CurrentUser.Username = user.Username;
                        CurrentUser.Email = user.Email;

                        MessageBox.Show("Sign up successful!" + CurrentUser.User_ID + CurrentUser.Username + CurrentUser.Email, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMain mainForm = new frmMain();
                        mainForm.Show();
                        this.Hide();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)  // 401
                    {
                        // Unauthorized - Invalid credentials
                        pbLoadingSpinner.Visible = false;
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        lblGeneralError.Text = responseBody;
                        lblGeneralError.Visible = true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)  // 400
                    {
                        // Bad Request - Usually validation errors or missing data
                        pbLoadingSpinner.Visible = false;
                        lblGeneralError.Text = "Invalid information entered";
                        lblGeneralError.Visible = true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)  // 403
                    {
                        // Forbidden - User does not have permission
                        pbLoadingSpinner.Visible = false;
                        lblGeneralError.Text = "You do not have permission to sign up";
                        lblGeneralError.Visible = true;
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)  // 500
                    {
                        pbLoadingSpinner.Visible = false;
                        lblGeneralError.Text = "Please try again later";
                        lblGeneralError.Visible = true;
                    }
                    else
                    {
                        // Other unexpected status codes
                        pbLoadingSpinner.Visible = false;
                        MessageBox.Show($"Sign up failed. Server returned status code {(int)response.StatusCode}: {responseBody}", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                pbLoadingSpinner.Visible = false;
                MessageBox.Show("Error: " + ex.Message, "Error Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pbLoadingSpinner.Visible = false; // Hide the spinner
                btnSignUp.Enabled = true;       // Re-enable the login button
                txtEmail.Enabled = true;       // Re-enable the email textbox
                txtUsername.Enabled = true;    // Re-enable username textbox
                txtPassword.Enabled = true;    // Re-enable password textbox
            }
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            await signUp();   
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

        private void linklblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            this.Hide();
        }

        private void pbxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
    }
}
