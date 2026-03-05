using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightsData.Data
{
    public class FlightsContext(DbContextOptions options) : DbContext
    {

    }
}