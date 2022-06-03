using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieAPP.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> ShowUserDetails()
        {
            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/User/SelectUsers
                string endPoint = _configuration["WebApibaseUrl"] + "User/SelectUsers";
                // we are passing getrequest to server  with urel
                using(var response = await client.GetAsync(endPoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var userModel = JsonConvert.DeserializeObject<List<UserModel>>(result);
                        return View(userModel);
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
        public async Task<IActionResult> Register(UserModel userModel)
        {
           // ViewBag.status = "";

            if(ModelState.IsValid)
            { 
               using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "User/Register";
                using (var response = await client.PostAsync(endPoint,content))
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
            }
            return View();
        }

        public async Task<IActionResult> EditUser(int userId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/User/SelectUserById
                string endPoint = _configuration["WebApibaseUrl"] + "User/SelectUserById?userId="+userId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }




                }
            

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApibaseUrl"] + "User/UpdateUser";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User Updated SuccessFully !!";
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
        public async Task<IActionResult> Delete(int userId)
        {

            using (HttpClient client = new HttpClient())

            {
                //server api=http://localhost:5000/api/User/SelectUserById
                string endPoint = _configuration["WebApibaseUrl"] + "User/SelectUserById?userId=" + userId;
                // we are passing getrequest to server  with urel
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)

                    {
                        //string-json results come
                        var result = await response.Content.ReadAsStringAsync();

                        //deseralize json-string to object i.e UserModel
                        var userModel = JsonConvert.DeserializeObject<UserModel>(result);
                        return View(userModel);
                    }




                }


            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
              
                string endPoint = _configuration["WebApibaseUrl"] + "User/DeleteUser?userId="+userModel.UserId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Deleted SuccessFully !!";
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


