using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CollaboRate.Services
{
    public class UserSessionData
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public int LastGroupId { get; set; }
        public string LastGroupName { get; set; }
    }

    public static class SecureStorageService
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "CollaboRate",
            "session.dat"
        );

        public static void SaveSession(UserSessionData session)
        {
            try
            {
                string json = JsonSerializer.Serialize(session);
                byte[] data = Encoding.UTF8.GetBytes(json);
                byte[] encryptedData = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);

                string directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllBytes(FilePath, encryptedData);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save session: {ex.Message}");
            }
        }

        public static UserSessionData LoadSession()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return null;
                }

                byte[] encryptedData = File.ReadAllBytes(FilePath);
                byte[] data = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                string json = Encoding.UTF8.GetString(data);

                return JsonSerializer.Deserialize<UserSessionData>(json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load session: {ex.Message}");
                ClearSession();
                return null;
            }
        }

        public static void ClearSession()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to clear session: {ex.Message}");
            }
        }
    }
}