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
    public class TheaterController : Controller
    {
        IConfiguration _configuration;
        
        public TheaterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowTheaterDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                //  server api=http://localhost:5000/api/Theater/SelectTheater

                string endPoint = _configuration["WebApibaseUrl"] + "Theater/SelectTheater";

                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();
                        //deseralize json-string to object i.e UserModel
                        var theaterModel = JsonConvert.DeserializeObject<List<TheaterModel>>(result);
                      
                        return View(theaterModel);
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
        public async Task<IActionResult> Register(TheaterModel theaterModel)
        {
            // ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theaterModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "Theater/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Registered";
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


        public async Task<IActionResult> EditTheater(int theaterId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/Theater/SelectTheaterById
                string endPoint = _configuration["WebApibaseUrl"] + "Theater/SelectTheaterById?theaterId=" + theaterId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var theaterModel = JsonConvert.DeserializeObject<TheaterModel>(result);
                        return View(theaterModel);
                    }




                }


            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditTheater(TheaterModel theaterModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theaterModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "Theater/UpdateTheater";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theater Updated SuccessFully !!";
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
        public async Task<IActionResult> Delete(int theaterId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/Theater/SelectTheaterById
                string endPoint = _configuration["WebApibaseUrl"] + "Theater/SelectTheaterById?theaterId=" + theaterId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var theaterModel = JsonConvert.DeserializeObject<TheaterModel>(result);
                        return View(theaterModel);
                    }




                }


            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TheaterModel theaterModel)
        {
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApibaseUrl"] + "Theater/DeleteTheater?theaterId=" + theaterModel.TheaterId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = " Theater Deleted SuccessFully !!";
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



