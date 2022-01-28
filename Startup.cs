using EmployeeManagement.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddMvc();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //'MvcOptions.EnableEndpointRouting = false' inside
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // It Costumizes UseDefaultFiles to accept another html file as default
            //FileServerOptions fileServerOptions = new FileServerOptions();
            // It clears the current default file
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            // It adds the new default file
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");

            //app.UseFileServer();

            //app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default", 
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                //endpoints.MapControllers();

                /*endpoints.MapGet("", async context =>
                {
                    await context.Response.WriteAsync("Hello World: " + env.EnvironmentName);
                });*/
            });

            //app.Run(async (context) =>
            //{
            //   // await context.Response.WriteAsync("Hello World: " + env.EnvironmentName);
            //});

        }
    }
}
