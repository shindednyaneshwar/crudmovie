using MovieAPP.Data.Repositories;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Business.Services
{
    public class MovieService
    {
        IMovie _movie;

        public MovieService(IMovie movie)
        {
            _movie = movie;
        }


        public string Register(MovieModel movieModel)
        {
            return _movie.Register(movieModel);
        }

        public object SelectMovie()
        {
            return _movie.SelectMovie();
        }


        public object SelectMovieById(int movieId)
        {
            return _movie.SelectMovieById(movieId);
        }

        public string DeleteMovie(int movieId)
        {
            return _movie.Delete(movieId);
        }

        public string UpdateMovie(MovieModel movieModel)
        {
            return _movie.Update(movieModel);
        }


    }
}
