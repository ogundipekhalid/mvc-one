using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Admin 
    {
        [Key]
        public  int Id{get;set;}
        [DisplayName("FirstName")]
        [Required]
        public string FirstName  {get; set;}
        [DisplayName("LastName")]
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
         public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public  User User{ get; set; } 
         public bool IsActive {get;set;}
    }
}