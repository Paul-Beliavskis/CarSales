using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarSales.VehicleManagement.API.Exceptions;
using CarSales.VehicleManagement.API.HandlerRequests;
using CarSales.VehicleManagement.API.HandlerResponses;
using CarSales.VehicleManagement.DATA;
using CarSales.VehicleManagement.Domain.Enums;
using MediatR;

namespace CarSales.VehicleManagement.API.RequestHandlers
{
    public class GetVehicleHandler : IRequestHandler<GetVehicleRequest, GetVehicleResponse>
    {
        public readonly CarSalesDbContext _carSalesDbContext;

        public GetVehicleHandler(CarSalesDbContext carSalesDbContext)
        {
            _carSalesDbContext = carSalesDbContext;
        }

        public Task<GetVehicleResponse> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
        {
            switch (request.VehicleType)
            {
                case VehicleType.Car:
                    var car = _carSalesDbContext.Cars.FirstOrDefault(x => x.VehicleId == request.VehicleId) ?? throw new VehicleNotFoundException(request.VehicleId);
                    return Task.FromResult(new GetVehicleResponse
                    {
                        VehicleEntity = car
                    });
            }

            throw new InvalidVehicleTypeException();
        }
    }
}
