using InfoBrokerCaller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller
{
    public class HttpClientService : IHttpClientService
    {
        private HttpClient _httpClient;

        public HttpClientService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAsync: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }

        public async Task<string> PostAsync(string url, string data)
        {
            try
            {
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in PostAsync: {ex.Message}");
                throw; // Re-throw the exception after logging
            }
        }
    }
}
