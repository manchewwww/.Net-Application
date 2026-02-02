using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IVehicleMakeRepository
    {
        public Task<VehicleMakeEntity> AddVehicleMakeAsync(VehicleMakeEntity entity);
        public Task<IEnumerable<VehicleMakeEntity>> GetAllVehicleMakesAsync();
        public Task<VehicleMakeEntity?> GetVehicleMakeByIdAsync(long id);
        public Task UpdateVehicleMakeAsync(VehicleMakeEntity entity);
        public Task DeleteVehicleMakeAsync(VehicleMakeEntity entity);
    }

    public class VehicleMakeRepository : Repository<VehicleMakeEntity>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<VehicleMakeEntity> AddVehicleMakeAsync(VehicleMakeEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<VehicleMakeEntity>> GetAllVehicleMakesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<VehicleMakeEntity?> GetVehicleMakeByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateVehicleMakeAsync(VehicleMakeEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteVehicleMakeAsync(VehicleMakeEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
