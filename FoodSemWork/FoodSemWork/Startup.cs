using FoodSemWork.Interfaces;
using FoodSemWork.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSemWork
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
            services.AddTransient<Service>();
            services.AddRazorPages();
            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(option => option.UseNpgsql(
                Configuration.GetConnectionString("Connect")));

            var tokenKey = Configuration.GetValue<string>("TokenKey");
            var key = Encoding.ASCII.GetBytes(tokenKey);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));
            //services.AddRazorPages();
            //services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationContext>(options => options.UseNpgsql(
            //        Configuration.GetConnectionString("DefaultConnection")
            //    )
            //);
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //{
            //    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Login");
            //    options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Home/Logout");
            //    options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
            //    options.ExpireTimeSpan = System.TimeSpan.FromDays(2);
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
