using Microsoft.EntityFrameworkCore;
using MovieAPP.Data.DataConnections;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAPP.Data.Repositories
{
    public class MovieShowTime : IMovieShowTime
    {
        MovieDBContext _movieDBContext;

        public MovieShowTime(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public string DeleteMovieShowTime(int showId)
        {
            var mShow=_movieDBContext.movieShowTimeModels.Find(showId);
            if (mShow == null)
                return "";
            _movieDBContext.Entry(mShow).State = EntityState.Deleted;
            _movieDBContext.SaveChanges();

            return "Deleted show time";
        }

        public string InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            _movieDBContext.movieShowTimeModels.Add(movieShowTimeModel);
            _movieDBContext.SaveChanges();
            return "Inserted movie show time";
        }

        public object SelectMovieShowById(int showId)
        {
            var mShow = _movieDBContext.movieShowTimeModels.Find(showId);
            if (mShow == null)
                return "";
            return mShow;
        }

        public List<MovieShowTimeModel> ShowMovieShowTime()
        {
            return _movieDBContext.movieShowTimeModels.ToList();
        }

        public string UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            _movieDBContext.Entry(movieShowTimeModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Updated Movie Show Time";
        }
    }
}
