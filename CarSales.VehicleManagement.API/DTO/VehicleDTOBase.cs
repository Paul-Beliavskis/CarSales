namespace CarSales.VehicleManagement.API.DTO
{
    public abstract class VehicleDTOBase
    {
        public int VehicleId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string VehicleType { get; set; }

        public double Price { get; set; }
    }
}