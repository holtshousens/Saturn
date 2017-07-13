using System.Collections.Generic;
using Saturn.Domain.Interfaces;

namespace Saturn.Domain
{
    public class Merchant : IMerchant
    {
        public int MerchantId { get; set; }
        public string MerchantName { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
