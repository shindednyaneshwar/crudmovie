using Microsoft.EntityFrameworkCore;
using MovieAPP.Data.DataConnections;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAPP.Data.Repositories
{
    public class Theater : ITheater
    {
        MovieDBContext _movieDBContext;

        public Theater(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
        public string Delete(int theaterId)
        {
           var theater= _movieDBContext.theaterModel.Find(theaterId);
            if (theater == null)
                return "";
            _movieDBContext.Entry(theater).State = EntityState.Deleted;
            _movieDBContext.SaveChanges();
            return "Deleted";


        }

        public TheaterModel Login(TheaterModel theaterModel)
        {
            TheaterModel theaterData = null;
           var theater= _movieDBContext.theaterModel.Where(u => u.Email == theaterModel.Email && u.Password == theaterModel.Password).ToList();
            if (theater.Count > 0)
                theaterData = theater[0];
            return theaterData;

        }

        public string Register(TheaterModel theaterModel)
        {
            string msg = "";
            _movieDBContext.theaterModel.Add(theaterModel);
            _movieDBContext.SaveChanges();
            msg = "Inserted";
          return msg;
        }

        //select * from theaterModel(table) i.e for display purpose
        public object SelectTheater()
        {
           List<TheaterModel> theaterModel = _movieDBContext.theaterModel.ToList();
            return theaterModel;
        }

        public object SelectTheaterById(int theaterId)
        {
            var theater=_movieDBContext.theaterModel.Find(theaterId);
            if (theater == null)
                return "";
            return theater;
        }

        public string Update(TheaterModel theaterModel)
        {
            _movieDBContext.Entry(theaterModel).State = EntityState.Modified;
            _movieDBContext.SaveChanges();
            return "Updated";
        }
    }
}
