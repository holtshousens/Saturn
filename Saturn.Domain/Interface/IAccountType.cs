using System.Collections.Generic;

namespace Saturn.Domain.Interface
{
    public interface IAccountType
    {
        string AccountNumber { get; set; }
        string AccountTypeDescription { get; set; }
        int AccountTypeId { get; set; }
        string SortCode { get; set; }
        ICollection<Transaction> Transactions { get; set; }
    }
}