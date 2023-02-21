using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieMvcDate.ApplicationDbContext;
using MovieMvcDate.Models.Entites;
using MovieMvcDate.Repositries.Interface;

namespace MovieMvcDate.Repositries.Implimentation
{
    public class MovieRepositries : IMovieRepositries
    {
        private readonly ApplictionContext _moviecontext;

        public MovieRepositries (ApplictionContext moviecontext)
        {
            _moviecontext = moviecontext;
        }
        public Movie CreateMovie(Movie movie)
        {
            _moviecontext.movies.Add(movie);
            _moviecontext.SaveChanges();
            return movie;
        }

        public Movie DeleteMovie(Movie movie)
        {
            _moviecontext.movies.Remove(movie);
            _moviecontext.SaveChanges();
            return movie;
        }
        public Movie SerchMovieByname(string MovieName)
        {
             var move =_moviecontext.movies.SingleOrDefault(a => a.MovieName == MovieName);
            return move;
        }
        public Movie GetMoviesbyid(int  id)
        {
             var move =_moviecontext.movies.SingleOrDefault(a => a.Id == id);
            return move;
        }
        public Movie UpdateMovie(Movie movie)
        {
            _moviecontext.movies.Update(movie);
            _moviecontext.SaveChanges();
            return movie;
        }
        public IList<Movie> ViewAllMovie()
        {
            return _moviecontext.movies.ToList();
        }
    }
}