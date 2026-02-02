using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoPartsShop.Handlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandHandler : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        async public Task<Entities.BrandEntity> AddBrandAsync(Entities.BrandEntity brand)
        {
            return await _brandService.AddBrandAsync(brand);
        }

        [HttpGet]
        async public Task<IEnumerable<Entities.BrandEntity>> GetAllBrandsAsync()
        {
            return await _brandService.GetAllBrandsAsync();
        }

        [HttpGet("{id:int}")]
        async public Task<Entities.BrandEntity?> GetBrandByIdAsync(int id)
        {
            return await _brandService.GetBrandByIdAsync(id);
        }

        [HttpPut("{id:int}")]
        async public Task UpdateBrandAsync(int id, Entities.BrandEntity brand)
        {
            brand.Id = id;
            await _brandService.UpdateBrandAsync(brand);
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