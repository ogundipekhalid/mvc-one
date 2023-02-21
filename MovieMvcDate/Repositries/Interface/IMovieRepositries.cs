using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.Models.Dto.RequestModel;
using MovieMvcDate.Models.Entites;

namespace MovieMvcDate.Repositries.Interface
{
    public interface IMovieRepositries
    {
        Movie CreateMovie (Movie movie);
        Movie UpdateMovie (Movie  movie);
        Movie DeleteMovie (Movie  movie);
        Movie SerchMovieByname(string moviename);
        Movie GetMoviesbyid(int id);
        IList<Movie>ViewAllMovie();  
    }
}