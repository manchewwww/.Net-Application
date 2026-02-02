using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IOrderRepository
    {
        public Task<OrderEntity> AddOrderAsync(OrderEntity entity);
        public Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
        public Task<OrderEntity?> GetOrderByIdAsync(long id);
        public Task UpdateOrderAsync(OrderEntity entity);
        public Task DeleteOrderAsync(OrderEntity entity);
    }

    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<OrderEntity> AddOrderAsync(OrderEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<OrderEntity?> GetOrderByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateOrderAsync(OrderEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteOrderAsync(OrderEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
