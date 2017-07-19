using System;
using Saturn.Domain;
using Saturn.Infrastructure.EF.Repositories;

namespace Saturn.Infrastructure.EF.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        TransactionRepository TransactionRepository { get; set; }
        Repository<Card> CardRepository { get; set; }
        Repository<AccountType> AccountTypeRepository { get; set; }
        Repository<Merchant> MerchantRepository { get; set; }
        Repository<TransactionGroup> TransactionGroupRepository { get; set; }

        void Complete();

    }
}