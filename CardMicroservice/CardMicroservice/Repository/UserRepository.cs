using CardMicroservice.DBContexts;
using CardMicroservice.Models;
using CardMicroservice.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyDbContext myDbContext)
            : base(myDbContext)
        {

        }

    }
}
