using System.Collections.Generic;
using Saturn.Domain.Interface;

namespace Saturn.Domain
{
    public class TransactionGroup : ITransactionGroup
    {
        public int TransactionGroupId { get; set; }
        public string TransactionGroupName { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
