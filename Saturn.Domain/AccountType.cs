using System.Collections.Generic;
using Saturn.Domain.Interfaces;

namespace Saturn.Domain
{
    public class AccountType : IAccountType
    {
        public int AccountTypeId { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountTypeDescription { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
