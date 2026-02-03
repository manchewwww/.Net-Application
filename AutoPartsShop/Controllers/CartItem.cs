using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/cartitems")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _service;

        public CartItemController(ICartItemService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CartItemResponse>> AddCartItemAsync([FromBody] CartItemCreateRequest request)
        {
            var created = await _service.AddCartItemAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<CartItemResponse>> GetAllCartItemsAsync()
        {
            return await _service.GetAllCartItemsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CartItemResponse?>> GetCartItemByIdAsync(long id)
        {
            var entity = await _service.GetCartItemByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateCartItemAsync(long id, [FromBody] CartItemUpdateRequest request)
        {
            var updated = await _service.UpdateCartItemAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CartItemResponse>> DeleteCartItemAsync(long id)
        {
            await _service.DeleteCartItemAsync(id);
            return Ok();
        }
    }
}
