using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ICategoryService
    {
        public Task<CategoryResponse> AddCategoryAsync(CategoryCreateRequest request);
        public Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
        public Task<CategoryResponse?> GetCategoryByIdAsync(long id);
        public Task<CategoryResponse> UpdateCategoryAsync(long id, CategoryUpdateRequest request);
        public Task<CategoryResponse> DeleteCategoryAsync(long id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CategoryResponse> AddCategoryAsync(CategoryCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddCategoryAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var entities = await _repository.GetAllCategoriesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<CategoryResponse?> GetCategoryByIdAsync(long id)
        {
            var entity = await _repository.GetCategoryByIdAsync(id) ?? throw new NotFoundException("Category with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<CategoryResponse> UpdateCategoryAsync(long id, CategoryUpdateRequest request)
        {
            var existing = await _repository.GetCategoryByIdAsync(id) ?? throw new NotFoundException("Category with ID " + id + " not found.");
            existing.ParentCategoryId = request.ParentCategoryId;
            existing.Name = request.Name;
            existing.Slug = request.Slug;

            await _repository.UpdateCategoryAsync(existing);
            return existing.ToDto();
        }

        public async Task<CategoryResponse> DeleteCategoryAsync(long id)
        {
            var entity = await _repository.GetCategoryByIdAsync(id) ?? throw new NotFoundException("Category with ID " + id + " not found.");
            await _repository.DeleteCategoryAsync(entity);
            return entity.ToDto();
        }
    }
}
