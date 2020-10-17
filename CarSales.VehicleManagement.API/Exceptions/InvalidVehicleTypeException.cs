using System;

namespace CarSales.VehicleManagement.API.Exceptions
{
    public class InvalidVehicleTypeException : Exception
    {
        public InvalidVehicleTypeException() : base("The vehicle type does not exist")
        {

        }
    }
}
