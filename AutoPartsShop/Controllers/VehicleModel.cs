using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/vehiclemodels")]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _service;

        public VehicleModelController(IVehicleModelService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<VehicleModelResponse>> AddVehicleModelAsync([FromBody] VehicleModelCreateRequest request)
        {
            var created = await _service.AddVehicleModelAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleModelResponse>> GetAllVehicleModelsAsync()
        {
            return await _service.GetAllVehicleModelsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<VehicleModelResponse?>> GetVehicleModelByIdAsync(long id)
        {
            var entity = await _service.GetVehicleModelByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateVehicleModelAsync(long id, [FromBody] VehicleModelUpdateRequest request)
        {
            var updated = await _service.UpdateVehicleModelAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<VehicleModelResponse>> DeleteVehicleModelAsync(long id)
        {
            await _service.DeleteVehicleModelAsync(id);
            return Ok();
        }
    }
}
