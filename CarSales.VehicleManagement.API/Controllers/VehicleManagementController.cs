using System.Threading;
using System.Threading.Tasks;
using CarSales.VehicleManagement.API.HandlerRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.VehicleManagement.API.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleManagementController : ControllerBase
    {
        private const string GetVehicleRoute = "";

        private readonly IMediator _mediator;

        public VehicleManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<ActionResult> CreateOrUpdateVehicle(PutVehicleRequest putVehicleRequest, CancellationToken cancelationToken = default)
        {
            var response = await _mediator.Send(putVehicleRequest, cancelationToken);

            if (response.ResponseStatus == PutResponseStatus.Created)
            {
                return CreatedAtRoute(
                    GetVehicleRoute,
                    new { response.CarEntity.VehicleId },
                        response.CarEntity);
            }

            return Ok(response.CarEntity);
        }

        [HttpGet]
        [Route("{VehicleId}")]
        public async Task<ActionResult> GetVehicle([FromRoute] GetVehicleRequest getVehicleRequest, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(getVehicleRequest, cancellationToken);

            //If we got here without exceptions then we know it's all good to return the response
            return Ok(response.VehicleEntity);
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> GetVehicleList([FromQuery] GetVehicleListRequest getVehicleListRequest, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(getVehicleListRequest, cancellationToken);

            //If we got here without exceptions then we know it's all good to return the response
            return Ok(response.VehicleList);
        }

        [HttpDelete]
        [Route("{VehicleId}")]
        public async Task<ActionResult> DeleteVehicle([FromRoute] DeleteVehicleRequest deleteVehicleRequest, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(deleteVehicleRequest, cancellationToken);

            return Ok();
        }
    }
}
