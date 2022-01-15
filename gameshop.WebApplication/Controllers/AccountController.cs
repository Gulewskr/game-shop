﻿using gameshop.WebApplication.Models;
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
                    //Dodanie roli użytkownika
                    //await _userManager.AddToRoleAsync(user, "User");

                    string _restpath = GetHostUrl().Content + "User";
                    
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
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            //Błąd przy rejestracji użytkownika
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
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

        public async Task<string> GenerateJSONWebToken()
        {
            if (_signInManager.IsSignedIn(User))
            {
                //TODO przenieść do configu
                var key = "SuperTajneHaslo111222";

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var user = await _userManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim("ID", user.Id),
                    new Claim("Name", User.Identity.Name),
                    new Claim("Roles", roles.ToString())
                };

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMonths(3),
                    signingCredentials: credentials,
                    claims: claims
                  );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "";
            }

        }
    }
}