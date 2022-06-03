using Microsoft.EntityFrameworkCore;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Data.DataConnections
{
    public class MovieDBContext :DbContext
    {
        //MovieDBContext class act as database
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {

        }

        //userModel acts as table name
        public DbSet<UserModel> userModel { get; set; }

        //movieModel acts as table name
        public DbSet<MovieModel> movieModel { get; set; }

        public DbSet<TheaterModel> theaterModel { get; set; }

        public DbSet<MovieShowTimeModel> movieShowTimeModels { get; set; }

    }

    
}
