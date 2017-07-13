using Saturn.Domain;
using Saturn.Infrastructure.EF.Interface;
using System;
using System.Collections.Generic;

namespace Saturn.Infrastructure.EF.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        ITransactionContext Context;

        public TransactionRepository(TransactionContext context) 
            : base(context)
        {
            Context = context;
        }

        public IEnumerable<Transaction> GetTotalFeesForPeriod(string period)
        {
            throw new NotImplementedException();
            //return Context.Transactions.OrderByDescending(c => c.TransactionDate).Equals(period).ToList();
        }

        public IEnumerable<Transaction> GetTotalTransactionsForPeriod(string period)
        {
            throw new NotImplementedException();
        }
    }
}
