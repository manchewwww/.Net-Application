using AutoPartsShop.Services;
using AutoPartsShop.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CountryResponse>> CreateCountryAsync([FromBody] CountryCreateRequest country)
        {
            var created = await _countryService.CreateCountryAsync(country);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        async public Task<IEnumerable<CountryResponse>> GetAllCountriesAsync()
        {
            return await _countryService.GetAllCountriesAsync();
        }

        [HttpGet("{id:long}")]
        async public Task<ActionResult<CountryResponse?>> GetCountryByIdAsync(long id)
        {
            var countryEntity = await _countryService.GetCountryByIdAsync(id);
            return Ok(countryEntity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        async public Task<ActionResult> UpdateCountryAsync(long id, [FromBody] CountryUpdateRequest country)
        {
            var updated = await _countryService.UpdateCountryAsync(id, country);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        async public Task<ActionResult<CountryResponse>> DeleteCountryAsync(long id)
        {
            await _countryService.DeleteCountryAsync(id);
            return Ok();
        }
    }
}
