﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Translator.Data.Models;

namespace Translator
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        private async Task sendResponseAsync(HttpContext context, string message, int statusCode = 200)
        {
            context.Response.ContentType = "text/plain; charset=utf-8";
            await context.Response.WriteAsync(message);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("word"))
                {
                    string word = context.Request.Query["word"];
                    Console.WriteLine(word);
                    Dictionary translation = Dictionary.Find(word);
                    if (translation == null)
                    {
                        await sendResponseAsync(context, "Not Found", 404);
                    }
                    else
                    {
                        await sendResponseAsync(context, translation.WordTo);
                    }
                }
                else
                {
                    await sendResponseAsync(context, "Client Error", 400);
                }
            });
        }
    }
}
