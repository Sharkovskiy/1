using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System;
using System.Collections.Generic;
using WebApplication12.Models;
using WebApplication12.Lists;
using Microsoft.EntityFrameworkCore;

namespace WebApplication12
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            endpoints.MapControllers());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ListOfGoods>();
            services.AddScoped<ListOfSortedGoods>();
            services.AddScoped<Logic>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddControllers(); 
        }
    }
}

