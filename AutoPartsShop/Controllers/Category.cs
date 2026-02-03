using AutoPartsShop.Dtos;
using AutoPartsShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AutoPartsShop.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> AddCategoryAsync([FromBody] CategoryCreateRequest request)
        {
            var created = await _service.AddCategoryAsync(request);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            return await _service.GetAllCategoriesAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CategoryResponse?>> GetCategoryByIdAsync(long id)
        {
            var entity = await _service.GetCategoryByIdAsync(id);
            return Ok(entity);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:long}")]
        public async Task<ActionResult> UpdateCategoryAsync(long id, [FromBody] CategoryUpdateRequest request)
        {
            var updated = await _service.UpdateCategoryAsync(id, request);
            return Ok(updated);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CategoryResponse>> DeleteCategoryAsync(long id)
        {
            await _service.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
