using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        public double Balance { get; set; }
        // public User User {get; set;}
        // public int UserId { get; set; }

        // public double Debit { get; set; }
        // public double Credit { get; set; }
        // note wallet customer id
        public int CustomerId { get; set; }
        //note wallet
        public Customer Customer { get; set; }
    }
}