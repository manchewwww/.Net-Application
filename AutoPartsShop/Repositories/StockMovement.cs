using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IStockMovementRepository
    {
        public Task<StockMovementEntity> AddStockMovementAsync(StockMovementEntity entity);
        public Task<IEnumerable<StockMovementEntity>> GetAllStockMovementsAsync();
        public Task<StockMovementEntity?> GetStockMovementByIdAsync(long id);
        public Task UpdateStockMovementAsync(StockMovementEntity entity);
        public Task DeleteStockMovementAsync(StockMovementEntity entity);
    }

    public class StockMovementRepository : Repository<StockMovementEntity>, IStockMovementRepository
    {
        public StockMovementRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<StockMovementEntity> AddStockMovementAsync(StockMovementEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<StockMovementEntity>> GetAllStockMovementsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<StockMovementEntity?> GetStockMovementByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateStockMovementAsync(StockMovementEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteStockMovementAsync(StockMovementEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
