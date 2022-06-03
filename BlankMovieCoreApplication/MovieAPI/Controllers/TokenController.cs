using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieAPP.Data.DataConnections;
using MovieAPP.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        IConfiguration _configuration;
        private readonly MovieDBContext _movieDBContext;

        public TokenController(IConfiguration configuration, MovieDBContext movieDBContext)
        {
            _configuration = configuration;
            _movieDBContext = movieDBContext;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post (UserModel userModel)
        {
            if (userModel != null && userModel.Email != null && userModel.Password != null)
            {
                var user = await GetUser(userModel.Email, userModel.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var Claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.UserId.ToString()),
                        new Claim("FirstName",user.FirstName),
                       new Claim("LastName",user.LastName),
                       new Claim("Email",user.Email),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], Claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }

            else
                return BadRequest();
        }

        private async Task<UserModel> GetUser(string email,string password)
        {
            UserModel userModel = null;
            var result = _movieDBContext.userModel.Where(u => u.Email == email && u.Password == password);
         
             foreach (var item in result)
            {
                userModel = new UserModel();
                userModel.UserId = item.UserId;
                userModel.FirstName = item.FirstName;
                userModel.LastName = item.LastName;
                userModel.Email = item.Email;
                userModel.Mobile = item.Mobile;

            }

            return userModel;


         }
    }
}
