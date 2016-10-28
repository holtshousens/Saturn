using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
{
    public class TransactionGroup
    {
        public TransactionGroup() { }

        [Key]
        public int TransactionGroupId { get; set; }

        public string TransactionGroupName { get; set; }

        public virtual int? TransactionId { get; set; }

        [InverseProperty("TransactionId")]
        [ForeignKey("TransactionId")]
        public virtual Transaction TransactionsInGroup { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
