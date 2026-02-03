using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/carts")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CartResponse>> AddCartAsync([FromBody] CartCreateRequest request)
        {
            var created = await _service.AddCartAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<CartResponse>> GetAllCartsAsync()
        {
            return await _service.GetAllCartsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CartResponse?>> GetCartByIdAsync(long id)
        {
            var entity = await _service.GetCartByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateCartAsync(long id, [FromBody] CartUpdateRequest request)
        {
            var updated = await _service.UpdateCartAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CartResponse>> DeleteCartAsync(long id)
        {
            await _service.DeleteCartAsync(id);
            return Ok();
        }
    }
}
