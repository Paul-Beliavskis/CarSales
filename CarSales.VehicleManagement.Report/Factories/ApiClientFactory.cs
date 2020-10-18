using RestSharp;

namespace CarSales.VehicleManagement.ReportGenerator.Factories
{
    public static class ApiClientFactory
    {
        public static RestClient Create()
        {
            return new RestClient("https://localhost:44386");
        }
    }
}
