using Saturn.Domain;
using System.Data.Entity;

namespace Saturn.Infrastructure.EF
{
    public class TransactionContext: DbContext
    {
        public TransactionContext(string connectionString) :base(connectionString)
        {
            Database.SetInitializer<TransactionContext>(new DropCreateDatabaseAlways<TransactionContext>());
        }

        public DbSet<Transaction> Transactions {get; set; }

        public DbSet<Merchant> Merchants { get; set; }

        public DbSet<TransactionGroup> TransactionGroups { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}
