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
using CarSales.VehicleManagement.Domain.Entities;
using CarSales.VehicleManagement.Domain.Enums;
using MediatR;

namespace CarSales.VehicleManagement.API.RequestHandlers
{
    public class PutVehicleHandler : IRequestHandler<PutVehicleRequest, PutVehicleResponse>
    {
        private readonly CarSalesDbContext _carSalesDbContext;

        private readonly IMapper _mapper;

        public PutVehicleHandler(CarSalesDbContext carSalesDbContext, IMapper mapper)
        {
            _carSalesDbContext = carSalesDbContext;

            _mapper = mapper;
        }

        public async Task<PutVehicleResponse> Handle(PutVehicleRequest request, CancellationToken cancellationToken)
        {
            ValidateBodyType(request.BodyType);

            if (request.Id.HasValue && request.Id > 0)
            {
                var car = _carSalesDbContext.Cars.FirstOrDefault(x => x.Vehicle.Id == request.Id) ?? throw new NotFoundException(ErrorConstants.VehicleTypeDoesNotExistMessage);

                _mapper.Map(request, car);

                await _carSalesDbContext.SaveChangesAsync(cancellationToken);

                return new PutVehicleResponse
                {
                    ResponseStatus = PutResponseStatus.Updated,
                    CarEntity = _mapper.Map<CarDTO>(car)
                };
            }

            var carEntityToAdd = _mapper.Map<Car>(request);

            var vehicle = _carSalesDbContext.Vehicles.AddAsync(new Vehicle()).Result.Entity;
            carEntityToAdd.Vehicle = vehicle;
            await _carSalesDbContext.Cars.AddAsync(carEntityToAdd, cancellationToken);
            await _carSalesDbContext.SaveChangesAsync(cancellationToken);

            return new PutVehicleResponse
            {
                ResponseStatus = PutResponseStatus.Created,
                CarEntity = _mapper.Map<CarDTO>(carEntityToAdd)
            };
        }

        private void ValidateBodyType(VehicleType vehicleType)
        {
            if (vehicleType != VehicleType.Car)
            {
                throw new BadRequestException(ErrorConstants.VehicleTypeDoesNotExistMessage);
            }
        }
    }
}
