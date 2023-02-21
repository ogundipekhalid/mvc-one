using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Services.Interface
{
    public interface IMovieServices
    {
        Task<CreateMovieRequestmodel> CreateMovie(CreateMovieRequestmodel movie);
            public UpdateMovieResponceModel UpdateMovie(UpdateMovieResponceModel movie);

        // public MovieResponceModel UpdateMovie(UpdateMovieResponceModel movie);
         void DeleteMovie(int id);
        // public MovieResponceModel GetMoviesById(int  id);
         public MovieResponceModel SearchMovieByName(string MovieName);
        //  public CreateMovieRequestmodel GetMoviesById(int id);
        // public MovieResponceModel GetMoviesById(int id);
        public CreateMovieRequestmodel GetMoviesById(int id);

        IList<Movie>ViewAllMovie(); 
        //  public CreateMovieRequestmodel PlayVideo(int id);


    }
}