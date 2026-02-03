using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> AddCustomerAsync([FromBody] CustomerCreateRequest request)
        {
            var created = await _service.AddCustomerAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync()
        {
            return await _service.GetAllCustomersAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CustomerResponse?>> GetCustomerByIdAsync(long id)
        {
            var entity = await _service.GetCustomerByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateCustomerAsync(long id, [FromBody] CustomerUpdateRequest request)
        {
            var updated = await _service.UpdateCustomerAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CustomerResponse>> DeleteCustomerAsync(long id)
        {
            await _service.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
