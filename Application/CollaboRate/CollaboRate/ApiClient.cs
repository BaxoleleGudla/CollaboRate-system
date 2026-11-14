using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ApiClient
{
    private static readonly HttpClient _httpCLient;

    static ApiClient()
    {
        string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];

        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new InvalidOperationException("Fatal: 'ApiBaseUrl' is missing.");
        }

        _httpCLient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl),

            Timeout = TimeSpan.FromSeconds(30)
        };
    }

    // Expose HttpClient globally for forms
    public static HttpClient HttpClient => _httpCLient;

    // Helper to attach the JWT token after login
    public static void SetAUthToken(string token)
    {
        _httpCLient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}

