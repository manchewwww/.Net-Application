using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ICategoryRepository
    {
        public Task<CategoryEntity> AddCategoryAsync(CategoryEntity entity);
        public Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
        public Task<CategoryEntity?> GetCategoryByIdAsync(long id);
        public Task UpdateCategoryAsync(CategoryEntity entity);
        public Task DeleteCategoryAsync(CategoryEntity entity);
    }

    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CategoryEntity> AddCategoryAsync(CategoryEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<CategoryEntity?> GetCategoryByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(CategoryEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteCategoryAsync(CategoryEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
