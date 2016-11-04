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

        public string TransactionDate { get; set; }

        public string TransactionAmount { get; set; }

        public string TransactionName { get; set; }

        public string TransactionLoadDate { get; set; }

    }
}
