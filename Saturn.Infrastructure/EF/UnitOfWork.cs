using System;
using System.ComponentModel;
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
            get
            {
                if(this._transactionRepository == null)
                    this._transactionRepository = new TransactionRepository(_context);
                return _transactionRepository;
            }
            set { }
        }

        public Repository<Card> CardRepository
        {
            get
            {
                if (this._cardRepository == null)
                    this._cardRepository = new Repository<Card>(_context);
                return _cardRepository;
            }
            set { }
        }

        public Repository<AccountType> AccountTypeRepository
        {
            get
            {
                if (this._accountTypeRepository == null)
                    this._accountTypeRepository = new Repository<AccountType>(_context);
                return _accountTypeRepository;
            }
            set { }
        }

        public Repository<Merchant> MerchantRepository
        {
            get
            {
                if (this._merchantRepository == null)
                    this._merchantRepository = new Repository<Merchant>(_context);
                return _merchantRepository;
            }
            set { }
        }

        public Repository<TransactionGroup> TransactionGroupRepository
        {
            get
            {
                if (this._transactionGroupRepository == null)
                    this._transactionGroupRepository = new Repository<TransactionGroup>(_context);
                return _transactionGroupRepository;
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
            if (this.disposed) return;
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