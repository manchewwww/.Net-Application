using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IVehicleVariantRepository
    {
        public Task<VehicleVariantEntity> AddVehicleVariantAsync(VehicleVariantEntity entity);
        public Task<IEnumerable<VehicleVariantEntity>> GetAllVehicleVariantsAsync();
        public Task<VehicleVariantEntity?> GetVehicleVariantByIdAsync(long id);
        public Task UpdateVehicleVariantAsync(VehicleVariantEntity entity);
        public Task DeleteVehicleVariantAsync(VehicleVariantEntity entity);
    }

    public class VehicleVariantRepository : Repository<VehicleVariantEntity>, IVehicleVariantRepository
    {
        public VehicleVariantRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<VehicleVariantEntity> AddVehicleVariantAsync(VehicleVariantEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<VehicleVariantEntity>> GetAllVehicleVariantsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<VehicleVariantEntity?> GetVehicleVariantByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateVehicleVariantAsync(VehicleVariantEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteVehicleVariantAsync(VehicleVariantEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
