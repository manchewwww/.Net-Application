using AutoPartsShop.Data;
using AutoPartsShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Repositories
{
    public interface ICartSessionRepository
    {
        public Task<CartEntity> GetOrCreateCartAsync(long customerId);
        public Task<List<(CartItemEntity Item, PartEntity Part)>> GetItemsWithPartsAsync(long cartId);
        public Task<CartItemEntity?> GetCartItemAsync(long cartId, long partId);
        public Task AddCartItemAsync(CartItemEntity item);
        public Task UpdateCartItemAsync(CartItemEntity item);
        public Task RemoveCartItemAsync(CartItemEntity item);
        public Task ClearCartAsync(long cartId);
    }

    public class CartSessionRepository : ICartSessionRepository
    {
        private readonly AutoPartsShopDbContext _context;

        public CartSessionRepository(AutoPartsShopDbContext context)
        {
            _context = context;
        }

        public async Task<CartEntity> GetOrCreateCartAsync(long customerId)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (cart != null)
            {
                return cart;
            }

            cart = new CartEntity { CustomerId = customerId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<List<(CartItemEntity Item, PartEntity Part)>> GetItemsWithPartsAsync(long cartId)
        {
            return await _context.CartItems
                .Where(i => i.CartId == cartId)
                .Join(
                    _context.Parts,
                    item => item.PartId,
                    part => part.Id,
                    (item, part) => new { item, part }
                )
                .Select(x => new ValueTuple<CartItemEntity, PartEntity>(x.item, x.part))
                .ToListAsync();
        }

        public async Task<CartItemEntity?> GetCartItemAsync(long cartId, long partId)
        {
            return await _context.CartItems.FirstOrDefaultAsync(i => i.CartId == cartId && i.PartId == partId);
        }

        public async Task AddCartItemAsync(CartItemEntity item)
        {
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(CartItemEntity item)
        {
            _context.CartItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartItemAsync(CartItemEntity item)
        {
            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task ClearCartAsync(long cartId)
        {
            var items = await _context.CartItems.Where(i => i.CartId == cartId).ToListAsync();
            if (items.Count == 0)
            {
                return;
            }

            _context.CartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
