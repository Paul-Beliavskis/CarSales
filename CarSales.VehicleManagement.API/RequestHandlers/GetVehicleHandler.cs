using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarSales.VehicleManagement.API.Constants;
using CarSales.VehicleManagement.API.DTO;
using CarSales.VehicleManagement.API.Exceptions;
using CarSales.VehicleManagement.API.HandlerRequests;
using CarSales.VehicleManagement.API.HandlerResponses;
using CarSales.VehicleManagement.DATA;
using MediatR;

namespace CarSales.VehicleManagement.API.RequestHandlers
{
    public class GetVehicleHandler : IRequestHandler<GetVehicleRequest, GetVehicleResponse>
    {
        private readonly CarSalesDbContext _carSalesDbContext;

        private readonly IMapper _mapper;

        public GetVehicleHandler(CarSalesDbContext carSalesDbContext, IMapper mapper)
        {
            _carSalesDbContext = carSalesDbContext;

            _mapper = mapper;
        }

        public Task<GetVehicleResponse> Handle(GetVehicleRequest request, CancellationToken cancellationToken)
        {

            var vehicleEntity = (from vehicle in _carSalesDbContext.Vehicles
                                 join car in _carSalesDbContext.Cars on vehicle.Id equals car.Id
                                 where vehicle.Id == car.VehicleId
                                 select _mapper.Map<CarDTO>(car)).FirstOrDefault() ?? throw new NotFoundException(string.Format(ErrorConstants.VehicleTypeDoesNotExistMessage, request.VehicleId));

            //var car = _carSalesDbContext.Cars.FirstOrDefault(x => x.VehicleId == request.VehicleId) ?? throw new NotFoundException(string.Format(ErrorConstants.VehicleTypeDoesNotExistMessage, request.VehicleId));
            return Task.FromResult(new GetVehicleResponse
            {
                VehicleEntity = vehicleEntity
            });
        }
    }
}
