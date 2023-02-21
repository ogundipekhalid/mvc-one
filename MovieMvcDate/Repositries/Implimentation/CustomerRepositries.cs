using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class CustomerRepositries : ICustomerRepositries
    {
        private readonly ApplictionContext _customercontext;
        public CustomerRepositries (ApplictionContext customercontext)
        {
            _customercontext = customercontext;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _customercontext.customers.Add(customer);
            _customercontext.SaveChanges();
            return customer;
        }

        public Customer DeleteCustomer(Customer customer)
        {
            _customercontext.customers.Remove(customer);
            _customercontext.SaveChanges();
            return customer;
        }

        public IList<Customer> GetAllCustomers()
        {
            return  _customercontext.customers.ToList();
        }

          public Customer GetCustomerByEmail(string email)
        {
           var getcusto = _customercontext.customers.SingleOrDefault(g => g.Email == email);
           return getcusto;
        }

        public Customer GetCustomerById(int id)
        {
            var getcuid = _customercontext.customers.SingleOrDefault(i => i.Id == id);
            return getcuid;
        }

        public Customer Login(string email, string password)
        {
            return _customercontext.customers.SingleOrDefault(a => a.Email  == email && a.Password == password);
        }
        public Customer UpdateCustomer(Customer customer)
        {
            _customercontext.customers.Update(customer);
            _customercontext.Update(customer);
            return customer;    
        }
    }
}