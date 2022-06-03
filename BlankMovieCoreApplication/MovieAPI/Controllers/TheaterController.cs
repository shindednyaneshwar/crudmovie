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
    public class TheaterController : ControllerBase
    {
        TheaterService _theaterService;

        public TheaterController(TheaterService theaterService)
        {
            _theaterService= theaterService;
        }

        [HttpPost ("Register")]
        public IActionResult Register(TheaterModel theaterModel)
        {
            return Ok(_theaterService.Register(theaterModel));
        }

        [HttpGet ("SelectTheater")]
        public IActionResult SelectTheater()
        {
            return Ok(_theaterService.SelectTheater());
        }

        [HttpGet("SelectTheaterById")]
        public IActionResult SelectTheaterById(int theaterId)
        {
            return Ok(_theaterService.SelectTheaterById(theaterId));
        }

        [HttpPut ("UpdateTheater")]
        public IActionResult UpdateTheater(TheaterModel theaterModel)
        {
            return Ok(_theaterService.UpdateTheater(theaterModel));
        }

        [HttpDelete ("DeleteTheater")]
        public IActionResult DeleteTheater(int theaterId)
        {
            return Ok(_theaterService.DeleteTheater(theaterId));
        }

        [HttpPost ("LoginTheater")]
        public IActionResult LoginTheater(TheaterModel theaterModel)
        {
            return Ok(_theaterService.LoginTheater(theaterModel));
        }
    }
}
