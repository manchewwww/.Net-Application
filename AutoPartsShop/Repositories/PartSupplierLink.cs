using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IPartSupplierLinkRepository
    {
        public Task<PartSupplierLinkEntity> AddPartSupplierLinkAsync(PartSupplierLinkEntity entity);
        public Task<IEnumerable<PartSupplierLinkEntity>> GetAllPartSupplierLinksAsync();
        public Task<PartSupplierLinkEntity?> GetPartSupplierLinkByIdAsync(long id);
        public Task UpdatePartSupplierLinkAsync(PartSupplierLinkEntity entity);
        public Task DeletePartSupplierLinkAsync(PartSupplierLinkEntity entity);
    }

    public class PartSupplierLinkRepository : Repository<PartSupplierLinkEntity>, IPartSupplierLinkRepository
    {
        public PartSupplierLinkRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<PartSupplierLinkEntity> AddPartSupplierLinkAsync(PartSupplierLinkEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<PartSupplierLinkEntity>> GetAllPartSupplierLinksAsync()
        {
            return await GetAllAsync();
        }

        public async Task<PartSupplierLinkEntity?> GetPartSupplierLinkByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePartSupplierLinkAsync(PartSupplierLinkEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeletePartSupplierLinkAsync(PartSupplierLinkEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
