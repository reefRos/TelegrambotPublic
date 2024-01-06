using InfoBrokerCaller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller
{
    public class GetApiHandler
    {
        private readonly IHttpClientService _httpClientService;

        public GetApiHandler(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<string> HandleGetRequest(string url)
        {
            try
            {
                return await _httpClientService.GetAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in HandleGetRequest: {ex.Message}");
                throw; 
            }
        }
    }
}
