using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateCartItemAsync(long id, [FromBody] CartItemUpdateRequest request)
        {
            var updated = await _service.UpdateCartItemAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CartItemResponse>> DeleteCartItemAsync(long id)
        {
            await _service.DeleteCartItemAsync(id);
            return Ok();
        }
    }
}
