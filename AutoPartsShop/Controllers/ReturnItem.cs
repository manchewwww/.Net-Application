using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/returnitems")]
    public class ReturnItemController : ControllerBase
    {
        private readonly IReturnItemService _service;

        public ReturnItemController(IReturnItemService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnItemResponse>> AddReturnItemAsync([FromBody] ReturnItemCreateRequest request)
        {
            var created = await _service.AddReturnItemAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<ReturnItemResponse>> GetAllReturnItemsAsync()
        {
            return await _service.GetAllReturnItemsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ReturnItemResponse?>> GetReturnItemByIdAsync(long id)
        {
            var entity = await _service.GetReturnItemByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateReturnItemAsync(long id, [FromBody] ReturnItemUpdateRequest request)
        {
            var updated = await _service.UpdateReturnItemAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ReturnItemResponse>> DeleteReturnItemAsync(long id)
        {
            await _service.DeleteReturnItemAsync(id);
            return Ok();
        }
    }
}
