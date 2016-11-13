using System;

namespace ConsoleApplication
{
    public class InputFile
    {
        public DateTime TransactionDate { get; set; }
        public string TransactionName { get; set; } 
        public string CardType { get; set; }
        public string CardUser { get; set; }
        public string TransactionGroup { get; set; } 
        public double AmountCr { get; set; } 
        public double AmountDr { get; set; } 
    }
}