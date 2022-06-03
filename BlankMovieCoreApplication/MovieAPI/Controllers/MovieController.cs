using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPP.Business.Services;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;

        }

        [HttpGet ("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieService.SelectMovie());
        }

        [HttpPost ("Register")]
        public IActionResult Register(MovieModel movieModel)
        {
            return Ok(_movieService.Register(movieModel));
        }

        [HttpGet ("SelectMovieById")]
        public IActionResult SelectMovieById(int movieId)
        {
            return Ok(_movieService.SelectMovieById(movieId));
        }

        [HttpDelete ("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            return Ok(_movieService.DeleteMovie(movieId));
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie(MovieModel movieModel)
        {
            return Ok(_movieService.UpdateMovie(movieModel));
        }


    }
}
