namespace CarSales.VehicleManagement.API.Constants
{
    public static class ErrorConstants
    {
        public const string SkipNumberInvalidMessage = "The skip number: {0} is invalid. Skip must be greater than or equal to 0";

        public const string PageSizeInvalidMessage = "The page size {0} is invalid, must be between 1 and 20";

        public const string VehicleTypeDoesNotExistMessage = "The vehicle type does not exist";

        public const string VehicleNotFoundException = "Vehicle with id {0} not found";
    }
}
