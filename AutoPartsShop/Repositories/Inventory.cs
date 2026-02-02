using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IInventoryRepository
    {
        public Task<InventoryEntity> AddInventoryAsync(InventoryEntity entity);
        public Task<IEnumerable<InventoryEntity>> GetAllInventoriesAsync();
        public Task<InventoryEntity?> GetInventoryByIdAsync(long id);
        public Task UpdateInventoryAsync(InventoryEntity entity);
        public Task DeleteInventoryAsync(InventoryEntity entity);
    }

    public class InventoryRepository : Repository<InventoryEntity>, IInventoryRepository
    {
        public InventoryRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<InventoryEntity> AddInventoryAsync(InventoryEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<InventoryEntity>> GetAllInventoriesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<InventoryEntity?> GetInventoryByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateInventoryAsync(InventoryEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteInventoryAsync(InventoryEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
