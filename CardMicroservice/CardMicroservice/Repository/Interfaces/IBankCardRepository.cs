using CardMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Repository.Interfaces
{
    public interface IBankCardRepository : IRepository<BankCard>
    {
        IEnumerable<BankCard> GetCardsWithUserId(int userId);
        void Update(BankCard card);
    }
}
