using MovieAPP.Data.Repositories;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Business.Services
{
   public class TheaterService
    {
        ITheater _theater;

        public TheaterService(ITheater theater)
        {
            _theater = theater;
        }


        public string Register(TheaterModel theaterModel)
        {
            return _theater.Register(theaterModel);
        }


        public object SelectTheater()
        {
            return _theater.SelectTheater();
        }


        public object SelectTheaterById(int theaterId)
        {
            return _theater.SelectTheaterById(theaterId);
        }

        public string UpdateTheater(TheaterModel theaterModel)
        {
            return _theater.Update(theaterModel);
        }


        public string DeleteTheater(int theaterId)
        {
          return   _theater.Delete(theaterId);
        }


        public object LoginTheater(TheaterModel theaterModel)
        {
            return _theater.Login(theaterModel);
        }

    }
}
