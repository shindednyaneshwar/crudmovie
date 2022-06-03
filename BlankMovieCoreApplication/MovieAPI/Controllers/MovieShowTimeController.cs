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
    public class MovieShowTimeController : ControllerBase
    {
        MovieShowTimeService _movieShowTimeService;

        public MovieShowTimeController(MovieShowTimeService movieShowTimeService)
        {
            _movieShowTimeService = movieShowTimeService;
        }

        [HttpGet("ShowMovieTimeList")]
        public IActionResult ShowMovieTimeList()
        {
            return Ok(_movieShowTimeService.ShowMovieTimeList());
        }


        [HttpPost("InsertMovieShowTime")]

        public IActionResult InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_movieShowTimeService.InsertMovieShowTime(movieShowTimeModel));
        }

        [HttpDelete ("DeleteMovieShowTime")]
       public IActionResult DeleteMovieShowTime(int showId)
        {
            return Ok(_movieShowTimeService.DeleteMovieShowTime(showId));

        }

        [HttpGet ("SelectMovieShowById")]
        public IActionResult SelectMovieShowById(int showId)
        {
            return Ok(_movieShowTimeService.SelectMovieShowById(showId));
        }

        [HttpPut ("UpdateMovieShowTime")]
        public IActionResult UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_movieShowTimeService.UpdateMovieShowTime(movieShowTimeModel));
        }


    }
}
