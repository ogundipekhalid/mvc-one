using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.ResponceModel;

namespace MovieMvcDate.Models.Dto.RequestModel
{
    public class CustomerDto
    {
         public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public Guid RefNumber { get; set; }  = Guid.NewGuid().ToString("CUT").Substring(0,20).Replace('/',' ');
        public Guid RefNumber { get; set; }  = Guid.NewGuid();
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive {get; set;}
        public string PhoneNumber { get; set; }
        //not may remove 
        // public double Walliet { get; set; }
    }
    public class CreateCustomerRequestmodel : BaseResponce
    {
         public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
         public Guid RefNumber { get; set; }  = Guid.NewGuid();// Guid.NewGuid().ToString("CUT").Substring(0,20).Replace('/',' ');
         public bool IsActive { get; set; }
        //not may remove 
        // public double Walliet { get; set; }
    }
    public class UpdateCustomerRequestmodel
    {        
        public int Id { get; set; }
        public int UserId {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
         public Guid RefNumber { get; set; }  = Guid.NewGuid();
    }
    public class DeleteCustomerRequestmodel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginCustomerRequestmodel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
    public class CustomerResponceModel : BaseResponce
    {
        public CustomerDto Data { get; set; }
    }
}