using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface ICustomerServices
    {
        Customer CreateCustomer(CustomerDto customer);
        public UpdateCustomerRequestmodel UpdateCustomer(UpdateCustomerRequestmodel customer);
         public void DeleteCustomer(int id);
        Customer Login(string email, string Pin);
         public   CreateCustomerRequestmodel GetCustomerByid(int id);
       // IList<Customer> GetAllCustomers();
         public IList<Customer> GetAllCustomers();

          public CustomerResponceModel GetCustomerByEmail(string email);


        // note use only for customer 
       // Customer AddMoneyToWallet (string email, double wallet);
        // only for customer check wallet
        // public double CheckWallet(int id);
    }
}