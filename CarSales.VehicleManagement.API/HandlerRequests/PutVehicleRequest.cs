using CarSales.VehicleManagement.API.HandlerResponses;
using CarSales.VehicleManagement.Domain.Enums;
using MediatR;

namespace CarSales.VehicleManagement.API.HandlerRequests
{
    public class PutVehicleRequest : IRequest<PutVehicleResponse>
    {
        public int? Id { get; set; }

        public int Doors { get; set; }

        public VehicleType BodyType { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }
    }
}
