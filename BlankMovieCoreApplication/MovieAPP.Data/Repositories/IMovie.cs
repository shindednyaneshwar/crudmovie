using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAPP.Data.Repositories
{
    public interface IMovie
    {
         string Register(MovieModel movieModel);
        string Update(MovieModel movieModel);

        string Delete(int movieId);

        object SelectMovie();

        object SelectMovieById(int movieId);
    }
}
