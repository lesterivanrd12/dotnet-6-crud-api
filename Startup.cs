using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;
using dotnet_6_crud_api.Helpers;
using dotnet_6_crud_api.Services;

namespace dotnet_6_crud_api
{
    public class Startup
    {
        // private readonly IWebHostEnvironment _env;
        private readonly IConfiguration Configuration;
        // public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add services to the DI container
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<DataContext>();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
             {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnet_6_crud_api", Version = "v1" });
             });

            services.AddScoped<IUserService, UserService>();



        }

        // configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, DataContext context)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware<ErrorHandlerMiddleware>();


            app.UseEndpoints(x => x.MapControllers());
        }
    }
}