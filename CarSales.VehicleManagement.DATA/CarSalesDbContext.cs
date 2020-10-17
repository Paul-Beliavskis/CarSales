using CarSales.VehicleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarSales.VehicleManagement.DATA
{
    public class CarSalesDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarSalesDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
