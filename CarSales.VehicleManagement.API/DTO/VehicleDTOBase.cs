using CarSales.VehicleManagement.Domain.Enums;

namespace CarSales.VehicleManagement.API.DTO
{
    public class VehicleDTOBase
    {
        public int VehicleId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        //This is protected because only concrete classes should set this
        protected VehicleType VehicleType { get; set; }

        public double Price { get; set; }
    }
}