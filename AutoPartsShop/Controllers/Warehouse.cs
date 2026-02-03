using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _service;

        public WarehouseController(IWarehouseService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<WarehouseResponse>> AddWarehouseAsync([FromBody] WarehouseCreateRequest request)
        {
            var created = await _service.AddWarehouseAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<WarehouseResponse>> GetAllWarehousesAsync()
        {
            return await _service.GetAllWarehousesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<WarehouseResponse?>> GetWarehouseByIdAsync(long id)
        {
            var entity = await _service.GetWarehouseByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateWarehouseAsync(long id, [FromBody] WarehouseUpdateRequest request)
        {
            var updated = await _service.UpdateWarehouseAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<WarehouseResponse>> DeleteWarehouseAsync(long id)
        {
            await _service.DeleteWarehouseAsync(id);
            return Ok();
        }
    }
}
