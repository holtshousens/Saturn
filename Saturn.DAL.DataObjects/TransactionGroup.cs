using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
{
    public class TransactionGroup
    {
        public TransactionGroup() { }
        
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionGroupId { get; set; }

        public string TransactionGroupName { get; set; }

        // Foreign Key
        

        //[InverseProperty("TransactionId")]
        //[ForeignKey("TransactionId")]
        //public virtual int? TransactionId { get; set; }
        //public virtual Transaction TransactionsInGroup { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
