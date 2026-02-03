using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/partattributes")]
    public class PartAttributeController : ControllerBase
    {
        private readonly IPartAttributeService _service;

        public PartAttributeController(IPartAttributeService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PartAttributeResponse>> AddPartAttributeAsync([FromBody] PartAttributeCreateRequest request)
        {
            var created = await _service.AddPartAttributeAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartAttributeResponse>> GetAllPartAttributesAsync()
        {
            return await _service.GetAllPartAttributesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartAttributeResponse?>> GetPartAttributeByIdAsync(long id)
        {
            var entity = await _service.GetPartAttributeByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartAttributeAsync(long id, [FromBody] PartAttributeUpdateRequest request)
        {
            var updated = await _service.UpdatePartAttributeAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartAttributeResponse>> DeletePartAttributeAsync(long id)
        {
            await _service.DeletePartAttributeAsync(id);
            return Ok();
        }
    }
}
