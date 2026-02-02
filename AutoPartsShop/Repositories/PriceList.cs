using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPriceListRepository
    {
        public Task<PriceListEntity> AddPriceListAsync(PriceListEntity entity);
        public Task<IEnumerable<PriceListEntity>> GetAllPriceListsAsync();
        public Task<PriceListEntity?> GetPriceListByIdAsync(long id);
        public Task UpdatePriceListAsync(PriceListEntity entity);
        public Task DeletePriceListAsync(PriceListEntity entity);
    }

    public class PriceListRepository : Repository<PriceListEntity>, IPriceListRepository
    {
        public PriceListRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PriceListEntity> AddPriceListAsync(PriceListEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PriceListEntity>> GetAllPriceListsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PriceListEntity?> GetPriceListByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePriceListAsync(PriceListEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePriceListAsync(PriceListEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
