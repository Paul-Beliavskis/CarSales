namespace CarSales.VehicleManagement.API.DTO
{
    public class CarDTO : VehicleDTOBase
    {
        public CarDTO()
        {
            VehicleType = Domain.Enums.VehicleType.Car;
        }

        public int Doors { get; set; }

        public string BodyType { get; set; }
    }
}
