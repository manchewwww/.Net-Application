using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IAddressRepository
    {
        public Task<AddressEntity> AddAddressAsync(AddressEntity entity);
        public Task<IEnumerable<AddressEntity>> GetAllAddressesAsync();
        public Task<AddressEntity?> GetAddressByIdAsync(long id);
        public Task UpdateAddressAsync(AddressEntity entity);
        public Task DeleteAddressAsync(AddressEntity entity);
    }

    public class AddressRepository : Repository<AddressEntity>, IAddressRepository
    {
        public AddressRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<AddressEntity> AddAddressAsync(AddressEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAddressesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<AddressEntity?> GetAddressByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateAddressAsync(AddressEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteAddressAsync(AddressEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
