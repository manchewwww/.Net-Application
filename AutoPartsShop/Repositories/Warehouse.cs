using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IWarehouseRepository
    {
        public Task<WarehouseEntity> AddWarehouseAsync(WarehouseEntity entity);
        public Task<IEnumerable<WarehouseEntity>> GetAllWarehousesAsync();
        public Task<WarehouseEntity?> GetWarehouseByIdAsync(long id);
        public Task UpdateWarehouseAsync(WarehouseEntity entity);
        public Task DeleteWarehouseAsync(WarehouseEntity entity);
    }

    public class WarehouseRepository : Repository<WarehouseEntity>, IWarehouseRepository
    {
        public WarehouseRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<WarehouseEntity> AddWarehouseAsync(WarehouseEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<WarehouseEntity>> GetAllWarehousesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<WarehouseEntity?> GetWarehouseByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateWarehouseAsync(WarehouseEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteWarehouseAsync(WarehouseEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
