using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<AddressResponse>> AddAddressAsync([FromBody] AddressCreateRequest request)
        {
            var created = await _service.AddAddressAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<AddressResponse>> GetAllAddressesAsync()
        {
            return await _service.GetAllAddressesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<AddressResponse?>> GetAddressByIdAsync(long id)
        {
            var entity = await _service.GetAddressByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateAddressAsync(long id, [FromBody] AddressUpdateRequest request)
        {
            var updated = await _service.UpdateAddressAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<AddressResponse>> DeleteAddressAsync(long id)
        {
            await _service.DeleteAddressAsync(id);
            return Ok();
        }
    }
}
