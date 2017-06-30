using Saturn.Domain.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Saturn.Domain
{
    public class Transaction : ITransaction
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
