using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface ICartRepository
    {
        public Task<CartEntity> AddCartAsync(CartEntity entity);
        public Task<IEnumerable<CartEntity>> GetAllCartsAsync();
        public Task<CartEntity?> GetCartByIdAsync(long id);
        public Task UpdateCartAsync(CartEntity entity);
        public Task DeleteCartAsync(CartEntity entity);
    }

    public class CartRepository : Repository<CartEntity>, ICartRepository
    {
        public CartRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CartEntity> AddCartAsync(CartEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<CartEntity>> GetAllCartsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<CartEntity?> GetCartByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateCartAsync(CartEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteCartAsync(CartEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
