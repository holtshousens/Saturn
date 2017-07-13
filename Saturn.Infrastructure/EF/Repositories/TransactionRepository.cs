using Saturn.Domain;
using Saturn.Infrastructure.EF.Interface;
using System;
using System.Collections.Generic;

namespace Saturn.Infrastructure.EF.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly TransactionContext _context;

        public TransactionRepository(TransactionContext context) 
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetTotalFeesForPeriod(string period)
        {
            yield return _context.Transactions.Find(period);
        }

        public IEnumerable<Transaction> GetTotalTransactionsForPeriod(string period)
        {
            throw new NotImplementedException();
        }
    }
}
