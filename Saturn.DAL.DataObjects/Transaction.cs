using System;
using System.ComponentModel.DataAnnotations;

namespace Saturn.DAL.DataObjects
{
    public class Transaction
    {
        public Transaction() { }

        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public double TransactionAmount { get; set; }

        public string TransactionName { get; set; }

        public DateTime TransactionLoadDate { get; set; }

    }
}
