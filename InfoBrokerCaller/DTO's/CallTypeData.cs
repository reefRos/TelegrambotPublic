using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller.DTO_s
{
    public enum CallType
    {
        Post = 1,
        Get = 2
    }
    public class CallTypeData
    {
        public CallType type { get; set; }
        public string url { get; set; }  
        public string? data { get; set; }
    }
}
