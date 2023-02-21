using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMvcDate.Models.Dto;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieServices _services;
        private readonly IWebHostEnvironment _webHostEnvironment;
         private readonly string _Video;

        public MovieController(IMovieServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult IndexMovie()
        {
            return View();
        }
        public async Task<IActionResult> MovieDarshboard()
        {
            return View();
        }
             public IActionResult Create()
        {
             return View();
        }
        [HttpPost]
        public IActionResult Create(CreateMovieRequestmodel movie)
        {
         var cretemovie = _services.CreateMovie(movie);
            TempData["success"] = "Movie Created Successfully";
            // if(cretemovie.Status == true)
            // {
            //     return View();
            // }
            //     //  return RedirectToAction("ViewAllMovie");
                return RedirectToAction(nameof(IndexMovie));
        }

        //  public ActionResult PlayVideo()
        // {
        //     var filePath = MovieFliePath.MapPath("~/video/video.mp4"); // Replace with the path to your video file
        //     return new VideoResult(filePath);
        // }


        //  public async Task<IActionResult> CreateMovie([FromForm]CreateMovieRequestmodel movie)
        // {
        //     return RedirectToAction("ViewAllMovie");

        // }
        // public async Task<IActionResult> CreateMovie([FromForm]CreateMovieRequestmodel movie, [FromRoute] int UserId)
        // {
        //     var files = HttpContext;
        //     if (files.Count != 0)
        //     {
                
        //     }
        // }
        public async Task<IActionResult> Test(TestRequestmodel movie)
        {
            return RedirectToAction("ViewAllMovie");
        }

        [HttpGet("ViewAllMovie")]
        public async Task<IActionResult> ViewAllMovie()
        {
            var viewall = _services.ViewAllMovie();
            return  View(viewall);
        }

        // [HttpGet("DeleteMovie")]

         public IActionResult Update(int id)
        {

            var manv = _services.GetMoviesById(id);
            if (manv == null)
            {
                return NotFound();
            }
            return View(manv);
        }
 

        public IActionResult UpdateMovie(UpdateMovieResponceModel movie)
        {
            var videos = _services.UpdateMovie(movie);
              TempData["success"] = "Movie Updated Successfully.";
            return RedirectToAction(nameof(ViewAllMovie));
        }

          public IActionResult Delete(int id)
        {
            if (id != null)
            {
                var deleteprew = _services.GetMoviesById(id);
                if (deleteprew == null)
                {
                    return View(deleteprew);
                }
                return NotFound();
            }

            return NotFound();
        }

        [HttpGet]
        
        public IActionResult DeleteMovie(int id )
        {

            if (id != null)
            {
           _services.DeleteMovie(id);
                return RedirectToAction(nameof(ViewAllMovie));
            }
            return NotFound();
        }

         [HttpGet("id")]
        public IActionResult Details(int id)
        {
            
            var movie = _services.GetMoviesById(id);
           
            return View(movie);
            
        }


        // public async Task<IActionResult> GetMoviesById()
        // {
        //     return View();
        // }

        [HttpGet]
       public async Task<IActionResult> GetMoviesById(int id )
        {
            var idmovie = _services.GetMoviesById(id);
            return View(idmovie);
        }
   
    }
}