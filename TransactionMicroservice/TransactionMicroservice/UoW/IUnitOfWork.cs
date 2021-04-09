using CardMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IBankCardRepository Cards { get; }
        IUserRepository Users { get; }
        ITransactionRepository Transactions { get; }
        int Save();
    }
}
