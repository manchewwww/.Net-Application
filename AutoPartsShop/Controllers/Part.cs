using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/parts")]
    public class PartController : ControllerBase
    {
        private readonly IPartService _service;

        public PartController(IPartService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<PartResponse>> AddPartAsync([FromBody] PartCreateRequest request)
        {
            var created = await _service.AddPartAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartResponse>> GetAllPartsAsync()
        {
            return await _service.GetAllPartsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartResponse?>> GetPartByIdAsync(long id)
        {
            var entity = await _service.GetPartByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartAsync(long id, [FromBody] PartUpdateRequest request)
        {
            var updated = await _service.UpdatePartAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartResponse>> DeletePartAsync(long id)
        {
            await _service.DeletePartAsync(id);
            return Ok();
        }
    }
}
