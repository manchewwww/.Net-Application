using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ISupplierPartRepository
    {
        public Task<SupplierPartEntity> AddSupplierPartAsync(SupplierPartEntity entity);
        public Task<IEnumerable<SupplierPartEntity>> GetAllSupplierPartsAsync();
        public Task<SupplierPartEntity?> GetSupplierPartByIdAsync(long id);
        public Task UpdateSupplierPartAsync(SupplierPartEntity entity);
        public Task DeleteSupplierPartAsync(SupplierPartEntity entity);
    }

    public class SupplierPartRepository : Repository<SupplierPartEntity>, ISupplierPartRepository
    {
        public SupplierPartRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<SupplierPartEntity> AddSupplierPartAsync(SupplierPartEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<SupplierPartEntity>> GetAllSupplierPartsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SupplierPartEntity?> GetSupplierPartByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateSupplierPartAsync(SupplierPartEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteSupplierPartAsync(SupplierPartEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
