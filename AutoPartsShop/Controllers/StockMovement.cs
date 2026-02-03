using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/stockmovements")]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _service;

        public StockMovementController(IStockMovementService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<StockMovementResponse>> AddStockMovementAsync([FromBody] StockMovementCreateRequest request)
        {
            var created = await _service.AddStockMovementAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<StockMovementResponse>> GetAllStockMovementsAsync()
        {
            return await _service.GetAllStockMovementsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<StockMovementResponse?>> GetStockMovementByIdAsync(long id)
        {
            var entity = await _service.GetStockMovementByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateStockMovementAsync(long id, [FromBody] StockMovementUpdateRequest request)
        {
            var updated = await _service.UpdateStockMovementAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<StockMovementResponse>> DeleteStockMovementAsync(long id)
        {
            await _service.DeleteStockMovementAsync(id);
            return Ok();
        }
    }
}
