using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarSales.VehicleManagement.API.Constants;
using CarSales.VehicleManagement.API.Exceptions;
using CarSales.VehicleManagement.API.HandlerRequests;
using CarSales.VehicleManagement.DATA;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarSales.VehicleManagement.API.RequestHandlers
{
    public class DeleteVehicleHandler : IRequestHandler<DeleteVehicleRequest, bool>
    {
        private readonly CarSalesDbContext _carSalesDbContext;

        private readonly IMapper _mapper;

        public DeleteVehicleHandler(CarSalesDbContext carSalesDbContext, IMapper mapper)
        {
            _carSalesDbContext = carSalesDbContext;

            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteVehicleRequest request, CancellationToken cancellationToken)
        {
            var vehicle = _carSalesDbContext.Vehicles.AsNoTracking().FirstOrDefault(x => x.Id == request.VehicleId)
            ?? throw new NotFoundException(string.Format(ErrorConstants.VehicleNotFoundException, request.VehicleId));

            _carSalesDbContext.Vehicles.Remove(vehicle);
            await _carSalesDbContext.SaveChangesAsync();

            return true;
        }
    }
}
