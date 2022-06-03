using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Data.Repositories
{
    public interface ITheater
    {
        string Register(TheaterModel theaterModel);
        TheaterModel Login(TheaterModel theaterModel);
        string Delete(int theaterId);

       string Update (TheaterModel theaterModel);

        object SelectTheater();

        object SelectTheaterById(int theaterId);


    }
}
