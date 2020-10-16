using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using lab7.Data;
using lab7.Data.Interfaces;
using lab7.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace lab7
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IBikesRepository, BikesRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IAgeTypeRepository, AgeTypeRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            //services.AddSingleton<AppDbContext>();
            services.AddDbContext<AppDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}"
                );
            });
        }
    }
}
