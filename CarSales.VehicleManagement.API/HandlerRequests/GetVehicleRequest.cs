using CarSales.VehicleManagement.API.HandlerResponses;
using CarSales.VehicleManagement.Domain.Enums;
using MediatR;

namespace CarSales.VehicleManagement.API.HandlerRequests
{
    public class GetVehicleRequest : IRequest<GetVehicleResponse>
    {
        public int? VehicleId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
