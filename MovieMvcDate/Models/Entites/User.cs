using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class User
    {
        // [Key]
        public int  Id { get; set; }
        public Customer Customer { get; set; }
        public Admin Admin { get; set; }
        // public Wallet wallet { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role {get; set;}
        public bool IsActive {get;set;}
        public bool IsDeleted { get; set; }  = false;
    }
}