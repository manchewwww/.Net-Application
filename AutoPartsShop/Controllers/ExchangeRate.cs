using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/exchangerates")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly IExchangeRateService _service;

        public ExchangeRateController(IExchangeRateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ExchangeRateResponse>> AddExchangeRateAsync([FromBody] ExchangeRateCreateRequest request)
        {
            var created = await _service.AddExchangeRateAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<ExchangeRateResponse>> GetAllExchangeRatesAsync()
        {
            return await _service.GetAllExchangeRatesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ExchangeRateResponse?>> GetExchangeRateByIdAsync(long id)
        {
            var entity = await _service.GetExchangeRateByIdAsync(id);
            return Ok(entity);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateExchangeRateAsync(long id, [FromBody] ExchangeRateUpdateRequest request)
        {
            var updated = await _service.UpdateExchangeRateAsync(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ExchangeRateResponse>> DeleteExchangeRateAsync(long id)
        {
            await _service.DeleteExchangeRateAsync(id);
            return Ok();
        }
    }
}
