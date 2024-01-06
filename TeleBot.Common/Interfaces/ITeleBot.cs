using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBot.Common.Interfaces
{
    interface ITeleBot
    {
        Task start(string filePath);

    }
}
