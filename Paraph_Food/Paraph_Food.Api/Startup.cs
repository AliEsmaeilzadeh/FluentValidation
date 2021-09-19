using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paraph_Food.Api.Configurations.ExtentionMethods;
using Paraph_Food.Api.Helper.Attributes;
using Paraph_Food.Application.Common.AppSettings;
using Paraph_Food.Application.Context;
using Paraph_Food.Application.Services.Products.FacadPattern;
using Paraph_Food.Application.Services.Users.FacadPattern;
using Paraph_Food.Persistence.Context;

namespace Paraph_Food.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        private string connectionString = "";
        private AppSettings _appSettings = new AppSettings();
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // دریافت تنظیمات سیستم
            var section = _configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(section);
            _appSettings = section.Get<AppSettings>();

            WebRoot.Path = _env.WebRootPath;

            connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Paraph_DbContext>(option => option.UseSqlServer(connectionString, o => o.UseNetTopologySuite()));

            services.AddScoped<IParaph_DbContext, Paraph_DbContext>();
            services.AddScoped<IUsersFacad, UsersFacad>();
            services.AddScoped<IProductsFacad, ProductsFacad>();

            services.AddScoped<MyAuthorizeAttribute>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwagger();
            services.AddAuthentications(_appSettings);

            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=StartApi}/{id?}");
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                   name: "Admin",
                   areaName: "Admin",
                   pattern: "Admin/{controller=Home}/{action=StartApi}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "CustomerApp",
                   areaName: "CustomerApp",
                   pattern: "CustomerApp/{controller=Home}/{action=StartApi}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "CustomerApp/{controller=Home}/{action=StartApi}/{id?}");

                endpoints.MapRazorPages();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(_appSettings.SwaggerEndpoint.Url, _appSettings.SwaggerEndpoint.Name);
            });
        }
    }
}
