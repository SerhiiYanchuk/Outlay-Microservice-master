using CardMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CardMicroservice.Repository.Interfaces
{
    public interface ITransactionRepository : IRepository<CardTransaction>
    {
        IEnumerable<CardTransaction> GetTransactionsWithType(int cardId, int type);
        IEnumerable<CardTransaction> GetSpendingTransactions(int cardId);
        IEnumerable<CardTransaction> GetAddingTransactions(int cardId);
        IEnumerable<CardTransaction> GetTransactionsWithCardId(int cardId);
    }
}
