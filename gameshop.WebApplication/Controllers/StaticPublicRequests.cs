using gameshop.WebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class StaticPublicRequests
    {
        private static String httpAPI = "https://localhost:5001/";
        public static async Task<List<CategoryVM>> GetCategories()
        {
            string _restpath = httpAPI + "Category";

            //var token = AccountController.TokenString;
            List<CategoryVM> list = new List<CategoryVM>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<CategoryVM>>(apiResponse);

                        System.Diagnostics.Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                
            }

            return list;
        }

        public static async Task<List<PlatformVM>> GetPlatforms()
        {
            string _restpath = httpAPI + "Platform";

            //var token = AccountController.TokenString;
            List<PlatformVM> list = new List<PlatformVM>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<PlatformVM>>(apiResponse);

                        System.Diagnostics.Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public static async Task<List<CompanyVM>> GetDevelopers()
        {
            string _restpath = httpAPI + "Developer";

            //var token = AccountController.TokenString;
            List<CompanyVM> list = new List<CompanyVM>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<CompanyVM>>(apiResponse);

                        System.Diagnostics.Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public static async Task<List<CompanyVM>> GetPublishers()
        {
            string _restpath = httpAPI + "Publisher";

            //var token = AccountController.TokenString;
            List<CompanyVM> list = new List<CompanyVM>();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    System.Diagnostics.Debug.WriteLine(httpClient.DefaultRequestHeaders);
                    using (var response = await httpClient.GetAsync(_restpath))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        list = JsonConvert.DeserializeObject<List<CompanyVM>>(apiResponse);

                        System.Diagnostics.Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {

            }

            return list;
        }

        public static async Task<List<GameVM>> GetGames()
        {
            string _restpath = httpAPI + "Game";

            //var token = AccountController.TokenString;
            List<GameVM> list = new List<GameVM>();
            try
            {
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
            }
            catch (Exception e)
            {

            }
            return list;
        }
    }
}
