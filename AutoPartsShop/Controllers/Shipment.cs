using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/shipments")]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _service;

        public ShipmentController(IShipmentService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ShipmentResponse>> AddShipmentAsync([FromBody] ShipmentCreateRequest request)
        {
            var created = await _service.AddShipmentAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<ShipmentResponse>> GetAllShipmentsAsync()
        {
            return await _service.GetAllShipmentsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ShipmentResponse?>> GetShipmentByIdAsync(long id)
        {
            var entity = await _service.GetShipmentByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateShipmentAsync(long id, [FromBody] ShipmentUpdateRequest request)
        {
            var updated = await _service.UpdateShipmentAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ShipmentResponse>> DeleteShipmentAsync(long id)
        {
            await _service.DeleteShipmentAsync(id);
            return Ok();
        }
    }
}
