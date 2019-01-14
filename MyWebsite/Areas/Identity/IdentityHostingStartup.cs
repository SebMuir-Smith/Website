using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebsite.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MyWebsite.Areas.Identity.IdentityHostingStartup))]
namespace MyWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyWebsiteIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("MyWebsiteIdentityDbContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>()
                    //.AddEntityFrameworkStores<MyWebsiteIdentityDbContext>();
            });
        }
    }
}