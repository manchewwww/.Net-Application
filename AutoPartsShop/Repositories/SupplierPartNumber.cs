using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ISupplierPartNumberRepository
    {
        public Task<SupplierPartNumberEntity> AddSupplierPartNumberAsync(SupplierPartNumberEntity entity);
        public Task<IEnumerable<SupplierPartNumberEntity>> GetAllSupplierPartNumbersAsync();
        public Task<SupplierPartNumberEntity?> GetSupplierPartNumberByIdAsync(long id);
        public Task UpdateSupplierPartNumberAsync(SupplierPartNumberEntity entity);
        public Task DeleteSupplierPartNumberAsync(SupplierPartNumberEntity entity);
    }

    public class SupplierPartNumberRepository : Repository<SupplierPartNumberEntity>, ISupplierPartNumberRepository
    {
        public SupplierPartNumberRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<SupplierPartNumberEntity> AddSupplierPartNumberAsync(SupplierPartNumberEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<SupplierPartNumberEntity>> GetAllSupplierPartNumbersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SupplierPartNumberEntity?> GetSupplierPartNumberByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateSupplierPartNumberAsync(SupplierPartNumberEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteSupplierPartNumberAsync(SupplierPartNumberEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
