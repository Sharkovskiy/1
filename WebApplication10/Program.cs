//using Microsoft.EntityFrameworkCore;
//using WebApplication10.Models;


//var builder = WebApplication.CreateBuilder(args);
//IConfiguration configuration;

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<GoodsContext>(options =>
//options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WebApplication10;

using System.Net;

public class Program
{

    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();
}
