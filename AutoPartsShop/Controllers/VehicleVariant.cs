using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/vehiclevariants")]
    public class VehicleVariantController : ControllerBase
    {
        private readonly IVehicleVariantService _service;

        public VehicleVariantController(IVehicleVariantService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleVariantResponse>> AddVehicleVariantAsync([FromBody] VehicleVariantCreateRequest request)
        {
            var created = await _service.AddVehicleVariantAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleVariantResponse>> GetAllVehicleVariantsAsync()
        {
            return await _service.GetAllVehicleVariantsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<VehicleVariantResponse?>> GetVehicleVariantByIdAsync(long id)
        {
            var entity = await _service.GetVehicleVariantByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateVehicleVariantAsync(long id, [FromBody] VehicleVariantUpdateRequest request)
        {
            var updated = await _service.UpdateVehicleVariantAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<VehicleVariantResponse>> DeleteVehicleVariantAsync(long id)
        {
            await _service.DeleteVehicleVariantAsync(id);
            return Ok();
        }
    }
}
