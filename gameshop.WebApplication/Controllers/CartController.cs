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
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class CartController : Controller
    {
        public IConfiguration Configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTOKEN TokenService;
        public CartController(IConfiguration configuration, JWTOKEN _token, UserManager<IdentityUser> userManager)
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

        public async Task<IActionResult> UserCart()
        {
            string _restpath = GetHostUrl().Content + CN();
            var token = TokenService.GenerateJSONWebToken();

            CartVM ob = new CartVM();
            List<OrderVM> orders = new List<OrderVM>();
            if(User.Identity.IsAuthenticated)
            try
            {
                var user = await _userManager.GetUserAsync(User);
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    using (var response = await httpClient.GetAsync($"{_restpath}/user-{user.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ob = JsonConvert.DeserializeObject<CartVM>(apiResponse);
                    }

                    _restpath = GetHostUrl().Content + "Order";
                    using (var response = await httpClient.GetAsync($"{_restpath}/cart-{ob.Id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        orders = JsonConvert.DeserializeObject<List<OrderVM>>(apiResponse);
                    }
                }
                ViewData["orders"] = orders;
                return View(ob);
            }
                catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            string _restpath = GetHostUrl().Content + "Order";
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
                System.Diagnostics.Debug.WriteLine(_restpath);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return RedirectToAction(nameof(UserCart));
        }
    }
}
