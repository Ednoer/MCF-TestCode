using BpkbMvc.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BpkbMvc.Services
{
    public class TrBpkbService
    {
        private readonly HttpClient _httpClient;

        public TrBpkbService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<TrBpkbModel> GetTrBpkb(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("api/TrBpkb/GetTrBpkb");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TrBpkbModel>();
        }

        public async Task UpsertTrBpkb(TrBpkbModel trBpkbModel, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("api/TrBpkb/UpsertTrBpkb", trBpkbModel);
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<Location>> GetLocations(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("api/MsStorageLocation");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<Location>>();
        }
    }
}
