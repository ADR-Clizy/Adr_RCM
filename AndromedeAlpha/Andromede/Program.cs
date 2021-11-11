/*
*
* (c) 2021-2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Andromede
{
    public class Program
    {
        public static void Main(string[] args)
        {
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
