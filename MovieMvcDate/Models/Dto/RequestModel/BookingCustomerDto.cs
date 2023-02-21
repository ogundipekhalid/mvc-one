using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;

namespace MovieMvcDate.Models.Dto.RequestModel
{
    public class BookingCustomerDto
    {
        public int Id { get; set; }
        public int UserId {get;set;}
        public string Email { get; set; }
        public string MovieName { get; set; }
        public string SitNumber { get; set; }
        // public string BookingCode {get; set;}
        public double Price { get; set; }
          public string IsdDleted { get; set; }
    }
    public class CreateBookingRequestmodel
    {
         public int Id { get; set; }
        public int UserId {get;set;}
        public string Email { get; set; }
        public string MovieName { get; set; }
        public string SitNumber { get; set; }
        public double Price { get; set; }
        //public Guid RefNumber { get; set; } = Guid.NewGuid();
        public bool IsdDleted { get; set; } = false;
        //public string BookingCode {get; set;}
    }
    public class UpdateCustomerRequestModel
    {
        public string MovieName { get; set; }
        public double Price { get; set; }
    }
    public class BookingResponceModel : BaseResponce
    {
        public BookingCustomerDto Data { get; set; }
    }
    public class DetilsResponceModel
    {
        public int Id { get; set; }
        public int UserId {get;set;}
        public string Email { get; set; }
        public string MovieName { get; set; }
        public string SitNumber { get; set; }
        public double Price { get; set; }
        public  bool IsdDleted { get; set; } = false;
    }

}