using System;
using System.Collections.Generic;

namespace CarSales.VehicleManagement.API.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> Errors { get; set; } = new List<string>();

        public BadRequestException(string message) : base(message)
        {
            Errors.Add(message);
        }

        public BadRequestException(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
        }
    }
}
