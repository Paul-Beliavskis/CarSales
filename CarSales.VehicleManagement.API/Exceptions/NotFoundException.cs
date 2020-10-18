using System;
using System.Collections.Generic;

namespace CarSales.VehicleManagement.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public List<string> Errors { get; set; } = new List<string>();

        public NotFoundException(string errorMsg) : base(errorMsg)
        {
            Errors.Add(errorMsg);
        }
    }
}
