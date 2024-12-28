using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kuaforsln.Models;
using kuaforsln.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace kuaforsln
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    cfg =>
                    {
                        cfg.SlidingExpiration = false;
                        cfg.ExpireTimeSpan = new TimeSpan(10000000000);
                        cfg.AccessDeniedPath = "/Home";
                        cfg.LoginPath = "/Giris";
                        cfg.LogoutPath = "/Giris";
                    });

            services.AddDbContext<BerberWebContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:MSSQL"]);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddAuthorization();
            ;
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=About}/{id?}");
            });
        }
    }
}