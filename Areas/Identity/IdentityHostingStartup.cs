using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xau.Areas.Identity.Data;
using xau.Models;

[assembly: HostingStartup(typeof(xau.Areas.Identity.IdentityHostingStartup))]
namespace xau.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<xauIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("xauContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<xauIdentityDbContext>();
            });
        }
    }
}