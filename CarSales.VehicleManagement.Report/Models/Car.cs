namespace CarSales.VehicleManagement.ReportGenerator.Models
{
    public class Car
    {
        public Car()
        {

        }

        public string VehicleType { get; set; }

        public int VehicleId { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int Doors { get; set; }

        public string BodyType { get; set; }
    }
}
