using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/pricelists")]
    public class PriceListController : ControllerBase
    {
        private readonly IPriceListService _service;

        public PriceListController(IPriceListService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<PriceListResponse>> AddPriceListAsync([FromBody] PriceListCreateRequest request)
        {
            var created = await _service.AddPriceListAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<PriceListResponse>> GetAllPriceListsAsync()
        {
            return await _service.GetAllPriceListsAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PriceListResponse?>> GetPriceListByIdAsync(long id)
        {
            var entity = await _service.GetPriceListByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdatePriceListAsync(long id, [FromBody] PriceListUpdateRequest request)
        {
            var updated = await _service.UpdatePriceListAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PriceListResponse>> DeletePriceListAsync(long id)
        {
            await _service.DeletePriceListAsync(id);
            return Ok();
        }
    }
}
