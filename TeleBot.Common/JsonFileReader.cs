using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleBot.Common.Interfaces;

namespace TeleBot.Common
{
    public class JsonFileReader : IJsonFileReader
    {
        public string ReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
