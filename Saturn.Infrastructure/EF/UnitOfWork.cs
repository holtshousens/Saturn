using System;
using Saturn.Domain;
using Saturn.Infrastructure.EF.Interfaces;
using Saturn.Infrastructure.EF.Repositories;

namespace Saturn.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransactionContext _context = new TransactionContext();
        private TransactionRepository _transactionRepository;
        private Repository<Card> _cardRepository;
        private Repository<AccountType> _accountTypeRepository;
        private Repository<Merchant> _merchantRepository;
        private Repository<TransactionGroup> _transactionGroupRepository;

        public TransactionRepository TransactionRepository
        {
            get { return _transactionRepository ?? (_transactionRepository = new TransactionRepository(_context)); }
            set { }
        }

        public Repository<Card> CardRepository
        {
            get { return _cardRepository ?? (_cardRepository = new Repository<Card>(_context)); }
            set { }
        }

        public Repository<AccountType> AccountTypeRepository
        {
            get { return _accountTypeRepository ?? (_accountTypeRepository = new Repository<AccountType>(_context)); }
            set { }
        }

        public Repository<Merchant> MerchantRepository
        {
            get { return _merchantRepository ?? (_merchantRepository = new Repository<Merchant>(_context)); }
            set { }
        }

        public Repository<TransactionGroup> TransactionGroupRepository
        {
            get
            {
                return _transactionGroupRepository ?? (_transactionGroupRepository =
                           new Repository<TransactionGroup>(_context));
            }
            set { }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}