using gameshop.WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IConfiguration Configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration _Configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            Configuration = _Configuration;
        }

        public ContentResult GetHostUrl()
        {
            var r = Configuration["RestApiUrl:HostUrl"];
            return Content(r);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (!ModelState.IsValid)    //blad logowania - nie bledne haslo jako niezgodne z walidacja
                return View(loginVM);

            //zwraca name usera do zalogowania
            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                //logowanie
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Niepoprawna nazwa użytkownika lub hasło...");

            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid) //wprowadzone wartości logowania zgodne z walidacją; ModelState-model predefiniowany
            {
                var user = new IdentityUser() { UserName = registerVM.Login };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                //var newID = await _signInManager.id.GetUserIdAsync(user);
                if (result.Succeeded)
                {
                    /*var _result = await _signInManager.PasswordSignInAsync(user, registerVM.Password, false, false);

                    if (_result.Succeeded)
                    {*/
                        //Dodanie roli użytkownika
                        //await _userManager.AddToRoleAsync(user, "User");

                        string _restpath = GetHostUrl().Content + "User";

                        System.Diagnostics.Debug.WriteLine(user.Id);

                        UserVM userVM = new UserVM()
                        {
                            UserId = user.Id,
                            Forename = registerVM.Forename,
                            Surname = registerVM.Surname,
                            Email = registerVM.Email,
                            Phonenumber = registerVM.Phonenumber,
                            BornDate = registerVM.BornDate,
                        };
                    
                        try
                        {
                            using var httpClient = new HttpClient();
                            string jsonString = System.Text.Json.JsonSerializer.Serialize(userVM);
                            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                            using var response = await httpClient.PostAsync($"{_restpath}", content);
                            if (response.IsSuccessStatusCode)
                            {
                                //Przekierowanie na strone główną
                                System.Diagnostics.Debug.WriteLine("Utworzono uzytkownika");
                                return RedirectToAction("Index", "Home");
                        }
                            else
                            {
                                //Błąd przy rejestracji użytkownika
                                System.Diagnostics.Debug.WriteLine("Blad przeslania");
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                    //}
                }
            }
            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
