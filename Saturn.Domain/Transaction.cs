using Saturn.Domain.Interface;
using System;

namespace Saturn.Domain
{
    public class Transaction : ITransaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionName { get; set; }
        public DateTime TransactionLoadDateTime { get; set; }
    }
}
