using gameshop.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class GameController : Controller
    {
        public IConfiguration Configuration;
        public GameController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var r = Configuration["RestApiUrl:HostUrl"];
            return Content(r);
        }

        private string CN()
        {
            return ControllerContext.RouteData.Values["controller"].ToString();
        }
        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + CN();

            //var token = AccountController.TokenString;
            List<GameVM> list = new List<GameVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<GameVM>>(apiResponse);

                    System.Diagnostics.Debug.WriteLine(response.StatusCode);
                }
            }

            return View(list);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            GameVM ob = new GameVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ob = JsonConvert.DeserializeObject<GameVM>(apiResponse);
                }
            }

            List<PlatformVM> platforms = await StaticPublicRequests.GetPlatforms();
            List<CategoryVM> categories = await StaticPublicRequests.GetCategories();
            List<CompanyVM> publishers = await StaticPublicRequests.GetPublishers();
            List<CompanyVM> developers = await StaticPublicRequests.GetDevelopers();
            ViewBag.Platforms = platforms;
            ViewBag.Categories = categories;
            ViewBag.Publishers = publishers;
            ViewBag.Developers = developers;
            return View(ob);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GameVM o)
        {
            string _restpath = GetHostUrl().Content + CN();

            GameVM ob = new GameVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(o);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"{_restpath}/{o.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ob = JsonConvert.DeserializeObject<GameVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            GameVM ob = new GameVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ob = JsonConvert.DeserializeObject<GameVM>(apiResponse);
                }
            }
            List<PlatformVM> platforms = await StaticPublicRequests.GetPlatforms();
            ViewBag.Platforms = platforms;
            List < GameByPlat > gbp = await GetGames(id);
            ViewBag.GamesByPlat = gbp;
            return View(ob);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            List<PlatformVM> platforms = await StaticPublicRequests.GetPlatforms();
            List<CategoryVM> categories = await StaticPublicRequests.GetCategories();
            List<CompanyVM> publishers = await StaticPublicRequests.GetPublishers();
            List<CompanyVM> developers = await StaticPublicRequests.GetDevelopers();
            ViewBag.Platforms = platforms;
            ViewBag.Categories = categories;
            ViewBag.Publishers = publishers;
            ViewBag.Developers = developers;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameVM o)
        {
            string _restpath = GetHostUrl().Content + CN();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(o);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(_restpath);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            return RedirectToAction(nameof(Index));
        }

        private async Task<List<GameByPlat>> GetGames(int id)
        {
            string _restpath = GetHostUrl().Content + "GamePlatform/filter?id=" + id;

            //var token = AccountController.TokenString;
            List<GameByPlat> list = new List<GameByPlat>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<GameByPlat>>(apiResponse);

                    System.Diagnostics.Debug.WriteLine(response.StatusCode);
                }
            }

            return list;
        }

        [HttpPost]
        public async void AddGames(GameByPlat o)
        {
            string _restpath = GetHostUrl().Content + "GamePlatform";

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(o);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(_restpath);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            //return Server.TransferRequest(Request.Url.AbsolutePath, false); ;
        }
    }
}
