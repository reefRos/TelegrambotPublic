using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleBot.Common;
using TeleBot.Common.Interfaces;
using System.Net.Http;
namespace TelegramBotMain
{
    class TeleBot
    {
        private static string settingsFile = "C:\\Users\\user\\TelegramBotMain\\botSettings.json";
        
        static async Task Main(string[] args)
        {
            try
            {
                var jsonFileReader = new JsonFileReader();
                var settingsReader = new TelebotSettings();
                var application = new TelebotHandler(jsonFileReader, settingsReader);
                await application.start(settingsFile);
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);
            }

        }
    }
}
