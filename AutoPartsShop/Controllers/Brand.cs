using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<BrandResponse>> AddBrandAsync([FromBody] BrandCreateRequest brand)
        {
            var created = await _brandService.AddBrandAsync(brand);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        async public Task<IEnumerable<BrandResponse>> GetAllBrandsAsync()
        {
            return await _brandService.GetAllBrandsAsync();
        }

        [HttpGet("{id:long}")]
        async public Task<ActionResult<BrandResponse?>> GetBrandByIdAsync(long id)
        {
            var brandEntity = await _brandService.GetBrandByIdAsync(id);
            return Ok(brandEntity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        async public Task<ActionResult> UpdateBrandAsync(long id, [FromBody] BrandUpdateRequest brand)
        {
            var updated = await _brandService.UpdateBrandAsync(id, brand);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        async public Task<ActionResult<BrandResponse>> DeleteBrandAsync(long id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok();
        }
    }
}
