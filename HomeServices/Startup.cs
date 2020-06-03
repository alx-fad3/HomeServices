using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeServices.Models;
using HomeServices.Models.Repositories.Abstract;
using HomeServices.Models.Repositories.EntityFramework;
using HomeServices.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HomeServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddDbContext<HomeDbContext>(o => 
                o.UseLazyLoadingProxies()
                .UseSqlServer(Config.ConnectionString));

            services.AddTransient<DbFiller>(); // 
            services.AddTransient<IFileManager, MusicFilesManager>();
            services.AddTransient<IDirectoryModelRepository, EFDirectoryModelRepository>();
            services.AddTransient<IFileModelRepository, EFFileModelRepository>();
            services.AddTransient<DataManager>();

            services.AddControllersWithViews();
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
