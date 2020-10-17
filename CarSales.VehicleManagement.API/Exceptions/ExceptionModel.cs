using System.Collections.Generic;

namespace CarSales.VehicleManagement.API.Exceptions
{
    public class ExceptionModel
    {
        public List<string> Errors { get; set; } = new List<string>();
    }
}
