using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/partsupplierlinks")]
    public class PartSupplierLinkController : ControllerBase
    {
        private readonly IPartSupplierLinkService _service;

        public PartSupplierLinkController(IPartSupplierLinkService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<PartSupplierLinkResponse>> AddPartSupplierLinkAsync([FromBody] PartSupplierLinkCreateRequest request)
        {
            var created = await _service.AddPartSupplierLinkAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartSupplierLinkResponse>> GetAllPartSupplierLinksAsync()
        {
            return await _service.GetAllPartSupplierLinksAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartSupplierLinkResponse?>> GetPartSupplierLinkByIdAsync(long id)
        {
            var entity = await _service.GetPartSupplierLinkByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartSupplierLinkAsync(long id, [FromBody] PartSupplierLinkUpdateRequest request)
        {
            var updated = await _service.UpdatePartSupplierLinkAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartSupplierLinkResponse>> DeletePartSupplierLinkAsync(long id)
        {
            await _service.DeletePartSupplierLinkAsync(id);
            return Ok();
        }
    }
}
