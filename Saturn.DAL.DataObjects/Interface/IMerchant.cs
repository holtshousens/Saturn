using System.Collections.Generic;

namespace Saturn.Domain.Interface
{
    public interface IMerchant
    {
        int MerchantId { get; set; }
        string MerchantName { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}