using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMvcDate.Models.Entites
{
    public class BookingCustomer
    {
        public int Id { get; set; }
        public string MovieName{get;set;}
        public   string SitNumber{get;set;}
        public  string  Email { get; set; }
        //public Guid RefNumber { get; set; } = Guid.NewGuid();
        // public string BookingCode {get; set;}
        public double Price {get; set;} 
         public int UserId {get;set;}
        public Customer Customer { get; set; }
        public bool IsActive {get;set;} 
         public bool IsdDleted { get; set; }  = false;
        // public string Duration {get; set;}
        
    }
}