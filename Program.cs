using CarManagementApplication.Data;
using CarManagementApplication.Data.Repositories;
using CarManagementApplication.Middleware;
using CarManagementApplication.Services;
using CarManagementApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace CarManagementApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            builder.Services.AddScoped<IGarageRepository, GarageRepository>();

            var app = builder.Build();

            app.UseErrorHandlerMiddleware();

            app.Run();
        }
    }
}
