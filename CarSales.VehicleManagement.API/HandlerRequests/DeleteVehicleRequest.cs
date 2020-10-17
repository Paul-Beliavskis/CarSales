using MediatR;

namespace CarSales.VehicleManagement.API.HandlerRequests
{
    public class DeleteVehicleRequest : IRequest<bool>
    {
        public int VehicleId { get; set; }
    }
}
