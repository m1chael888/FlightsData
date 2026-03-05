using Microsoft.EntityFrameworkCore;
using FlightsData.Models;

namespace FlightsData.Data
{
    public class FlightsContext : DbContext
    {
        public FlightsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
    }
}