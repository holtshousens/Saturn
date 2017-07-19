using Saturn.Domain;
using System.Data.Entity;
using Saturn.Infrastructure.EF.Interfaces;

namespace Saturn.Infrastructure.EF
{
    public sealed class TransactionContext : DbContext, ITransactionContext
    {
        public TransactionContext() 
            : base("name=TransactionContext")
        {
            Database.SetInitializer<TransactionContext>(new DropCreateDatabaseAlways<TransactionContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Transaction> Transactions {get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<TransactionGroup> TransactionGroups { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
