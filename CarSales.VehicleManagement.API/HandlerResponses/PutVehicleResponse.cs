using CarSales.VehicleManagement.API.DTO;

namespace CarSales.VehicleManagement.API.HandlerResponses
{
    public class PutVehicleResponse
    {
        public PutResponseStatus ResponseStatus { get; set; }

        public CarDTO CarEntity { get; set; }
    }
}
