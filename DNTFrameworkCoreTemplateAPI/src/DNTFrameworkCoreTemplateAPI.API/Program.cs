﻿using DNTFrameworkCore.EntityFramework.Logging;
using DNTFrameworkCore.Web.EntityFramework;
using DNTFrameworkCoreTemplateAPI.API;
using DNTFrameworkCoreTemplateAPI.Infrastructure.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace DNTFrameworkCore.TestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build()
                .MigrateDbContext<ProjectDbContext>()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                    logging.AddEntityFramework<ProjectDbContext>(options => options.MinLevel = LogLevel.Warning);
                })
                .UseStartup<Startup>();
    }
}