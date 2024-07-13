using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(NestAway.Web.Areas.Identity.IdentityHostingStartup))]
namespace NestAway.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}