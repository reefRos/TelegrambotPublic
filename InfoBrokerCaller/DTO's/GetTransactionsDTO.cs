using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoBrokerCaller.DTO_s
{
    public class GetTransactionsDTO
    {
        public int? id { get; set; }
        public int customerId { get; set; }
        public int? endUserId { get; set; }
        public string? thirdPartyTransactionId { get; set; }
        public string? thirdPartyUserId { get; set; }
        public string? thirdPartyUserToken { get; set; }
        public double totalPrice { get; set; }
        public int? betAmount { get; set; }
        public int? winAmount { get; set; }
        public string? currencyIso { get; set; }
        public int? status { get; set; }
        public string? description { get; set; }
        public DateTime? creationDate { get; set; }
        public DateTime? lastUpdate { get; set; }
        public List<object>? bets { get; set; }
    }
}
