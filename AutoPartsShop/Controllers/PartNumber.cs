using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/partnumbers")]
    public class PartNumberController : ControllerBase
    {
        private readonly IPartNumberService _service;

        public PartNumberController(IPartNumberService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<PartNumberResponse>> AddPartNumberAsync([FromBody] PartNumberCreateRequest request)
        {
            var created = await _service.AddPartNumberAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PartNumberResponse>> GetAllPartNumbersAsync()
        {
            return await _service.GetAllPartNumbersAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PartNumberResponse?>> GetPartNumberByIdAsync(long id)
        {
            var entity = await _service.GetPartNumberByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePartNumberAsync(long id, [FromBody] PartNumberUpdateRequest request)
        {
            var updated = await _service.UpdatePartNumberAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PartNumberResponse>> DeletePartNumberAsync(long id)
        {
            await _service.DeletePartNumberAsync(id);
            return Ok();
        }
    }
}
