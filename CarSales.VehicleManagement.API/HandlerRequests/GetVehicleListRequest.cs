using CarSales.VehicleManagement.API.HandlerResponses;
using MediatR;

namespace CarSales.VehicleManagement.API.HandlerRequests
{
    public class GetVehicleListRequest : IRequest<GetVehicleListResponse>
    {
        public int PageSize { get; set; }

        public int Skip { get; set; }
    }
}
