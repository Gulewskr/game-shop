using gameshop.WebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class ImageController : Controller
    {
        public IConfiguration Configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JWTOKEN TokenService;
        public ImageController(IConfiguration configuration, JWTOKEN _token, UserManager<IdentityUser> userManager)
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

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile image)
        {
            string _restpath = GetHostUrl().Content + "ImagesUpload";
            var token = TokenService.GenerateJSONWebToken();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    //string jsonString = System.Text.Json.JsonSerializer.Serialize(image);
                    var content = new MultipartFormDataContent();

                    if (image.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            image.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            // act on the Base64 data
                            content.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), "image", image.FileName);
                            using (var response = await httpClient.PostAsync($"{_restpath}", content))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                return Content(apiResponse);
                            }
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(_restpath);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return Content("NULL");
        }
    }
}
