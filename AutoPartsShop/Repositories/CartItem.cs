using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ICartItemRepository
    {
        public Task<CartItemEntity> AddCartItemAsync(CartItemEntity entity);
        public Task<IEnumerable<CartItemEntity>> GetAllCartItemsAsync();
        public Task<CartItemEntity?> GetCartItemByIdAsync(long id);
        public Task UpdateCartItemAsync(CartItemEntity entity);
        public Task DeleteCartItemAsync(CartItemEntity entity);
    }

    public class CartItemRepository : Repository<CartItemEntity>, ICartItemRepository
    {
        public CartItemRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CartItemEntity> AddCartItemAsync(CartItemEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<CartItemEntity>> GetAllCartItemsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<CartItemEntity?> GetCartItemByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateCartItemAsync(CartItemEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteCartItemAsync(CartItemEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
