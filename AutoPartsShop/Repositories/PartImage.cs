using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartImageRepository
    {
        public Task<PartImageEntity> AddPartImageAsync(PartImageEntity entity);
        public Task<IEnumerable<PartImageEntity>> GetAllPartImagesAsync();
        public Task<PartImageEntity?> GetPartImageByIdAsync(long id);
        public Task UpdatePartImageAsync(PartImageEntity entity);
        public Task DeletePartImageAsync(PartImageEntity entity);
    }

    public class PartImageRepository : Repository<PartImageEntity>, IPartImageRepository
    {
        public PartImageRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartImageEntity> AddPartImageAsync(PartImageEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartImageEntity>> GetAllPartImagesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartImageEntity?> GetPartImageByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartImageAsync(PartImageEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartImageAsync(PartImageEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
