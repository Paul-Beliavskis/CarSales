namespace CarSales.VehicleManagement.Domain.Entities
{
    public class Car : VehicleBase
    {
        public Car()
        {
            VehicleType = Enums.VehicleType.Car;
        }

        public int Doors { get; set; }

        public string BodyType { get; set; }
    }
}
