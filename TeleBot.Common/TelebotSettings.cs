using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TeleBot.Common.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace TeleBot.Common
{
    public class TelebotSettings : ISettingHandler
    {
       
        public IBotSettings build_settings(string jsonFile)
        {
            try
            {              
                return JsonConvert.DeserializeObject<BotSettings>(jsonFile);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
