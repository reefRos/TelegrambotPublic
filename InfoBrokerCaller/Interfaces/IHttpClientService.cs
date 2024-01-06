using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller.Interfaces
{
    public interface IHttpClientService
    {
            Task<string> GetAsync(string url);
            Task<string> PostAsync(string url, string data);
    }
}
