using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/inventories")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<InventoryResponse>> AddInventoryAsync([FromBody] InventoryCreateRequest request)
        {
            var created = await _service.AddInventoryAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<InventoryResponse>> GetAllInventoriesAsync()
        {
            return await _service.GetAllInventoriesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<InventoryResponse?>> GetInventoryByIdAsync(long id)
        {
            var entity = await _service.GetInventoryByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateInventoryAsync(long id, [FromBody] InventoryUpdateRequest request)
        {
            var updated = await _service.UpdateInventoryAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<InventoryResponse>> DeleteInventoryAsync(long id)
        {
            await _service.DeleteInventoryAsync(id);
            return Ok();
        }
    }
}
