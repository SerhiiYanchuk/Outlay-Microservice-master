using CardMicroservice.DBContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MyDbContext>());
            }

        }

        public static void SeedData(MyDbContext context)
        {
            Console.WriteLine("Appling Migrations...");

            context.Database.Migrate();

            if(!context.Users.Any())
            {
                Console.WriteLine("Adding data - seeding...");
                //context.Users.AddRange(
                //    new User
                //    {
                //        Login = "deniar.dev",
                //        Password = "1111",
                //        Age = 62,
                //        Name = "Vitya",
                //        Surname = "BigBoss"
                //    },
                //    new User
                //    {
                //        Login = "Volodya",
                //        Password = "111111",
                //        Age = 19,
                //        Name = "Vova",
                //        Surname = "Dol"
                //    }
                //    );

                var user = new User
                {
                    Login = "deniar.dev",
                    Password = "1111",
                    Age = 62,
                    Name = "Vitya",
                    Surname = "BigBoss"
                };

                var card = new BankCard
                {
                    Number = "1425789654123564",
                    TotalMoney = 2000,
                    User = user
                };

                context.Transactions.Add(new CardTransaction
                {
                    Sum = 100,
                    Type = TransactionType.OnlinePayment,
                    DateTime = new DateTime(2017, 10, 5, 17, 45, 55),
                    Card = card
                });

                context.Transactions.Add(new CardTransaction
                {
                    Sum = 720,
                    Type = TransactionType.Books,
                    DateTime = new DateTime(2017, 11, 7, 12, 55, 57),
                    Card = card
                });

                context.Transactions.Add(new CardTransaction
                {
                    Sum = 25,
                    Type = TransactionType.CafesAndRestaurants,
                    DateTime = new DateTime(2017, 11, 8, 16, 34, 21),
                    Card = card
                });


                var user1 = new User
                {
                    Login = "Volodya",
                    Password = "111111",
                    Age = 19,
                    Name = "Vova",
                    Surname = "Dol"
                };

                var card1 = new BankCard
                {
                    Number = "3467579468945768",
                    TotalMoney = 45782,
                    User = user1
                };

                context.Transactions.Add(new CardTransaction
                {
                    Sum = 110,
                    Type = TransactionType.OnlinePayment,
                    DateTime = new DateTime(2018, 1, 27, 7, 55, 55),
                    Card = card1
                });


                context.Transactions.Add(new CardTransaction
                {
                    Sum = 750,
                    Type = TransactionType.Books,
                    DateTime = new DateTime(2019, 1, 12, 7, 55, 55),
                    Card = card1
                });

                var card2 = new BankCard
                {
                    Number = "1111111111111111",
                    TotalMoney = 3700,
                    User = user1
                };


                context.Transactions.Add(new CardTransaction
                {
                    Sum = 110,
                    Type = TransactionType.CafesAndRestaurants,
                    DateTime = new DateTime(2019, 10, 27, 17, 55, 55),
                    Card = card2
                });

                context.Transactions.Add(new CardTransaction
                {
                    Sum = 110,
                    Type = TransactionType.OnlinePayment,
                    DateTime = new DateTime(2020, 1, 1, 18, 47, 25),
                    Card = card2
                });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}
