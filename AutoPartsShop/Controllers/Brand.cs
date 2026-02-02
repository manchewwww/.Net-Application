using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

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

        [HttpGet("{id:int}")]
        async public Task<ActionResult<BrandResponse?>> GetBrandByIdAsync(int id)
        {
            var brandEntity = await _brandService.GetBrandByIdAsync(id);
            return brandEntity == null ? NotFound() : Ok(brandEntity);
        }

        [HttpPut("{id:int}")]
        async public Task<ActionResult> UpdateBrandAsync(int id, [FromBody] BrandUpdateRequest brand)
        {
            if (brand.Id != 0 && brand.Id != id)
            {
                return BadRequest("ID mismatch.");
            }
            var existing = await _brandService.GetBrandByIdAsync(id);
            if (existing is null)
            {
                return NotFound();
            }

            var updated = await _brandService.UpdateBrandAsync(id, brand);
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        async public Task<ActionResult<BrandResponse>> DeleteBrandAsync(int id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            await _brandService.DeleteBrandAsync(id);
            return Ok();
        }
    }
}