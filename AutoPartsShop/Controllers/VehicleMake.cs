using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/vehiclemakes")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _service;

        public VehicleMakeController(IVehicleMakeService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<VehicleMakeResponse>> AddVehicleMakeAsync([FromBody] VehicleMakeCreateRequest request)
        {
            var created = await _service.AddVehicleMakeAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleMakeResponse>> GetAllVehicleMakesAsync()
        {
            return await _service.GetAllVehicleMakesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<VehicleMakeResponse?>> GetVehicleMakeByIdAsync(long id)
        {
            var entity = await _service.GetVehicleMakeByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateVehicleMakeAsync(long id, [FromBody] VehicleMakeUpdateRequest request)
        {
            var updated = await _service.UpdateVehicleMakeAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<VehicleMakeResponse>> DeleteVehicleMakeAsync(long id)
        {
            await _service.DeleteVehicleMakeAsync(id);
            return Ok();
        }
    }
}
