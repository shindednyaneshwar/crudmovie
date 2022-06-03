 using Microsoft.EntityFrameworkCore;
using MovieAPP.Data.DataConnections;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAPP.Data.Repositories
{
    public class Movie : IMovie
    {
        //to access usermodel from dataconnection i have to create instance of class i.e MovieDbContext
        MovieDBContext _movieDBContext;

        public   Movie (MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

      

        //Now you have to insert record of MovieModel from entity inside movieModel table
        public string Register(MovieModel movieModel)
        {
            string msg = "";
            //insert into movieModel values(movieModel.Id,movieModel.MName like that)
            _movieDBContext.movieModel.Add(movieModel);
            _movieDBContext.SaveChanges();

            msg = "Inserted";

            return msg;

        }

        public object SelectMovie()
        {
            //selct * from movieModel(table)
           List<MovieModel>movieList= _movieDBContext.movieModel.ToList();
            return movieList;
        }

        public string Update(MovieModel movieModel)
        {
           
            _movieDBContext.Entry(movieModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Updated";

        }


        public string Delete(int movieId)
        {
            var movie = _movieDBContext.movieModel.Find(movieId);
            if (movie == null)
                return "";
            _movieDBContext.Entry(movie).State = EntityState.Deleted;
            _movieDBContext.SaveChanges();
            return "deleted";

        }


        public object SelectMovieById(int movieId)
        {
           var movie= _movieDBContext.movieModel.Find(movieId);
            if (movie == null)
                return "";
            return movie;
        }
    }
}
