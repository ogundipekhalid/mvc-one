using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface ICustomerRepositries
    {
         Customer CreateCustomer(Customer customer );
        Customer DeleteCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        Customer Login(string email, string password);
        Customer GetCustomerById(int id);
        Customer GetCustomerByEmail(string email);
        IList<Customer> GetAllCustomers();

        
    //    public Customer AddMoneyToWallet(string email, double Walliet);
    //    double CheckWallet ( int id );
    }
}