using System.Collections.Generic;

namespace Saturn.Domain.Interface
{
    public interface IAccountType
    {
        string accountNumber { get; set; }
        string accountType { get; set; }
        int AccountTypeId { get; set; }
        string sortCode { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}