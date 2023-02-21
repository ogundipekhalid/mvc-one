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
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepositries _repo;
        private readonly IMovieRepositries _moviRepo;
        private readonly ICustomerRepositries _cutomerRepo;

        // // private readonly IUserServices _userrepositry;
        public BookingServices(IBookingRepositries repo, IUserServices userrepositry)
        {
            _repo = repo;
            //// _userrepositry = userrepositry;
        }

         public BookingCustomer CreateBooking(CreateBookingRequestmodel createbooking)
         {
              var bok = new BookingCustomer
            {
             Id = createbooking.Id,
                   MovieName = createbooking.MovieName,
                    Price = createbooking.Price,
                    Email = createbooking.Email,
                    SitNumber = createbooking.SitNumber,
                    //RefNumber = createBooking.RefNumber,
                    IsActive = true
            };
                 return _repo.CreateBooking(bok);

         }

        // public BookingCustomer CreateBooking(CreateBookingRequestmodel createbooking, string moviename,  int id)
        // {
        //     var booker = new BookingCustomer();
        //     var verifyMovieName = _moviRepo.GetMoviesbyid(id);
        //     var verifyRefnumber = _cutomerRepo.GetCustomerById(jd);
        //     if (verifyRefnumber == null)
        //     {
        //         Console.WriteLine("unrecognized Refnumber");
        //     }
        //     else
        //     {
        //         if (verifyMovieName == null)
        //         {
        //             Console.WriteLine("movie name does not exist");
        //         }
        //          booker = new BookingCustomer
        //         {
        //             Id = createbooking.Id,
        //            MovieName = createbooking.MovieName,
        //             Price = createbooking.Price,
        //             Email = createbooking.Email,
        //             SitNumber = createbooking.SitNumber,
        //             //RefNumber = createBooking.RefNumber,
        //             IsActive = true
        //         };

        //          _repo.CreateBooking(booker);
        //     }
        //     return booker;
        // }



        public void DeleteBooking(int id)
        {
            var booki = _repo.GetBookingBy(id);
            _repo.DeleteBooking(booki);
        }

        public IList<BookingCustomer> GetAllBooking()
        {
            return _repo.GetAllBooking();
        }

        public BookingResponceModel GetBooking(int id)
        {
            var bokeed = _repo.GetBookingBy(id);
            if (bokeed == null)
            {
                return new BookingResponceModel
                {
                    Message = "Booking Id not found",
                    Status = false
                };

            }
            var book = new BookingCustomerDto
            {
                Email = bokeed.Email,
                MovieName = bokeed.MovieName,
                UserId = bokeed.Id
            };

            return new BookingResponceModel
            {
                Message = "bookig found",
                Status = false,
                Data = book,
            };


        }

        public BookingResponceModel UpdateBooking(BookingCustomerDto bookingcustomer)
        {
            var bookies = _repo.GetBookingBy(bookingcustomer.Id);
            if (bookies == null)
            {
                return new BookingResponceModel
                {
                    Message = "Updating not found",
                    Status = false
                };
            }
            bookies.MovieName = bookies.MovieName ?? bookies.MovieName;
            bookies.Price = bookies.Price < 0 ? bookies.Price : bookies.Price;
            // bookies.
            _repo.UpdateBooking(bookies);
            // return bookingcustomer;
            return new BookingResponceModel
            {
                Message = " Updating  found",
                Status = true
            };
        }
    }
}