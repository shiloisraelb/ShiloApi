using ClassLibrary1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.Reflection;


namespace ShiloApi
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
            //the DataBase weel be singl in the app
           
            services.AddSingleton<ShiloShopContext>();
            // only the speciphic orgen can have a acsses to my api
            services.AddControllers();
            services.AddCors(
                options =>
                {
                    options.AddPolicy(name: "shilo",
                                      builder =>
                                      { 

                                          builder.WithOrigins("https://shiloshop-44962.web.app/", "https://localhost:64313/", "http://localhost:4200/", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod();          

                                      });
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if the app is in develop invirmant you can debug it
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                  c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
                 //c.RoutePrefix = string.Empty;
                });
            }
            app.UseStaticFiles();
            //Set all the midelWers.request pipeline
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("shilo");
            app.UseAuthentication();
            app.UseAuthorization();  
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
            });
        }
    }
}
