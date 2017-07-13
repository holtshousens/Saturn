using System.Collections.Generic;
using Saturn.Domain;

namespace Saturn.Infrastructure.EF.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetTotalTransactionsForPeriod(string period);
        IEnumerable<Transaction> GetTotalFeesForPeriod(string period);
    }
}
