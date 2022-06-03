using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MovieAPP.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class MovieController : Controller
    {
        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        

        public async Task<IActionResult> ShowMovieDetails()
        {
            using(HttpClient client = new HttpClient())
            {
                //url http://localhost:5000/api/Movie/SelectMovie
                string endPoint = _configuration["WebApibaseUrl"] + "Movie/SelectMovie";
                using(var response=await client.GetAsync(endPoint))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        var movieModel= JsonConvert.DeserializeObject<List<MovieModel>>(result);
                      
                        return View(movieModel);
                    }

                }
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(MovieModel movieModel)
        {
            using(HttpClient client= new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "Movie/Register";
                using(var response=await client.PostAsync(endPoint,content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie is Registered";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "WrongEntry";
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditMovie (int movieId)
        {
            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/Movie/SelectMovieById
                string endPoint = _configuration["WebApibaseUrl"] + "Movie/SelectMovieById?movieId="+movieId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var movieModel = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModel);
                    }
                }
             }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditMovie(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie is Updated successfully";
                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "WrongEntry";
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int movieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApibaseUrl"] + "Movie/SelectMovieById?movieId=" + movieId;

                using (var response = await client.GetAsync(endpoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel= JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModel);

                    }
                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
               
                string endpoint = _configuration["WebApibaseUrl"] + "Movie/DeleteMovie?movieId="+movieModel.MovieId ;

                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deleted Successfully!!";

                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong Entry!!";
                    }
                }
            }

            return View();
        }









    }
}
