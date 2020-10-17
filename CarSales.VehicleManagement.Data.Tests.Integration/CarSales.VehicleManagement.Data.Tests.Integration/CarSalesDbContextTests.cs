using System;
using System.Threading.Tasks;
using CarSales.VehicleManagement.Data.Tests.Integration.Constants;
using CarSales.VehicleManagement.DATA;
using CarSales.VehicleManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CarSales.VehicleManagement.Data.Tests.Integration
{
    public class CarSalesDbContextTests
    {
        private readonly CarSalesDbContext _carSalesDbContext;

        public CarSalesDbContextTests()
        {
            ////Have a separate database for each test to avoid poisoning of tests
            var databaseName = TestConstants.TestDBName + Guid.NewGuid();

            var dbConfigOptions = new DbContextOptionsBuilder()
                                        .UseInMemoryDatabase(databaseName);

            _carSalesDbContext = new CarSalesDbContext(dbConfigOptions.Options);
        }

        [Fact]
        public async Task AddAsync_IsCarAddedSuccessfully_CarAddedSuccessfullyAsync()
        {
            //Arrange
            var testCarId = 1;

            var car = new Car
            {
                Id = testCarId,
                Doors = 4,
                BodyType = "Hatch back",
                Make = "Ferrari S.p.A.",
                Model = "Ferrari 488",
                Price = 596888
            };

            await _carSalesDbContext.Cars.AddAsync(car);
            await _carSalesDbContext.SaveChangesAsync();

            var retrievedCar = _carSalesDbContext.Cars.Find(testCarId);

            Assert.NotNull(retrievedCar);
            Assert.Equal(testCarId, retrievedCar.Id);
        }
    }
}
