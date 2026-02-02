using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ISupplierRepository
    {
        public Task<SupplierEntity> AddSupplierAsync(SupplierEntity entity);
        public Task<IEnumerable<SupplierEntity>> GetAllSuppliersAsync();
        public Task<SupplierEntity?> GetSupplierByIdAsync(long id);
        public Task UpdateSupplierAsync(SupplierEntity entity);
        public Task DeleteSupplierAsync(SupplierEntity entity);
    }

    public class SupplierRepository : Repository<SupplierEntity>, ISupplierRepository
    {
        public SupplierRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<SupplierEntity> AddSupplierAsync(SupplierEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<SupplierEntity>> GetAllSuppliersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SupplierEntity?> GetSupplierByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateSupplierAsync(SupplierEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteSupplierAsync(SupplierEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
