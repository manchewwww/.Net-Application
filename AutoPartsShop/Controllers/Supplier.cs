using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/suppliers")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<SupplierResponse>> AddSupplierAsync([FromBody] SupplierCreateRequest request)
        {
            var created = await _service.AddSupplierAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync()
        {
            return await _service.GetAllSuppliersAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<SupplierResponse?>> GetSupplierByIdAsync(long id)
        {
            var entity = await _service.GetSupplierByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateSupplierAsync(long id, [FromBody] SupplierUpdateRequest request)
        {
            var updated = await _service.UpdateSupplierAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<SupplierResponse>> DeleteSupplierAsync(long id)
        {
            await _service.DeleteSupplierAsync(id);
            return Ok();
        }
    }
}
