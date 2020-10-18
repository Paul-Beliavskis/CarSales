using CarSales.VehicleManagement.API.HandlerResponses;
using MediatR;

namespace CarSales.VehicleManagement.API.HandlerRequests
{
    public class GetVehicleRequest : IRequest<GetVehicleResponse>
    {
        public int? VehicleId { get; set; }
    }
}
