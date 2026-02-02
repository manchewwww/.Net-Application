using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartRepository
    {
        public Task<PartEntity> AddPartAsync(PartEntity entity);
        public Task<IEnumerable<PartEntity>> GetAllPartsAsync();
        public Task<PartEntity?> GetPartByIdAsync(long id);
        public Task UpdatePartAsync(PartEntity entity);
        public Task DeletePartAsync(PartEntity entity);
    }

    public class PartRepository : Repository<PartEntity>, IPartRepository
    {
        public PartRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartEntity> AddPartAsync(PartEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartEntity>> GetAllPartsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartEntity?> GetPartByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartAsync(PartEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartAsync(PartEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
