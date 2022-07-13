using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FiveTask1.Models;
using FiveTask1.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;



namespace FiveTask1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=goodsdbstore;Trusted_Connection=True;";
            // устанавливаем контекст данных
            services.AddDbContext<GoodsContext>(options => options.UseSqlServer(con));
            services.AddDbContext<FiveTask1.Models.GoodsContext>();
            services.AddControllers(); // используем контроллеры без представлений
            services.AddDbContext<GoodsContext>();

        }


        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();


            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }


    }
}




