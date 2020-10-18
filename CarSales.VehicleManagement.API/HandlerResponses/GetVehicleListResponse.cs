using System.Collections.Generic;

namespace CarSales.VehicleManagement.API.HandlerResponses
{
    public class GetVehicleListResponse
    {
        public List<object> VehicleList { get; set; } = new List<object>();
    }
}
