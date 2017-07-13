﻿using Saturn.Domain;
using System.Data.Entity;
using Saturn.Infrastructure.EF.Interfaces;

namespace Saturn.Infrastructure.EF
{
    public class TransactionContext : DbContext, ITransactionContext
    {
        public TransactionContext() 
            : base("name=TransactionContext")
        {
            Database.SetInitializer<TransactionContext>(new DropCreateDatabaseAlways<TransactionContext>());
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Transaction> Transactions {get; set; }
        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<TransactionGroup> TransactionGroups { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
    }
}
