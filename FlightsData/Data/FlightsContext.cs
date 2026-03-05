using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightsData.Data
{
    public class FlightsContext(DbContextOptions options) : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = builder.GetConnectionString("ConnectionString");

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}