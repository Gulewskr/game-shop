using gameshop.WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class GameController : Controller
    {
        public IConfiguration Configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTOKEN TokenService;
        public GameController(IConfiguration configuration, JWTOKEN _token, UserManager<IdentityUser> userManager)
        {
            Configuration = configuration;
            TokenService = _token;
            _userManager = userManager;
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

            var token = TokenService.GenerateJSONWebToken();
            List<GameVM> list = new List<GameVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

        public async Task<IActionResult> GameFilter(int PlatformID, int CategoryID)
        {
            string _restpath = GetHostUrl().Content + CN();

            var token = TokenService.GenerateJSONWebToken();
            List<GameVM> list = new List<GameVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                using (var response = await httpClient.GetAsync($"{_restpath}?plat={PlatformID}&cat={CategoryID}"))
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
            var token = TokenService.GenerateJSONWebToken();

            GameVM ob = new GameVM();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            var token = TokenService.GenerateJSONWebToken();

            GameVM ob = new GameVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            var token = TokenService.GenerateJSONWebToken();

            GameVM ob = new GameVM();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

        public async Task<IActionResult> DetailsShop(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            GameVM ob = new GameVM();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ob = JsonConvert.DeserializeObject<GameVM>(apiResponse);
                }
            }
            List<PlatformVM> platforms = await StaticPublicRequests.GetPlatforms();
            ViewBag.Platforms = platforms;
            List<GameByPlat> gbp = await GetGames(id);
            ViewBag.GamesByPlat = gbp;
            ViewBag.Test = "????";
            foreach (GameByPlat g in gbp) Console.WriteLine(g.PlatformID);
            foreach (PlatformVM g in platforms) Console.WriteLine(g.Id);
            return View(ob);
        }

        public async Task<IActionResult> BuyGame(GameByPlat o, int amount)
        {
            string _restpath = GetHostUrl().Content + "Cart/AddToCart";
            var token = TokenService.GenerateJSONWebToken();

            try
            {
                var user = await _userManager.GetUserAsync(User);
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    BuyGame ob = new BuyGame()
                    {
                        amount = amount,
                        GameID = o.Id,
                        UserID = user.Id
                    };

                    string jsonString = System.Text.Json.JsonSerializer.Serialize(ob);
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

            return RedirectToAction("DetailsShop", new { id = o.GameID });
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            var token = TokenService.GenerateJSONWebToken();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
            var token = TokenService.GenerateJSONWebToken();

            List<GameByPlat> list = new List<GameByPlat>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                
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
        public async Task<IActionResult> AddGames(GameByPlat o)
        {
            string _restpath = GetHostUrl().Content + "GamePlatform";
            var token = TokenService.GenerateJSONWebToken();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
    }
}
