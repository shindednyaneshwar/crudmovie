using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPP.Business.Services;
using MovieAPP.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet ("SelectUsers")]
        //it accept json or xml result
        public IActionResult SelectUsers()
        {
            return Ok(_userService.SelectUsers());
        }

        [HttpPost ("Register")]

        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
        }


        [HttpDelete("DeleteUser")]
        //it accept json or xml result
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userService.DeleteUser(userId));
        }


        [HttpPut ("UpdateUser")]
        public IActionResult UpdateUser(UserModel userModel)
        {
            return Ok(_userService.UpdateUser(userModel));
        }


        [HttpGet ("SelectUserById")]
        public object SelectUserById(int userId)
        {
            return Ok(_userService.SelectUserById(userId));
        }

        [HttpPost("LoginUser")]
        public object LoginUser(UserModel userModel)
        {
            return Ok(_userService.LoginUser(userModel));
        }


    }
}
