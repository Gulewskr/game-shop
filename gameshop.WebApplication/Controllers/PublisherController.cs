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
    public class PublisherController : Controller
    {
        public IConfiguration Configuration;
        private readonly JWTOKEN TokenService;
        public PublisherController(IConfiguration configuration, JWTOKEN _token)
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
            List<CompanyVM> list = new List<CompanyVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<CompanyVM>>(apiResponse);

                    System.Diagnostics.Debug.WriteLine(response.StatusCode);
                }
            }

            return View(list);
        }
        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();
            CompanyVM ob = new CompanyVM();
            List<CompanyVM> list = new List<CompanyVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ob = JsonConvert.DeserializeObject<CompanyVM>(apiResponse);
                }
            }

            return View(ob);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyVM o)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CompanyVM ob = new CompanyVM();
            List<CompanyVM> list = new List<CompanyVM>();

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
                        ob = JsonConvert.DeserializeObject<CompanyVM>(apiResponse);
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
            List<CompanyVM> list = new List<CompanyVM>();

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
        public async Task<IActionResult> Create(CompanyVM o)
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CompanyVM ob = new CompanyVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var jsonString = System.Text.Json.JsonSerializer.Serialize(o);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ob = JsonConvert.DeserializeObject<CompanyVM>(apiResponse);
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
