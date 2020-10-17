using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CarSales.API
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
                    webBuilder.UseStartup<Startup>().CaptureStartupErrors(false); //this is to prevent default page being served if startup fails
                });
    }
}
