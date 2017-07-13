using System.Data.Entity;
using Saturn.Domain;

namespace Saturn.Infrastructure.EF.Interface
{
    public interface ITransactionContext
    {
        DbSet<AccountType> AccountTypes { get; set; }
        DbSet<Card> Cards { get; set; }
        DbSet<Merchant> Merchants { get; set; }
        DbSet<TransactionGroup> TransactionGroups { get; set; }
        DbSet<Transaction> Transactions { get; set; }
    }
}