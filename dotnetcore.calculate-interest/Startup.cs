using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace dotnetcore.calculate_interest
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
      services.AddMvc(option => option.EnableEndpointRouting = false);
      services.AddSingleton<IConfiguration>(Configuration);
      services.AddHttpClient("api-interest-rate", config =>
      {
        config.BaseAddress = new Uri(Configuration.GetSection("api-interest-rate:BaseURL").Value);
        config.DefaultRequestHeaders.Accept.Clear();
        config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
              Title = "Dotnet Core - Api",
              Version = "v1",
              Description = "Api feita em dotnet core com c# + docker",
              Contact = new OpenApiContact
              {
                Name = "Ricardo Netto",
                Url = new Uri("https://github.com/ricardofanetto")
              }
            });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
     if (env.IsProduction() || env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnet Core - Api");
        });
        app.UseMvc();

      }
    }
  }
}
