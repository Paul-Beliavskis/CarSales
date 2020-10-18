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
using CarSales.VehicleManagement.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarSales.VehicleManagement.API.RequestHandlers
{
    public class GetVehicleListHandler : IRequestHandler<GetVehicleListRequest, GetVehicleListResponse>
    {
        private CarSalesDbContext _carSalesDbContext;

        private IMapper _mapper;

        public GetVehicleListHandler(CarSalesDbContext carSalesDbContext, IMapper mapper)
        {
            _carSalesDbContext = carSalesDbContext;

            _mapper = mapper;
        }

        public async Task<GetVehicleListResponse> Handle(GetVehicleListRequest request, CancellationToken cancellationToken)
        {
            if (request.PageSize > AppConstants.MaxPageSize || request.PageSize < AppConstants.MinPageSize)
            {
                //Passing the page size here because this exception can be reused by different parts of the app where page size may differ
                throw new BadRequestException(string.Format(ErrorConstants.PageSizeInvalidMessage, request.PageSize));
            }
            if (request.Skip < 0)
            {
                throw new BadRequestException(string.Format(ErrorConstants.SkipNumberInvalidMessage, request.Skip));
            }

            var skipRecords = request.Skip * request.PageSize;

            var getListQuery = (from vehicle in _carSalesDbContext.Vehicles
                                join car in _carSalesDbContext.Cars on vehicle.Id equals car.VehicleId
                                select SelectVehicle(car, _mapper)).Skip(skipRecords).Take(request.PageSize);

            //We are limiting how much data can be returned so it is okay to load data into memory to perform the vehicle type check
            var vehicleList = getListQuery.AsAsyncEnumerable();
            var response = new GetVehicleListResponse();

            await foreach (var vehicle in vehicleList)
            {
                response.VehicleList.Add(vehicle);
            }

            return response;
        }

        private static object SelectVehicle(dynamic vehicle, IMapper mapper)
        {
            switch (vehicle.VehicleType)
            {
                case VehicleType.Car:
                    return mapper.Map<CarDTO>(vehicle);
            }

            return null;
        }
    }
}
