using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IOrderItemRepository
    {
        public Task<OrderItemEntity> AddOrderItemAsync(OrderItemEntity entity);
        public Task<IEnumerable<OrderItemEntity>> GetAllOrderItemsAsync();
        public Task<OrderItemEntity?> GetOrderItemByIdAsync(long id);
        public Task UpdateOrderItemAsync(OrderItemEntity entity);
        public Task DeleteOrderItemAsync(OrderItemEntity entity);
    }

    public class OrderItemRepository : Repository<OrderItemEntity>, IOrderItemRepository
    {
        public OrderItemRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<OrderItemEntity> AddOrderItemAsync(OrderItemEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<OrderItemEntity>> GetAllOrderItemsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<OrderItemEntity?> GetOrderItemByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateOrderItemAsync(OrderItemEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteOrderItemAsync(OrderItemEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
