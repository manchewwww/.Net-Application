using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartNumberRepository
    {
        public Task<PartNumberEntity> AddPartNumberAsync(PartNumberEntity entity);
        public Task<IEnumerable<PartNumberEntity>> GetAllPartNumbersAsync();
        public Task<PartNumberEntity?> GetPartNumberByIdAsync(long id);
        public Task UpdatePartNumberAsync(PartNumberEntity entity);
        public Task DeletePartNumberAsync(PartNumberEntity entity);
    }

    public class PartNumberRepository : Repository<PartNumberEntity>, IPartNumberRepository
    {
        public PartNumberRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartNumberEntity> AddPartNumberAsync(PartNumberEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartNumberEntity>> GetAllPartNumbersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartNumberEntity?> GetPartNumberByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartNumberAsync(PartNumberEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartNumberAsync(PartNumberEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
