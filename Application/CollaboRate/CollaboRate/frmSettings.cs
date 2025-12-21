using CollaboRate.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CollaboRate
{
    public partial class frmSettings : Form
    {
        private const string ApiBaseUrl = "https://collaborateapi.runasp.net";
        private readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtUsername.Texts = CurrentUser.Username;
            txtEmail.Texts = CurrentUser.Email;
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

        // Method to check for profile errors
        private bool ProfileInputValidation()
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

            return hasError;
        }

        // Method to update username and email
        public async Task<bool> UpdateUserProfileAsync(int userId, string username, string email)
        {
            try
            {
                if (ProfileInputValidation() == false)
                {
                    btnSaveProfileChanges.Enabled = false;
                    btnSaveProfileChanges.ButtonText = "";
                    pbLoadingSpinner.Visible = true;

                    var updateDto = new UpdateUserDto
                    {
                        User_ID = userId,
                        Username = username,
                        Email = email
                    };

                    var json = JsonSerializer.Serialize(updateDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{ApiBaseUrl}/api/Account/users/{userId}";

                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        btnSaveProfileChanges.Enabled = true;
                        btnSaveProfileChanges.ButtonText = "Save Profile Changes";
                        pbLoadingSpinner.Visible = false;

                        CurrentUser.Username = username;
                        CurrentUser.Email = email;

                        MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        string errorMsg = await response.Content.ReadAsStringAsync();

                        btnSaveProfileChanges.Enabled = true;
                        btnSaveProfileChanges.ButtonText = "Save Profile Changes";
                        pbLoadingSpinner.Visible = false;

                        MessageBox.Show($"Failed to update profile: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                btnSaveProfileChanges.Enabled = true;
                btnSaveProfileChanges.ButtonText = "Save Profile Changes";
                pbLoadingSpinner.Visible = false;

                MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to check for password errors
        private bool PasswordInputValidation()
        {
            bool hasError = false;

            // Current password validation
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Texts))
            {
                if (!lblCurrentPasswordError.Visible)
                    lblCurrentPasswordError.Visible = true;

                lblCurrentPasswordError.Text = "Please enter current password";

                if (txtCurrentPassword.BorderColor != Color.Red)
                    txtCurrentPassword.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblCurrentPasswordError.Visible)
                    lblCurrentPasswordError.Visible = false;

                if (txtCurrentPassword.BorderColor != Color.DimGray)
                    txtCurrentPassword.BorderColor = Color.DimGray;
            }

            // New password validation
            if (string.IsNullOrWhiteSpace(txtNewPassword.Texts))
            {
                if (!lblNewPasswordError.Visible)
                    lblNewPasswordError.Visible = true;

                lblNewPasswordError.Text = "Please enter new password";

                if (txtNewPassword.BorderColor != Color.Red)
                    txtNewPassword.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblNewPasswordError.Visible)
                    lblNewPasswordError.Visible = false;

                if (txtNewPassword.BorderColor != Color.DimGray)
                    txtNewPassword.BorderColor = Color.DimGray;
            }

            // Confirm new password validation
            if (string.IsNullOrWhiteSpace(txtConfirmNewPassword.Texts))
            {
                if (!lblConfirmNewPasswordError.Visible)
                    lblConfirmNewPasswordError.Visible = true;

                lblConfirmNewPasswordError.Text = "Please enter confirmation password";

                if (txtConfirmNewPassword.BorderColor != Color.Red)
                    txtConfirmNewPassword.BorderColor = Color.Red;

                hasError = true;
            }
            else
            {
                if (lblConfirmNewPasswordError.Visible)
                    lblConfirmNewPasswordError.Visible = false;

                if (txtConfirmNewPassword.BorderColor != Color.DimGray)
                    txtConfirmNewPassword.BorderColor = Color.DimGray;
            }

            return hasError;
        }

        private async void btnSaveProfileChanges_Click(object sender, EventArgs e)
        {
            await UpdateUserProfileAsync(CurrentUser.User_ID, txtUsername.Texts, txtEmail.Texts);
        }

        // Method to update password
        public async Task<bool> UpdateUserPasswordAsync(int userId, string currentPassword, string newPassword, string confirmPassword)
        {
            try
            {
                if (PasswordInputValidation() == false)
                {
                    btnChangePassword.Enabled = false;
                    btnChangePassword.ButtonText = "";
                    pbLoadingSpinnerChangePassword.Visible = true; 

                    var passwordDto = new UpdatePasswordDto
                    {
                        User_ID = userId,
                        CurrentPassword = currentPassword,
                        NewPassword = newPassword,
                        ConfirmPassword = confirmPassword
                    };

                    var json = JsonSerializer.Serialize(passwordDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = $"{ApiBaseUrl}/api/Account/users/{userId}/password";

                    var response = await client.PutAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        btnChangePassword.Enabled = true;
                        btnChangePassword.ButtonText = "Change Password";
                        pbLoadingSpinnerChangePassword.Visible = false;

                        MessageBox.Show("Password updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    else
                    {
                        string errorMsg = await response.Content.ReadAsStringAsync();

                        btnChangePassword.Enabled = true;
                        btnChangePassword.ButtonText = "Change Password";
                        pbLoadingSpinnerChangePassword.Visible = false;

                        MessageBox.Show($"Failed to update password: {errorMsg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                btnChangePassword.Enabled = true;
                btnChangePassword.ButtonText = "Change Password";
                pbLoadingSpinnerChangePassword.Visible = false;

                MessageBox.Show($"Error: {ex.Message}", "Error Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            await UpdateUserPasswordAsync(CurrentUser.User_ID, txtCurrentPassword.Texts, txtNewPassword.Texts, txtConfirmNewPassword.Texts);
        }
    }
}
