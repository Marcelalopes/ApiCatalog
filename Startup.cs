using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using api_catalogo.Context;
using api_catalogo.service;
using api_catalogo.Repository.Interfaces;
using api_catalogo.Repository;
using api_catalogo.config;

namespace api_catalogo
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
      string connection = Configuration.GetConnectionString("conexaoMySQL");
      services.AddDbContextPool<AppDbContext>(
        options => options.UseMySql(
          connection, ServerVersion.AutoDetect(connection)
        ));

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "api_catalogo", Version = "v1" });
      });

      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<IProductRepository, ProductRepository>();

      services.AddAutoMapper(typeof(AutoMapperProfile));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "api_catalogo v1");
              c.RoutePrefix = "";
            }
        );
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
