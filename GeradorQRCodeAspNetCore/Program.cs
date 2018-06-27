using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GeradorQRCodeAspNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateBuildWebHost(args).Build().Run();
        }

        public static IWebHostBuilder CreateBuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
