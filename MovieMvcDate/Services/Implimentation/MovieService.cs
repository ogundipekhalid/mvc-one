using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;
using MovieMvcDate.Services.Interface;

namespace MovieMvcDate.Services.Implimentation
{
    public class MovieService : IMovieServices
    {
        private readonly IMovieRepositries _repo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepositries _UserRepository;
        private readonly ICustomerRepositries _customerRepositries;
        public MovieService(IMovieRepositries repo, IWebHostEnvironment webHostEnvironment, IUserRepositries UserRepository, ICustomerRepositries customerRepositries)
        {
            _repo = repo;
            _UserRepository = UserRepository;
            _webHostEnvironment = webHostEnvironment;
            _customerRepositries = customerRepositries;
        }

           public async Task<CreateMovieRequestmodel> CreateMovie(CreateMovieRequestmodel movie)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Videos");
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);
            var fileName = Path.GetFileNameWithoutExtension(movie.incomingFiles.FileName);
            var filePath = Path.Combine(basePath, movie.incomingFiles.FileName);
            var extension = Path.GetExtension(movie.incomingFiles.FileName);

            if (!System.IO.File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    movie.incomingFiles.CopyToAsync(stream);
                }

                var movies = new Movie
                {
                    Id = movie.Id,
                    MovieName = movie.MovieName,
                    Director = movie.Director,
                    Year = movie.Year,
                    MoviePrice = movie.MoviePrice,
                    TimeCreted = DateTime.UtcNow,
                    MovieFliePath = filePath,
                    Moviedate = DateTime.Now.AddDays(2),
                };
                _repo.CreateMovie(movies);
            }

            return null;
        }

        // public MovieResponceModel CreateMovie(CreateMovieRequestmodel movie)
        // {
        //     var MovieFlieName = "";
        //     if (movie.MovieFlieType != null)

        //     {
        //         var path = _webHostEnvironment.WebRootPath;
        //         var videoeparth = Path.Combine(path, "MovieFlieType");
        //         Directory.CreateDirectory(videoeparth);
        //         string wordVideoType = movie.MovieFlieType.ContentType.Split('/')[1];
        //         // MovieFlieType = $"{movie.MovieFlieType}/{Guid.NewGuid().ToString().Substring(0,9)}.{wordVideoType}";
        //         if (wordVideoType.ToLower() != "MP4" || wordVideoType.ToLower() != "MOV" || wordVideoType.ToLower() != "WEBM")
        //         {
        //             return new MovieResponceModel
        //             {
        //                 Message = "Fail to create product because file type is not image",
        //                 Status = false
        //             };
        //         }
        //         MovieFlieName = $"{movie.MovieFlieType}/{Guid.NewGuid().ToString().Substring(0, 9)}.{wordVideoType}";
        //         var fullPath = Path.Combine(videoeparth, MovieFlieName);
        //         using (var stream = new FileStream(fullPath, FileMode.Create))
        //             {
        //                 movie.MovieFlieType.CopyTo(stream);
        //             }
        //     }
               
        //      var movies = new Movie
        //         {
        //             MovieName = movie.MovieName,
        //             Director = movie.Director,
        //             Year = movie.Year,
        //             MoviePrice = movie.MoviePrice,
        //             TimeCreted = DateTime.UtcNow.AddDays(-1),
        //             MovieFlieType = MovieFlieName,
        //             Moviedate = DateTime.Now.AddDays(2),
        //         };
        //         var creamo = _repo.CreateMovie(movies);
        //         if (creamo == null)
        //         {
        //             return new MovieResponceModel
        //             {
        //                 Message = "fail to create",
        //                  Status = false,
        //             };
        //         }
        //           return new MovieResponceModel
        //         {
        //               Data = new MovieDto
        //            {
        //                 MovieName = movie.MovieName,
        //                 Director = movie.Director,
        //                 Year = movie.Year,
        //                 MoviePrice = movie.MoviePrice,
        //                 TimeCreted = DateTime.UtcNow.AddDays(-1),
        //                 MovieFlieType = MovieFlieName,
        //                 Moviedate = DateTime.Now.AddDays(2),
        //            },
        //            Message = "successfully create",
        //             Status = true,
        //         };

            
        // }

        public void DeleteMovie(int id)
        {
            var DelMovie = _repo.GetMoviesbyid(id);
            // if (DelMovie == null)
            // {
            //     DelMovie.IsDeleted = true;
                _repo.DeleteMovie(DelMovie);
            // }
        }


        public CreateMovieRequestmodel GetMoviesById(int id) 
        {
            var mid = _repo.GetMoviesbyid(id);
            return new CreateMovieRequestmodel
            {
                 Id = mid.Id,
                    MovieName = mid.MovieName,
                    Director = mid.Director,
                    Year = mid.Year,
                    MoviePrice = mid.MoviePrice,
                    TimeCreted = DateTime.UtcNow,
                    MovieFliePath = mid.MovieFliePath,
                    Moviedate = DateTime.Now.AddDays(+2),
            };
        }
        // public MovieResponceModel GetMoviesById(int id)
        // {
        //     var getmovie = _repo.GetMoviesbyid(id);
        //     if (getmovie == null)
        //     {
        //          return new MovieResponceModel
        //         {
        //             Message = "Failed to get id",
        //             Status = false,
        //         }; 
        //     }
        //      return new MovieResponceModel{

        //          Message = "successfully fetched",
        //         Status = true,
        //         Data = new MovieDto
        //         {
        //             Id = getmovie.Id,
        //             MovieName = getmovie.MovieName,
        //             Director = getmovie.Director,
        //             Year = getmovie.Year,
        //             MoviePrice = getmovie.MoviePrice,
        //             MovieFliePath = getmovie.MovieFliePath
        //         }
        //      };
        //     //MovieFlieType
        // }

         public IList<Movie> ViewAllMovie()
        {
            return _repo.ViewAllMovie();
        }

            public UpdateMovieResponceModel UpdateMovie(UpdateMovieResponceModel movie)
            {
                 var updateMovie = _repo.GetMoviesbyid(movie.Id);
                 if (updateMovie == null)
                 {
                    return null;
                 }
                updateMovie.Director = updateMovie.Director ?? updateMovie.Director;
            updateMovie.MovieName = updateMovie.MovieName ?? updateMovie.MovieName;
            updateMovie.Year = movie.Year != null? movie.Year: updateMovie.Year;
            // updateMovie.MoviePrice = updateMovie.MoviePrice < 0 ? updateMovie.MoviePrice : updateMovie.MoviePrice;
            _repo.UpdateMovie(updateMovie);
             return movie;
            }

        // public MovieResponceModel UpdateMovie(UpdateMovieResponceModel movie)
        // {
        //     var updateMovie = _repo.GetMoviesbyid(movie.Id);
        //     if (updateMovie == null) return new MovieResponceModel
        //     {
        //         Message = "Movie Not Found",
        //         Status = false,
        //     };
        //     updateMovie.Director = updateMovie.Director ?? updateMovie.Director;
        //     updateMovie.MovieName = updateMovie.MovieName ?? updateMovie.MovieName;
        //     updateMovie.MovieFliePath = updateMovie.MovieFliePath ?? updateMovie.MovieFliePath;
        //     updateMovie.MoviePrice = updateMovie.MoviePrice < 0 ? updateMovie.MoviePrice : updateMovie.MoviePrice;
        //     updateMovie.TimeCreted = DateTime.UtcNow;
        //     updateMovie.Moviedate = DateTime.Now.AddDays(+2);
        //     _repo.UpdateMovie(updateMovie);
        //     return new MovieResponceModel
        //     {
        //         Message = " Movie  found",
        //         Status = true
        //     };
        // }

        public MovieResponceModel SearchMovieByName(string MovieName)
        {
            throw new NotImplementedException();
        }

     
    }
}





