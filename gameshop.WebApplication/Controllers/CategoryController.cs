using gameshop.WebApplication.Models;
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
    public class CategoryController : Controller
    {
        public IConfiguration Configuration;
        private readonly JWTOKEN TokenService;
        public CategoryController(IConfiguration configuration, JWTOKEN _token)
        {
            Configuration = configuration;
            TokenService = _token;
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
            List<CategoryVM> list = new List<CategoryVM>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);

                        System.Diagnostics.Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return View(list);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CategoryVM ob = new CategoryVM();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ob = JsonConvert.DeserializeObject<CategoryVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return View(ob);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM o)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CategoryVM ob = new CategoryVM();

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
                        ob = JsonConvert.DeserializeObject<CategoryVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


            return RedirectToAction(nameof(Index));
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM o)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CategoryVM ob = new CategoryVM();

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
                        ob = JsonConvert.DeserializeObject<CategoryVM>(apiResponse);
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
