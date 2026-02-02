using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IVehicleModelRepository
    {
        public Task<VehicleModelEntity> AddVehicleModelAsync(VehicleModelEntity entity);
        public Task<IEnumerable<VehicleModelEntity>> GetAllVehicleModelsAsync();
        public Task<VehicleModelEntity?> GetVehicleModelByIdAsync(long id);
        public Task UpdateVehicleModelAsync(VehicleModelEntity entity);
        public Task DeleteVehicleModelAsync(VehicleModelEntity entity);
    }

    public class VehicleModelRepository : Repository<VehicleModelEntity>, IVehicleModelRepository
    {
        public VehicleModelRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<VehicleModelEntity> AddVehicleModelAsync(VehicleModelEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<VehicleModelEntity>> GetAllVehicleModelsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<VehicleModelEntity?> GetVehicleModelByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateVehicleModelAsync(VehicleModelEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteVehicleModelAsync(VehicleModelEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
