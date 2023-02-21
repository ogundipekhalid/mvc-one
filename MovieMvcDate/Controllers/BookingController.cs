using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices  _service;
        public BookingController(IBookingServices service)
        {
            _service = service;
        }
         public IActionResult IndexBooking()
        {
            return View();
        }
         public IActionResult BookingDashborad()
        {
            return View();
        }
         public IActionResult CreateBooking()
        {
            return View();
        }

         [HttpPost]
          public IActionResult CreateBooking(CreateBookingRequestmodel createBooking )
        {
           
          if(createBooking != null )
          {
            var esit = _service.GetBooking(createBooking.Id);
            if (esit == null)
            {
                _service.CreateBooking(createBooking);
                TempData["success"] = "Created Successfully.";
                    return RedirectToAction("Index");
            }
            TempData["failed"] = "already exist.";
                return View();
          }
          TempData["failed"] = "failed.";
                return View(createBooking);
        }



        //   public IActionResult CreateBooking(CreateBookingRequestmodel createBooking ,string MovieName)
        // {
        //     if (createBooking == null)
        //     {
        //         _service.CreateBooking(createBooking.MovieName);
        //         TempData["success"] = "Booking Created Successfully";
        //         //  return RedirectToAction("LogIn", "Home");
        //          return RedirectToAction(nameof(BookingDashborad));
        //     }
        //     else
        //     {
        //         ViewBag.Error = "Wrong Input";
        //         return View();
        //     }
        //         //return RedirectToAction(nameof(UpdateBooking));

        // }

         public IActionResult Details()
        {
            return View();
        }
          public IActionResult Details(int id)
        {
           if (id != null)
            {
                var buk = _service.GetBooking(id);
                if (buk != null)
                {
                    return View(buk);
                }
                return NotFound();
            }
            return NotFound();
        }
        
        public IActionResult GetAllBooking()
        {
            var get = _service.GetAllBooking();
            return View(get);      
        }


         public IActionResult UpdateBooking(int id)
        {
            if (id == null)
            {
                // return NotFound();
                return View();
            }
            var UpBook = _service.GetBooking(id);
            if (UpBook == null)
            {
                return NotFound();
            }
            return View(UpBook);
       
        }
        [HttpPost]
         public IActionResult UpdateBooking(BookingCustomerDto bookingcustomer)
        {
            var admi = _service.UpdateBooking(bookingcustomer);
                return RedirectToAction(nameof(GetAllBooking));
        }
         public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var Dele = _service.GetBooking(id);
            if(Dele == null)
            {
                return NotFound();
            }
            return View(Dele);
        }
        //  [HttpPost("{id}")]
        [HttpGet]
         public IActionResult DeleteBooking(int id)
        {
            _service.DeleteBooking(id);
            return RedirectToAction(nameof(GetAllBooking));
        }
        
    }
}