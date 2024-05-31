using BpkbMvc.Models;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BpkbMvc.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> Login(LoginModel loginModel, CancellationToken cancellationToken)
        {
            try
            {
                HttpResponseMessage response = await System.Net.Http.HttpClientExtensions.PostAsJsonAsync(_httpClient, "/api/Auth/Login", loginModel, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {
                    Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"An error occurred while sending the request: {ex.Message}");
                return null;
            }
        }
    }
}
