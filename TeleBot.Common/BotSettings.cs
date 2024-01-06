using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleBot.Common.Interfaces;

namespace TeleBot.Common
{
    public class BotSettings : IBotSettings
    {
        public string BotID { get; set; }
        public long ChatID { get; set; }
    }
}
