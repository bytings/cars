using cars.Models;
using Microsoft.EntityFrameworkCore;

namespace cars.Data
{
    public class CarsDbContext : DbContext
    {        
        public CarsDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Cars> Cars { get; set; }
    }
}
