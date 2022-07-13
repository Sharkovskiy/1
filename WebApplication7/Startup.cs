using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using WebApplication7.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using WebApplication7.Repositories;


namespace WebApplication7
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        //ListOfGoods listOfGoods = new ListOfGoods("http://www.mocky.io/v2/5e307edf3200005d00858b49");
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GoodsContext>(
            options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            //services.AddDbContext<>
            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IGoodsRepository, GoodsRepository>(); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookAPI", Version = "v1" });
            });
        }
    }
}

