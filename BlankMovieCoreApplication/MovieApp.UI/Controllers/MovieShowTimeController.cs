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
    public class MovieShowTimeController : Controller
    {
        IConfiguration _configuration;

        public MovieShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApibaseUrl"] + "MovieShowTime/ShowMovieTimeList";
                using(var response = await client.GetAsync(endpoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimeModels= JsonConvert.DeserializeObject<List<MovieShowTimeModel>>(result);

                  
                        return View(movieShowTimeModels);

                    }

                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No data found";
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> InsertMovieTime()
        {
            using (HttpClient client = new HttpClient())
            {
                //url http://localhost:5000/api/Movie/SelectMovie
                string endPoint = _configuration["WebApibaseUrl"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        List<SelectListItem> selectListItemsmovies = new List<SelectListItem>();

                        foreach (var item in movieModel)
                        {
                            SelectListItem _selectListItem = new SelectListItem();
                            _selectListItem.Text = item.MovieName;
                            _selectListItem.Value = item.MovieId.ToString();
                            selectListItemsmovies.Add(_selectListItem);
                        }
                        ViewBag.movieList = selectListItemsmovies;
                        
                    }

                }
              
            }
            using (HttpClient client = new HttpClient())
            {
                //  server api=http://localhost:5000/api/Theater/SelectTheater

                string endPoint = _configuration["WebApibaseUrl"] + "Theater/SelectTheater";

                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel
                        var theaterModel = JsonConvert.DeserializeObject<List<TheaterModel>>(result);
                        List<SelectListItem> selectListItemstheaters = new List<SelectListItem>();

                        foreach (var item in theaterModel)
                        {
                            SelectListItem _selectListItem = new SelectListItem();
                            _selectListItem.Text = item.TheaterName;
                            _selectListItem.Value = item.TheaterId.ToString();
                            selectListItemstheaters.Add(_selectListItem);
                        }
                        ViewBag.theaterList = selectListItemstheaters;
                        
                    }
                }

                
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertMovieTime(MovieShowTimeModel movieShowTimeModel)
        {
            using(HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endpont = _configuration["WebApibaseUrl"] + "MovieShowTime/InsertMovieShowTime";
                using (var response = await client.PostAsync(endpont, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    { 
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted Successfully!!";
                        return RedirectToAction("Index");

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

        public async Task<IActionResult> UpdateMSTime(int showId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/MovieShowTime/SelectMovieShowById
                string endPoint = _configuration["WebApibaseUrl"] + "MovieShowTime/SelectMovieShowById?showId=" + showId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var movieShowTimeModel = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimeModel);
                    }

                }
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMSTime(MovieShowTimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "MovieShowTime/UpdateMovieShowTime";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie Show time Updated SuccessFully !!";
                      //  return RedirectToAction("Index");   Diectly show updated table
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
        public async Task<IActionResult> DeleteMSTime(int showId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/MovieShowTime/SelectMovieShowById
                string endPoint = _configuration["WebApibaseUrl"] + "MovieShowTime/SelectMovieShowById?showId=" + showId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var movieShowTimeModel = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimeModel);
                    }




                }


            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMSTime(MovieShowTimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApibaseUrl"] + "MovieShowTime/DeleteMovieShowTime?showId=" + movieShowTimeModel.ShowId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deleted SuccessFully !!";
                        // return RedirectToAction("Index");   Diectly show view of index table
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

    }
}
