using CarSales.VehicleManagement.Domain.Enums;

namespace CarSales.VehicleManagement.Domain.Entities
{
    public abstract class VehicleBase
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        //This is protected because only concrete classes should set this
        protected VehicleType VehicleType { get; set; }

        public double Price { get; set; }
    }
}
