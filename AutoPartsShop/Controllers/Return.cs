using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/returns")]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _service;

        public ReturnController(IReturnService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnResponse>> AddReturnAsync([FromBody] ReturnCreateRequest request)
        {
            var created = await _service.AddReturnAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<ReturnResponse>> GetAllReturnsAsync()
        {
            return await _service.GetAllReturnsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ReturnResponse?>> GetReturnByIdAsync(long id)
        {
            var entity = await _service.GetReturnByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateReturnAsync(long id, [FromBody] ReturnUpdateRequest request)
        {
            var updated = await _service.UpdateReturnAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ReturnResponse>> DeleteReturnAsync(long id)
        {
            await _service.DeleteReturnAsync(id);
            return Ok();
        }
    }
}
