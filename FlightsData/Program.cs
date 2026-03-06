
using FlightsData.Data;
using Microsoft.EntityFrameworkCore;
using FlightsData.Services;

namespace FlightsData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddControllers();

            builder.Services.AddDbContext<FlightsContext>(x => x.UseSqlite(builder.Configuration.GetConnectionString("ConnectionString")));
            builder.Services.AddScoped<IFlightsService, FlightsService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllers();
            app.Run();
        }
    }
}