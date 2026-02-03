using System.Security.Claims;
using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/me/cart")]
    public class CartSessionController : ControllerBase
    {
        private readonly ICartSessionService _cartService;

        public CartSessionController(ICartSessionService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<CartSessionResponse>> GetCartAsync()
        {
            var customerId = GetCustomerId();
            var response = await _cartService.GetCartAsync(customerId);
            return Ok(response);
        }

        [HttpPost("items")]
        public async Task<ActionResult<CartSessionResponse>> UpsertItemAsync([FromBody] CartItemUpsertRequest request)
        {
            var customerId = GetCustomerId();
            var response = await _cartService.UpsertItemAsync(customerId, request);
            return Ok(response);
        }

        [HttpDelete("items/{partId:long}")]
        public async Task<ActionResult<CartSessionResponse>> RemoveItemAsync(long partId)
        {
            var customerId = GetCustomerId();
            var response = await _cartService.RemoveItemAsync(customerId, partId);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<CartSessionResponse>> ClearCartAsync()
        {
            var customerId = GetCustomerId();
            var response = await _cartService.ClearCartAsync(customerId);
            return Ok(response);
        }

        private long GetCustomerId()
        {
            var raw = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return long.Parse(raw ?? "0");
        }
    }
}
