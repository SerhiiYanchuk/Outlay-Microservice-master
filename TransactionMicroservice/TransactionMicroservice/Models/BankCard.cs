using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Models
{
    public class BankCard
    {
        public int Id { get; set; }
        [Required, MinLength(16), MaxLength(16)]
        public string Number { get; set; }
        public double TotalMoney { get; set; }
        [Required]
        public User User { get; set; }
        public List<CardTransaction> Transactions { get; set; }
    }
}
