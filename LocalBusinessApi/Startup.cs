// using System;
// using System.Collections.Generic;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.HttpsPolicy;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Logging;
// using Microsoft.OpenApi.Models;
// using Microsoft.EntityFrameworkCore;
// using LocalBusinessApi.Models;

// namespace LocalBusinessApi
// {
//   public class Startup
//   {
//     public Startup(IConfiguration configuration)
//     {
//       Configuration = configuration;
//     }

//     public IConfiguration Configuration { get; }

//     // This method gets called by the runtime. Use this method to add services to the container.
//     public void ConfigureServices(IServiceCollection services)
//     {

//       services.AddDbContext<LocalBusinessContext>(opt =>
//         opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
//       services.AddControllers();
//     }

//     // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//       if (env.IsDevelopment())
//       {
//         app.UseDeveloperExceptionPage();
//       }

//       // app.UseHttpsRedirection();

//       app.UseRouting();

//       app.UseAuthorization();

//       app.UseEndpoints(endpoints =>
//       {
//         endpoints.MapControllers();
//       });
//     }
//   }
// }

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LocalBusinessApi.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace LocalBusinessApi
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

      services.AddDbContext<LocalBusinessContext>(opt =>
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers();
      //Swagger
      services.AddSwaggerGen(c=>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Local Business API",
          Description ="An API built to help locals to be able to get information of any local business in their community",
          Contact = new OpenApiContact
          {
            Name ="Ryan Gibson",
            Email ="ryaninlux@gmail.com"
            
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      //Enable middleware
      app.UseSwagger(c =>
      {
        c.SerializeAsV2 =true;

      });
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json"," API V1");
        c.RoutePrefix = string.Empty;
      });

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}