using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/supplierpartnumbers")]
    public class SupplierPartNumberController : ControllerBase
    {
        private readonly ISupplierPartNumberService _service;

        public SupplierPartNumberController(ISupplierPartNumberService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierPartNumberResponse>> AddSupplierPartNumberAsync([FromBody] SupplierPartNumberCreateRequest request)
        {
            var created = await _service.AddSupplierPartNumberAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierPartNumberResponse>> GetAllSupplierPartNumbersAsync()
        {
            return await _service.GetAllSupplierPartNumbersAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SupplierPartNumberResponse?>> GetSupplierPartNumberByIdAsync(long id)
        {
            var entity = await _service.GetSupplierPartNumberByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateSupplierPartNumberAsync(long id, [FromBody] SupplierPartNumberUpdateRequest request)
        {
            var updated = await _service.UpdateSupplierPartNumberAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<SupplierPartNumberResponse>> DeleteSupplierPartNumberAsync(long id)
        {
            await _service.DeleteSupplierPartNumberAsync(id);
            return Ok();
        }
    }
}
