using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.DAL.DataObjects
{
    public class Transaction
    {
        public Transaction() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public double TransactionAmount { get; set; }

        public string TransactionName { get; set; }

        public DateTime TransactionLoadDateTime { get; set; }

    }
}
