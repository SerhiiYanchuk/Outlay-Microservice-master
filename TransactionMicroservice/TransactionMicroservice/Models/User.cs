using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CardMicroservice.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MinLength(5), MaxLength(20)]
        public string Login { get; set; }
        [Required, MinLength(4), MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        [Range(18, 90)]
        public int Age { get; set; }

        public List<BankCard> Cards { get; set; }
    }
}
