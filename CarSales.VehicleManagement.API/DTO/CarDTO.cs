namespace CarSales.VehicleManagement.API.DTO
{
    public class CarDTO : VehicleDTOBase
    {
        public CarDTO()
        {
            VehicleType = Domain.Enums.VehicleType.Car.ToString();
        }

        public int Doors { get; set; }
    }
}
