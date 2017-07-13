using Saturn.Domain;
using System.Collections.Generic;

namespace Saturn.Infrastructure.EF.Interface
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        IEnumerable<Transaction> GetTotalTransactionsForPeriod(string period);
        IEnumerable<Transaction> GetTotalFeesForPeriod(string period);
    }
}
