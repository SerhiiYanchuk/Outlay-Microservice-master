using CardMicroservice.DBContexts;
using CardMicroservice.Repository;
using CardMicroservice.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;

        public UnitOfWork(DbContextOptions<MyDbContext> options)
        {
            _context = new MyDbContext(options);
            Cards = new CardRepository(_context);
            Transactions = new TransactionRepository(_context);
            Users = new UserRepository(_context);
        }

        public IBankCardRepository Cards { get; private set; }

        public IUserRepository Users { get; private set; }

        public ITransactionRepository Transactions { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
