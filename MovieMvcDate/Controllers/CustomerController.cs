using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        public IActionResult IndexCustomer()
        {
            // return View(nameof(CustomerDashborad));
            return View();
        }
        public IActionResult CustomerDashborad()
        {
            return View();
        }

        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]
        [ActionName ( "CreateCustomer")]
        public IActionResult CreateCustomer(CustomerDto customer)
        {
            if (customer != null)
            {
                var exit  = _customerServices.GetCustomerByEmail(customer.Email);
               if (exit == null)
               {
                 _customerServices.CreateCustomer(customer);
                  TempData["success"] = "Registration Successfully";
                return RedirectToAction("LogIn", "Home");
               }
                 TempData["failed"] = "Email already exist.";
                return View();
                // return RedirectToAction("CustomerDashborad","Admin");
            }
            TempData["failed"] = "Registration failed because of incomplete details.";
            return View();
        }

        // [Authorize(Roles = "Customer")]
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                var customer = _customerServices.GetCustomerByid(id);
                if (customer == null)
                {
                    return View(customer);
                }
                return NotFound();
            }

            return NotFound();
        }
        //  [Authorize]
        // [HttpPost , ActionName("Delete")]
        [HttpGet]
        // [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int id)
        {
            if (id != null)
            {
                _customerServices.DeleteCustomer(id);
                return RedirectToAction(nameof(GetAllCustomer));
            }
            return NotFound();
        }
        //  [Authorize(Roles = "Customer,Admin")]
          [HttpGet ("RefNumber")]
        public IActionResult Details(int id)
        {
          //  if (RefNumber != null)
           // {
                var customer = _customerServices.GetCustomerByid(id);
                // if (customer != null)
                // {
                    return View(customer);
                   // return View(nameof(GetAllCustomer));
              //  }
            //     return NotFound();
            // }
            // return NotFound();
        }
        // [Authorize(Roles = "Admin")]
        // [HttpPost]
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _customerServices.GetCustomerByid(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

           // return View(GetAllCustomer);
        }
        [HttpPost , ActionName("UpdateCustomer")]
        // [HttpPost]
        public IActionResult UpdateCustomer(UpdateCustomerRequestmodel customer)
        {
            _customerServices.UpdateCustomer(customer);
            TempData["success"] = "profile updated Successfully.";
            return RedirectToAction(nameof(GetAllCustomer));
        }

        //  [Authorize(Roles = "Admin")]
        public IActionResult GetAllCustomer()
        {
            var customers = _customerServices.GetAllCustomers();
            return View(customers);
        }

      //  [Authorize(Roles = "Cutomer")]
        // public IActionResult Login()
        // {
        //     return View();
        // }
        // // [HttpPost, ActionName("Login")]
        //  public IActionResult Login(string email, string password)
        // {
        //     if(email == null || password == null)
        //     {
        //          return NotFound();   
        //     }

        //     var adminmin = _customerServices.Login(email, password);
        //     if (adminmin == null)
        //     {
        //         ViewBag.Error = "Invalid Email or PassWord";
        //         return View();
        //          return NotFound();
        //     }

        //     return RedirectToAction(nameof(IndexCustomer));
        // }

      
       
    }
}