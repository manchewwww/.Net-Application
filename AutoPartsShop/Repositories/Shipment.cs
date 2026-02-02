using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IShipmentRepository
    {
        public Task<ShipmentEntity> AddShipmentAsync(ShipmentEntity entity);
        public Task<IEnumerable<ShipmentEntity>> GetAllShipmentsAsync();
        public Task<ShipmentEntity?> GetShipmentByIdAsync(long id);
        public Task UpdateShipmentAsync(ShipmentEntity entity);
        public Task DeleteShipmentAsync(ShipmentEntity entity);
    }

    public class ShipmentRepository : Repository<ShipmentEntity>, IShipmentRepository
    {
        public ShipmentRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<ShipmentEntity> AddShipmentAsync(ShipmentEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<ShipmentEntity>> GetAllShipmentsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ShipmentEntity?> GetShipmentByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateShipmentAsync(ShipmentEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteShipmentAsync(ShipmentEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
