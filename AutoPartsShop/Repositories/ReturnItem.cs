using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IReturnItemRepository
    {
        public Task<ReturnItemEntity> AddReturnItemAsync(ReturnItemEntity entity);
        public Task<IEnumerable<ReturnItemEntity>> GetAllReturnItemsAsync();
        public Task<ReturnItemEntity?> GetReturnItemByIdAsync(long id);
        public Task UpdateReturnItemAsync(ReturnItemEntity entity);
        public Task DeleteReturnItemAsync(ReturnItemEntity entity);
    }

    public class ReturnItemRepository : Repository<ReturnItemEntity>, IReturnItemRepository
    {
        public ReturnItemRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<ReturnItemEntity> AddReturnItemAsync(ReturnItemEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<ReturnItemEntity>> GetAllReturnItemsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ReturnItemEntity?> GetReturnItemByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateReturnItemAsync(ReturnItemEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteReturnItemAsync(ReturnItemEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
