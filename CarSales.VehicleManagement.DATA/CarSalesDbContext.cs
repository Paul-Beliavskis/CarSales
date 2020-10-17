using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarSales.VehicleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarSales.VehicleManagement.DATA
{
    public class CarSalesDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Car> Cars { get; set; }

        public CarSalesDbContext(DbContextOptions options) : base(options)
        {

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entitieNum = await base.SaveChangesAsync();

            //Now let's detach all entities because the context is singleton for this MVP
            var changedEntriesCopy = ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }

            return entitieNum;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasOne(x => x.Vehicle).WithOne().HasForeignKey<Car>(x => x.VehicleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
