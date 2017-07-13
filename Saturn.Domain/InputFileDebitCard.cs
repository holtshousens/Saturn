using Saturn.Domain.Interface;
using System;

namespace Saturn.Domain
{
    public class InputFileDebitCard : IInputFile
    {
        public DateTime TransactionDate { get; set; }
        public DateTime TransactionLoadDateTime { get; set; }
        public string TransactionName { get; set; }
        public string TransactionGroup { get; set; }
        public string AccountNumber { get; set; }
        public double Amount { get; set; } 
    }
}
