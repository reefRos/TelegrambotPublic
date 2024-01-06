using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleBot.Common.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Configuration;
using InfoBrokerCaller;
using InfoBrokerCaller.Interfaces;
using InfoBrokerCaller.DTO_s;

namespace TeleBot.Common
{
    public class TelebotHandler : ITeleBot
    {

        static TelegramBotClient client;
        private readonly IJsonFileReader fileReader;
        private IHttpClientService httpClientService;
        private readonly ISettingHandler setting;
        private GetApiHandler getApiHandler;
        private PostApiHandler postApiHandler;
        public TelebotHandler(JsonFileReader fileReader, TelebotSettings settingHandler)
        {
            this.setting = settingHandler;
            this.fileReader = fileReader;
            this.httpClientService = new HttpClientService();
            this.getApiHandler = new GetApiHandler(httpClientService);
            this.postApiHandler = new PostApiHandler(httpClientService);
        }
        public async Task SendHandler(long chatid, CallTypeData request)
        {
            //change to switch case or if else
            //Example for a Post or Get call that sends data to our group. i enumerated the calls in type so the cast is for each value of post or get in the enumeration - Get = 1, Post = 2
            string message = "Connected";
            await client.SendTextMessageAsync(chatid, message);
            if ((int)request.type == 1)
            {
                try
                {
                    var postResult = await postApiHandler.HandlePostRequest(request.url, request.data);
                    Console.WriteLine(postResult);
                    Console.WriteLine($"POST Result: {postResult}");
                    await client.SendTextMessageAsync(chatid, postResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if ((int)request.type == 2)
            {
                try
                {
                    var getResult = await getApiHandler.HandleGetRequest(request.url);
                    Console.WriteLine(getResult);
                    Console.WriteLine($"Get Result: {getResult}");
                    await client.SendTextMessageAsync(chatid, getResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //NO GOOD WHILE TRUE
            //this can be changed to an api call that receives logs and implement the logic for which logs/exceptions to send. for now it sends whatever is typed in console
            while (true)
            {
                message = Console.ReadLine();
                client.SendTextMessageAsync(chatid, message);
            }

        }
        public async Task start(string filePath)
        {
            //here initialize an object which hold the url and data if needed and the call type.
            CallTypeData req = new CallTypeData
            {
                type = CallType.Post, //choose post or get request
                url = "", //enter post or get url
                data = "{}"
            };

            try
            {
                string jsonContent = fileReader.ReadAllText(filePath);
                IBotSettings settingHandler = setting.build_settings(jsonContent);
                client = new TelegramBotClient(settingHandler.BotID);
                await SendHandler(settingHandler.ChatID, req);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
