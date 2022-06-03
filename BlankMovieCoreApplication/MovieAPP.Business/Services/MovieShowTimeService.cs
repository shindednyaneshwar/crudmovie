using MovieAPP.Data.Repositories;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Business.Services
{
   public class MovieShowTimeService
    {
        IMovieShowTime _movieShowTime;

        public MovieShowTimeService(IMovieShowTime movieShowTime)
        {
            _movieShowTime = movieShowTime;
        }

        public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.InsertMovieShowTime(movieShowTimeModel);

        }

        public List<MovieShowTimeModel> ShowMovieTimeList()
        {
            return _movieShowTime.ShowMovieShowTime();
        }

        public string DeleteMovieShowTime(int showId)
        {
            return _movieShowTime.DeleteMovieShowTime(showId);
        }

        public object SelectMovieShowById(int showId)
        {
            return _movieShowTime.SelectMovieShowById(showId);
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return _movieShowTime.UpdateMovieShowTime(movieShowTimeModel);
        }
    }
}
