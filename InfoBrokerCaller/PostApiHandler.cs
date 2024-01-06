using InfoBrokerCaller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller
{
    public class PostApiHandler
    {
        private readonly IHttpClientService _httpClientService;

        public PostApiHandler(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<string> HandlePostRequest(string url, string data)
        {
            try
            {
                return await _httpClientService.PostAsync(url, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

        }
    }
}
