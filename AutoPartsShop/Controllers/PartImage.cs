using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/partimages")]
    public class PartImageController : ControllerBase
    {
        private readonly IPartImageService _service;

        public PartImageController(IPartImageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<PartImageResponse>> AddPartImageAsync([FromBody] PartImageCreateRequest request)
        {
            var created = await _service.AddPartImageAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartImageResponse>> GetAllPartImagesAsync()
        {
            return await _service.GetAllPartImagesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartImageResponse?>> GetPartImageByIdAsync(long id)
        {
            var entity = await _service.GetPartImageByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartImageAsync(long id, [FromBody] PartImageUpdateRequest request)
        {
            var updated = await _service.UpdatePartImageAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartImageResponse>> DeletePartImageAsync(long id)
        {
            await _service.DeletePartImageAsync(id);
            return Ok();
        }
    }
}
