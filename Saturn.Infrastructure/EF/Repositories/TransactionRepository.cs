using Saturn.Domain;
using System;
using System.Collections.Generic;
using Saturn.Infrastructure.EF.Interfaces;

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
            yield return _context.Transactions.Find(period);
        }
    }
}
