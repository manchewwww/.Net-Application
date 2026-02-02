using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyResponse>> AddCurrencyAsync([FromBody] CurrencyCreateRequest currency)
        {
            var created = await _currencyService.AddCurrencyAsync(currency);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }


        [HttpGet]
        async public Task<IEnumerable<CurrencyResponse>> GetAllCurrenciesAsync()
        {
            return await _currencyService.GetAllCurrenciesAsync();
        }

        [HttpGet("{id:long}")]
        async public Task<ActionResult<CurrencyResponse?>> GetCurrencyByIdAsync(long id)
        {
            var currencyEntity = await _currencyService.GetCurrencyByIdAsync(id);
            return Ok(currencyEntity);
        }

        [HttpPut("{id:long}")]
        async public Task<ActionResult> UpdateCurrencyAsync(long id, [FromBody] CurrencyUpdateRequest currency)
        {
            var updated = await _currencyService.UpdateCurrencyAsync(id, currency);
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        async public Task<ActionResult<CurrencyResponse>> DeleteCurrencyAsync(long id)
        {
            await _currencyService.DeleteCurrencyAsync(id);
            return Ok();
        }
    }
}