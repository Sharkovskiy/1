using WebApplication7.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WebApplication7;
using Newtonsoft.Json;
using System.Net;

public class Program
{
    GoodsContext db;
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

}

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//var app = builder.Build();
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddScoped<IGoodsRepository, GoodsRepository>();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();