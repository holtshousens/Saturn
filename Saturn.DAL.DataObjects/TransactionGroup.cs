using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saturn.DAL.DataObjects
{
    public class TransactionGroup
    {
        public TransactionGroup() { }

        [Key]
        public int TransactionGroupId { get; set; }

        public string TransactionGroupName { get; set; }

        public IList<Transaction> Transactions { get; set; }
    }
}
