using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepositries _repo;
        private readonly IUserRepositries _userRepo;

         public CustomerServices (ICustomerRepositries repo ,  IUserRepositries  userRepo)
        {
            _userRepo  = userRepo;
            _repo = repo;
        }


        public Customer CreateCustomer(CustomerDto customer)
        {
            var user = new User
            {
                Email = customer.Email,
                Password = customer.Password,
                IsActive = true,
                Role = "Customer"
            };
            var use = _userRepo.CreateUser(user);
            // Random random = new Random();
            // Random rand = new Random();
            customer.UserId = use.Id;
            customer.IsActive = true;

            var lecustomer = new Customer
            {
                Id = customer.Id,
                UserId = customer.UserId,
                RefNumber = customer.RefNumber,
                IsActive = customer.IsActive,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Password = customer.Password,
                PhoneNumber = customer.PhoneNumber,
               // Walliet = customer.Walliet,
                // UserId = use.Id,

            };
            return _repo.CreateCustomer(lecustomer);
        }

          public CustomerResponceModel GetCustomerByEmail(string email)
        {
            var CuserEmail = _repo.GetCustomerByEmail(email);
            if (CuserEmail == null)
            {
                return null;
            }
             var CustomerResponceModel = new CustomerResponceModel
            {
                Message = "Customer retrieved Successfully",
                Status = true,
                Data = new CustomerDto
                {
                    Id = CuserEmail.Id,
                    FirstName = CuserEmail.FirstName,
                    LastName = CuserEmail.LastName,
                    PhoneNumber = CuserEmail.PhoneNumber,
                    Email = CuserEmail.Email,
                    // UserId = CuserEmail.UserId,
                    Password = CuserEmail.Password, 
                    IsActive = CuserEmail.IsActive,
                    RefNumber = CuserEmail.RefNumber
                }
            };
            return CustomerResponceModel;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _repo.GetCustomerById(id);
            // customer.Isdeleted = true;
            _repo.DeleteCustomer(customer);
        }

        public IList<Customer> GetAllCustomers()
        {
            return  _repo.GetAllCustomers();
        }

         public CreateCustomerRequestmodel GetCustomerByid(int id)
        {
             var cutom = _repo.GetCustomerById(id);
           return new CreateCustomerRequestmodel
            {

                Id = cutom.Id,
                RefNumber = cutom.RefNumber,
                 FirstName = cutom.FirstName,
                LastName = cutom.LastName,
                Email = cutom.Email,
                PhoneNumber = cutom.PhoneNumber,
                Password = cutom.Password,
                IsActive = cutom.IsActive,

            };
        }


            public Customer Login(string email, string password)
            {
                return _repo.Login(email,password);
            }

            public UpdateCustomerRequestmodel UpdateCustomer(UpdateCustomerRequestmodel customer)
            {
                var cutimo = _repo.GetCustomerById(customer.Id);
                if(cutimo == null)
                {
                    return null;
                }

                cutimo.FirstName = customer.FirstName ?? cutimo.FirstName;
                cutimo.LastName = customer.LastName ?? cutimo.LastName;
               cutimo.Email = customer.Email ?? cutimo.LastName;
               cutimo.PhoneNumber = customer.PhoneNumber ?? cutimo.PhoneNumber;
               cutimo.Password = customer.Password ?? cutimo.Password;
               _repo.UpdateCustomer(cutimo);
               return customer;
            }


       
        //note latter for customer to update password
        // public UpdateCustomerPasswordRequestModel UpdatePassword(UpdateCustomerPasswordRequestModel customer)

    }
    }