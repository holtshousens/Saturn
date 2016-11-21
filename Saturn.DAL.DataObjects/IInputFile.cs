using System;

namespace Saturn.DAL.DataObjects
{
    public interface IInputFile
    {
        DateTime TransactionDate { get; set; }
        string TransactionName { get; set; } 
        //public string CardType { get; set; }
        //public string CardUser { get; set; }
        string TransactionGroup { get; set; } 
        //public double AmountCr { get; set; } 
        //public double AmountDr { get; set; } 
        DateTime TransactionLoadDateTime { get; set; }
    }
}