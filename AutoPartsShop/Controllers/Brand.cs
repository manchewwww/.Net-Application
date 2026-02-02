using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Entities.BrandEntity>> AddBrandAsync([FromBody] Entities.BrandEntity brand)
        {
            var created = await _brandService.AddBrandAsync(brand);
            return CreatedAtAction(nameof(GetBrandByIdAsync), new { id = created.Id }, created);
        }

        [HttpGet]
        async public Task<IEnumerable<Entities.BrandEntity>> GetAllBrandsAsync()
        {
            return await _brandService.GetAllBrandsAsync();
        }

        [HttpGet("{id:int}")]
        async public Task<ActionResult<Entities.BrandEntity?>> GetBrandByIdAsync(int id)
        {
            var brandEntity = await _brandService.GetBrandByIdAsync(id);
            return brandEntity == null ? NotFound() : Ok(brandEntity);
        }

        [HttpPut("{id:int}")]
        async public Task<ActionResult> UpdateBrandAsync(int id, [FromBody] Entities.BrandEntity brand)
        {
            if (brand.Id != 0 && brand.Id != id)
            {
                return BadRequest("ID mismatch.");
            }
            brand.Id = id;
            var existing = await _brandService.GetBrandByIdAsync(id);
            if (existing is null)
            {
                return NotFound();
            }

            await _brandService.UpdateBrandAsync(brand);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        async public Task<IActionResult> DeleteBrandAsync(int id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            await _brandService.DeleteBrandAsync(brand);
            return Ok();
        }
    }
}