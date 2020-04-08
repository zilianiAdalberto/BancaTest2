using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancaTest2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BancaTest2
{
    public class Program
    {


        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

             
            var host = CreateWebHostBuilder(args).Build();  // richiama metodo sottostante per inzializzare kestrel
            //using (var scope = host.Services.CreateScope()) //parametro di inzializzazioen dentro
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<AppDbContext>(); //inizializza db
            //        DbInitializer.Seed(context);
            //    }
            //    catch (Exception)
            //    {
            //        throw;
            //    }
            //}
            host.Run();




        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //richiama metodo startup
                });
    }
}
