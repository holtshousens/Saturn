using System;

namespace Saturn.DAL.DataObjects
{
    public interface IInputFile
    {
        DateTime TransactionDate { get; set; }
        string TransactionName { get; set; } 
        string TransactionGroup { get; set; } 
        DateTime TransactionLoadDateTime { get; set; }
    }
}