
using Saturn.DAL.DataObjects;
using System.Data.Entity;

namespace Saturn.DAL.DataContext
{
    public class TransactionContext: DbContext
    {
        public TransactionContext() { }

        public DbSet<Transaction> Transactions {get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}
