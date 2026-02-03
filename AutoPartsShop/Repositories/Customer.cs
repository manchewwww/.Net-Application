using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ICustomerRepository
    {
        public Task<CustomerEntity> AddCustomerAsync(CustomerEntity entity);
        public Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync();
        public Task<CustomerEntity?> GetCustomerByIdAsync(long id);
        public Task<CustomerEntity?> GetCustomerByEmailAsync(string email);
        public Task UpdateCustomerAsync(CustomerEntity entity);
        public Task DeleteCustomerAsync(CustomerEntity entity);
    }

    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CustomerEntity> AddCustomerAsync(CustomerEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<CustomerEntity?> GetCustomerByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<CustomerEntity?> GetCustomerByEmailAsync(string email)
        {
            return DbSet.FirstOrDefault(c => c.Email == email);
        }

        public async Task UpdateCustomerAsync(CustomerEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteCustomerAsync(CustomerEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
