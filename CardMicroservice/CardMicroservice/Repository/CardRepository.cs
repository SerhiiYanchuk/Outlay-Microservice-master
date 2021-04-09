using CardMicroservice.DBContexts;
using CardMicroservice.Models;
using CardMicroservice.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Repository
{
    public class CardRepository : Repository<BankCard>, IBankCardRepository
    {
        public CardRepository(MyDbContext myDbContext)
            : base(myDbContext)
        {
        }

        public IEnumerable<BankCard> GetCardsWithUserId(int userId)
        {
            return MyDbContext.Cards.Select(a => a).Where(a => a.User.Id == userId).ToList();
        }

        void IBankCardRepository.Update(BankCard card)
        {
            MyDbContext.Entry(card).State = EntityState.Modified;
        }

        public MyDbContext MyDbContext
        {
            get { return _context as MyDbContext; }
        }
    }
}
