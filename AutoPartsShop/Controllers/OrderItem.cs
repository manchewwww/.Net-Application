using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/orderitems")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemController(IOrderItemService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<OrderItemResponse>> AddOrderItemAsync([FromBody] OrderItemCreateRequest request)
        {
            var created = await _service.AddOrderItemAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItemResponse>> GetAllOrderItemsAsync()
        {
            return await _service.GetAllOrderItemsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<OrderItemResponse?>> GetOrderItemByIdAsync(long id)
        {
            var entity = await _service.GetOrderItemByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateOrderItemAsync(long id, [FromBody] OrderItemUpdateRequest request)
        {
            var updated = await _service.UpdateOrderItemAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<OrderItemResponse>> DeleteOrderItemAsync(long id)
        {
            await _service.DeleteOrderItemAsync(id);
            return Ok();
        }
    }
}
