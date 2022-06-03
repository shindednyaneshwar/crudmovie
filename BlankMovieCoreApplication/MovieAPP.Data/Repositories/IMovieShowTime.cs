using System;
using System.Collections.Generic;
using System.Text;
using MovieAPP.Entity;

namespace MovieAPP.Data.Repositories
{
   public interface IMovieShowTime
    {
        string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel);

        List<MovieShowTimeModel> ShowMovieShowTime();

        string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel);

        string DeleteMovieShowTime(int showId);

        object SelectMovieShowById(int showId);
    }
}
