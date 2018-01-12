using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LibProject_Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LibProject_Api
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
            services.AddMvc();
            //var connection = @"Server=DESKTOP-NBS75FU\MSSQLSERVER02;Database=LibProject;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<LibProjectContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<LibProjectContext>(options => options.UseSqlServer(Configuration.GetConnectionString("connectionstring")));

            services.AddCors(options =>
            {
                //options.AddPolicy("AllowSpecificOrigin",
                //    builder => builder.WithOrigins("http://localhost:57759"));

                options.AddPolicy("AllowAllMethods",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:57759")
                               .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("AllowSpecificOrigin");
            app.UseCors("AllowAllMethods");

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                    //name: "adult-checkout",
                    //template: "api/{controller}/{adultMemberID}/MediaCopy/{mediaCopyID}",
                    //defaults: new { controller = "A_CheckOut", action = "GetByIds" });

                routes.MapRoute(
                    name: "default",
                    template: "api/{controller}/{action}/{id?}",
                    defaults: new { controller = "AdultMember", action = "GetAll" });
            });
        }
    }
}
