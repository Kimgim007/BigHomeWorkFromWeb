using BigHomeWorkFromWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

namespace BigHomeWorkFromWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var users = UserHelper.GetUsers();
            users.Wait();
            var user = users.Result.Max(q=>q.Id);

            var adress = AdressHelper.GetAdress();
            adress.Wait();
            var adres = adress.Result.Max(q=>q.Id);

            MaxUserId.maxUserId = user;
            MaxAdressId.maxAdressId = adres;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
