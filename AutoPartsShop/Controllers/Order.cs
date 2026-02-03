using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> AddOrderAsync([FromBody] OrderCreateRequest request)
        {
            var created = await _service.AddOrderAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            return await _service.GetAllOrdersAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<OrderResponse?>> GetOrderByIdAsync(long id)
        {
            var entity = await _service.GetOrderByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateOrderAsync(long id, [FromBody] OrderUpdateRequest request)
        {
            var updated = await _service.UpdateOrderAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<OrderResponse>> DeleteOrderAsync(long id)
        {
            await _service.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
