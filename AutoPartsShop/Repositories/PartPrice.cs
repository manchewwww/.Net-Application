using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartPriceRepository
    {
        public Task<PartPriceEntity> AddPartPriceAsync(PartPriceEntity entity);
        public Task<IEnumerable<PartPriceEntity>> GetAllPartPricesAsync();
        public Task<PartPriceEntity?> GetPartPriceByIdAsync(long id);
        public Task UpdatePartPriceAsync(PartPriceEntity entity);
        public Task DeletePartPriceAsync(PartPriceEntity entity);
    }

    public class PartPriceRepository : Repository<PartPriceEntity>, IPartPriceRepository
    {
        public PartPriceRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartPriceEntity> AddPartPriceAsync(PartPriceEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartPriceEntity>> GetAllPartPricesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartPriceEntity?> GetPartPriceByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartPriceAsync(PartPriceEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartPriceAsync(PartPriceEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
