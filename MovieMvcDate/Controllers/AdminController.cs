using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices _service;
        public AdminController(IAdminServices service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult IndexPage()
        {
            return View();
        }
        //    [Authorize(Roles = "Admin ")]
        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAdmin(CretaAdminRequestModel admin)
        {
             if (admin != null)
            {
                var EmaailExist = _service.GetAdminByEmail(admin.Email);
                if (EmaailExist == null)
                {
                   _service.CreateAdmin(admin);
                   TempData["success"] = "Admin Created Successfully";
                    return RedirectToAction("LogIn", "Home");
                }
                 TempData["failed"] = "Email already Exist.";
                return View();  
            }
            else
            {
                TempData["failed"] = "Registration failed because of incomplete details.";
                return View();
            }

            // if (admin != null)
            // {
            //     _service.CreateAdmin(admin);
            //     TempData["success"] = "Admin Created Successfully";
            //     return RedirectToAction("LogIn", "Home");
            //     //  return RedirectToAction("Home" ,"LogIn");
            // }
            // else
            // {
            //     ViewBag.Error = "Wrong Input";
            //     return View();
            // }

        }
        // [ActionName("UpdateAdmin")]
        //   [HttpGet]
        // public IActionResult UpdateAdmin(int id, UpdateAdminRequestModel admin)
        // {
        //     if (HttpContext.Request.Method == "POST")
        //     {
        //         var admi = _service.UpdateAdmin(id,admin);
        //         return RedirectToAction(nameof(GetAllAdmin));
        //     }
        //     var adminn = _service.GetAdminById(id);
        //     return View(adminn);
        // }

        // public IActionResult Update(UpdateAdminRequestModel admin)
        // {
        //     if (HttpContext.Session.GetInt32("id") == null)
        //     {
        //         return RedirectToAction("LogIn");
        //         if (HttpContext.Request.Method == "POST")
        //         {
        //             var request = _service.UpdateAdmin(HttpContext.Session.GetString("id"),admin);
        //             return StatusCode(201, "Profile Successfully Updated");

        //         }
        //         var admmm = _service.(HttpContext.Session.GetString("id"));//(("id"));
        //           return StatusCode(201,"Profile Successfully Updated");

        //         //var customer = await _customerService.FindByEmailAsync(HttpContext.Session.GetString("Email"));
        //         if (customer == null)
        //         {
        //             return StatusCode(404, "Customer Not Found");
        //         }
        //         return View(customer);
        //     }
        // }
        // [ActionName("UpdateAdmin")]
        public IActionResult UpdateAdmin(int id)
        {

            var admin = _service.GetAdminById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }
        //    [HttpPost, ActionName("UpdateAdmin")]
        [HttpPost]
        public IActionResult UpdateAdmin(CretaAdminRequestModel admin)
        {
            _service.UpdateAdmin(admin);
            TempData["success"] = "Profile Updated Successfully.";
            return RedirectToAction(nameof(GetAllAdmin));
        }

        //
        public IActionResult Delete(int id)
        {
            if (id != null)
            {
                var deleteprew = _service.GetAdminById(id);
                if (deleteprew == null)
                {
                    return View(deleteprew);
                }
                return NotFound();
            }

            return NotFound();
        }
        [HttpGet]
        public IActionResult DeleteAdmin(int id)
        {
            if (id != null)
            {
                _service.DeleteAdmin(id);
                return RedirectToAction(nameof(GetAllAdmin));
            }
            return NotFound();
        }

        [HttpGet("id")]
        public IActionResult Details(int id)
        {
            
            var admin = _service.GetAdminById(id);
           
            return View(admin);
            
        }
        public IActionResult GetAllAdmin()
        {
            var admins = _service.GetAllAdmin();
            return View(admins);
        }
        // public IActionResult Login()
        // {
        //     return View();
        // }
        // [HttpPost, ActionName("Login")]
        // public IActionResult Login(string email, string password)
        // {
        //     if (email == null || password == null)
        //     {
        //         return NotFound();
        //     }

        //     var adminmin = _service.Login(email, password);
        //     if (adminmin == null)
        //     {
        //         ViewBag.Error = "Invalid Email or PassWord";
        //         // return View();
        //         return NotFound();
        //     }
        //     return RedirectToAction(nameof(CreateAdmin));

        // }
    }
}