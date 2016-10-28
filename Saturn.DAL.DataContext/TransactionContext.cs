﻿
using Saturn.DAL.DataObjects;
using System.Data.Entity;

namespace Saturn.DAL.DataContext
{
    public class TransactionContext: DbContext
    {
        public TransactionContext(string connectionString) :base(connectionString)
        {
            Database.SetInitializer<TransactionContext>(new DropCreateDatabaseAlways<TransactionContext>());
        }

        public DbSet<Transaction> Transactions {get; set; }

        public DbSet<Merchant> Merchants { get; set; }

        public DbSet<TransactionGroup> TransactionTypes { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}
