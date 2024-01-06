using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleBot.Common.Interfaces
{
    interface ISendReceive
    {
        void SendHandler(long chatid);
    }
}
