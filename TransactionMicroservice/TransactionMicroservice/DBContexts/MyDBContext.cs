using CardMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.DBContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BankCard> Cards { get; set; }
        public DbSet<CardTransaction> Transactions { get; set; }

        
    }
}
