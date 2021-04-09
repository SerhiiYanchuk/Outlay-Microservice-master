using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Models
{
    public class CardTransaction
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double Sum { get; set; }
        public DateTime DateTime { get; set; }

        public TransactionType Type { get; set; }
        public bool Profitable { get; set; } = false;

        public BankCard Card { get; set; }
    }

    public enum TransactionType
    {
        OnlinePayment = 1,
        CafesAndRestaurants,
        Products,
        Books,
        AdditionMoney,
        TransferToAnotherCard,
        Other
    }
}
