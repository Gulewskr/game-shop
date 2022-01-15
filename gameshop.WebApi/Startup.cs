using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Infrastructure.Repositories;
using gameshop.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = "SuperTajneHaslo111222";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            services.AddControllers();
            //Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            //Cart
            services.AddScoped<ICartRepository, CatRepository>();
            services.AddScoped<ICartService, CartService>();
            //Order
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            //Developer
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            //Publisher
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IPublisherService, PublisherService>();
            //Platform
            services.AddScoped<IPlatformRepository, PlatformRepository>();
            services.AddScoped<IPlatformService, PlatformService>();
            //Games
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameByPlatformRepository, GameByPlatformRepository>();
            services.AddScoped<IGameByPlatService, GameByPlatService>();
            //Users
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //services.AddMvc();
            services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("GameShopConnectionString"));
                }
            );
            /*
                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddUserStore<AppDbContext>();
            */
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameShop.WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameShop.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
