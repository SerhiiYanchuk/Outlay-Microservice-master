using CardMicroservice.DBContexts;
using CardMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardMicroservice.Models;

namespace CardMicroservice.Repository
{
    public class TransactionRepository : Repository<CardTransaction>, ITransactionRepository
    {
        public TransactionRepository(MyDbContext context)
            : base(context)
        {
        }
        public IEnumerable<CardTransaction> GetAddingTransactions(int cardId)
        {
            return MyDbContext.Transactions.Where(x => x.Card.Id == cardId && x.Profitable).ToList();
        }

        public IEnumerable<CardTransaction> GetSpendingTransactions(int cardId)
        {
            return MyDbContext.Transactions.Select(x => x).Where(x => x.Card.Id == cardId && !x.Profitable).ToList();
        }

        public IEnumerable<CardTransaction> GetTransactionsWithType(int cardId, int type)
        {
            return MyDbContext.Transactions.Select(x => x)
                              .Where(a => a.Card.Id == cardId && a.Type.CompareTo((TransactionType)type) == 0).ToList();
        }

        public IEnumerable<CardTransaction> GetTransactionsWithCardId(int cardId)
        {
            return MyDbContext.Transactions.Select(x => x).Where(a => a.Card.Id == cardId).ToList();
        }


        // Вивів у властивість, щоб не прописувати кожного разу в методі і отримати доступ до Transactions
        public MyDbContext MyDbContext
        {
            get { return _context as MyDbContext; }
        }
    }
}
