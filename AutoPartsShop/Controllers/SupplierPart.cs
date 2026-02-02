using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/supplierparts")]
    public class SupplierPartController : ControllerBase
    {
        private readonly ISupplierPartService _service;

        public SupplierPartController(ISupplierPartService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierPartResponse>> AddSupplierPartAsync([FromBody] SupplierPartCreateRequest request)
        {
            var created = await _service.AddSupplierPartAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierPartResponse>> GetAllSupplierPartsAsync()
        {
            return await _service.GetAllSupplierPartsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SupplierPartResponse?>> GetSupplierPartByIdAsync(long id)
        {
            var entity = await _service.GetSupplierPartByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateSupplierPartAsync(long id, [FromBody] SupplierPartUpdateRequest request)
        {
            var updated = await _service.UpdateSupplierPartAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<SupplierPartResponse>> DeleteSupplierPartAsync(long id)
        {
            await _service.DeleteSupplierPartAsync(id);
            return Ok();
        }
    }
}
