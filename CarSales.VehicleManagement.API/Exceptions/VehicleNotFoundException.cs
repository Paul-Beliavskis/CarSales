using System;

namespace CarSales.VehicleManagement.API.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(int? vehicleId) : base($"Vehicle with Id {vehicleId} was not found")
        {

        }
    }
}
