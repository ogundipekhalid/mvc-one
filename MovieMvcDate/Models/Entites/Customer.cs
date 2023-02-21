using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class Customer
    {
        // [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [DisplayName("FirstName")]
        [Required]
        public string FirstName { get; set; }
        [DisplayName("LastName")]
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid RefNumber { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
        // public double Walliet { get; set; }
        public IList<BookingCustomer> BookingCustomers { get; set; } = new List<BookingCustomer>();
        public User User { get; set; }
        // public int MovieId { get; set; }
        //note of customer wallet
       public Wallet Wallet { get; set; }
        // the of wallet in customer
        // public int? WalletId { get; set; }
        public IList<CustomerMovie> CustomerMovies { get; set; } = new List<CustomerMovie>();
        //note dis 
        public bool IsActive { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}