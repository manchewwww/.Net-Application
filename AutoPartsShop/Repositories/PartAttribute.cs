using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartAttributeRepository
    {
        public Task<PartAttributeEntity> AddPartAttributeAsync(PartAttributeEntity entity);
        public Task<IEnumerable<PartAttributeEntity>> GetAllPartAttributesAsync();
        public Task<PartAttributeEntity?> GetPartAttributeByIdAsync(long id);
        public Task UpdatePartAttributeAsync(PartAttributeEntity entity);
        public Task DeletePartAttributeAsync(PartAttributeEntity entity);
    }

    public class PartAttributeRepository : Repository<PartAttributeEntity>, IPartAttributeRepository
    {
        public PartAttributeRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartAttributeEntity> AddPartAttributeAsync(PartAttributeEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartAttributeEntity>> GetAllPartAttributesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartAttributeEntity?> GetPartAttributeByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartAttributeAsync(PartAttributeEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartAttributeAsync(PartAttributeEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
