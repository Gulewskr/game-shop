using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace gameshop.WebApplication.Models
{
    //Klasa generująca JSON Web Token
    public class JWTOKEN
    {
        private IConfiguration Configuration;
        public JWTOKEN(IConfiguration configuration)
        {
            Configuration = configuration;

            TokenUrl = "http://localhost:5001";
            SecretKey = "SuperTajneHaslo111222";
        }
        public string TokenUrl { get; set; }
        public string SecretKey { get; set; }

        public string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{SecretKey}"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: $"{TokenUrl}",
                audience: $"{TokenUrl}",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}


