using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CalenderApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // var host = new WebHostBuilder()
           //.UseKestrel()
           //.UseContentRoot(Directory.GetCurrentDirectory())
           //.UseIISIntegration()
           //.UseStartup()
           //.Build();

           // host.Run();

            CreateHostBuilder(args).Build().Run();


        //    var builder = CalenderApi.CreateBuilder(args);

        //    builder.Services.AddDbContext<MvcMovieContext>(options =>
        //options.UseSqlServer(builder.Configuration.GetConnectionString("MvcMovieContext")));

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

  
    }
}
