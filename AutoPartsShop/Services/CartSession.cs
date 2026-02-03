using AutoPartsShop.Dtos;
using AutoPartsShop.Entities;
using AutoPartsShop.Repositories;

namespace AutoPartsShop.Services
{
    public interface ICartSessionService
    {
        public Task<CartSessionResponse> GetCartAsync(long customerId);
        public Task<CartSessionResponse> UpsertItemAsync(long customerId, CartItemUpsertRequest request);
        public Task<CartSessionResponse> RemoveItemAsync(long customerId, long partId);
        public Task<CartSessionResponse> ClearCartAsync(long customerId);
    }

    public class CartSessionService : ICartSessionService
    {
        private readonly ICartSessionRepository _cartRepository;

        public CartSessionService(ICartSessionRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartSessionResponse> GetCartAsync(long customerId)
        {
            var cart = await _cartRepository.GetOrCreateCartAsync(customerId);
            return await BuildCartResponseAsync(cart.Id);
        }

        public async Task<CartSessionResponse> UpsertItemAsync(long customerId, CartItemUpsertRequest request)
        {
            var cart = await _cartRepository.GetOrCreateCartAsync(customerId);
            var item = await _cartRepository.GetCartItemAsync(cart.Id, request.PartId);
            if (item == null)
            {
                item = new CartItemEntity
                {
                    CartId = cart.Id,
                    PartId = request.PartId,
                    Qty = request.Qty
                };
                await _cartRepository.AddCartItemAsync(item);
            }
            else
            {
                item.Qty = request.Qty;
                await _cartRepository.UpdateCartItemAsync(item);
            }
            return await BuildCartResponseAsync(cart.Id);
        }

        public async Task<CartSessionResponse> RemoveItemAsync(long customerId, long partId)
        {
            var cart = await _cartRepository.GetOrCreateCartAsync(customerId);
            var item = await _cartRepository.GetCartItemAsync(cart.Id, partId);
            if (item != null)
            {
                await _cartRepository.RemoveCartItemAsync(item);
            }

            return await BuildCartResponseAsync(cart.Id);
        }

        public async Task<CartSessionResponse> ClearCartAsync(long customerId)
        {
            var cart = await _cartRepository.GetOrCreateCartAsync(customerId);
            await _cartRepository.ClearCartAsync(cart.Id);

            return await BuildCartResponseAsync(cart.Id);
        }

        private async Task<CartSessionResponse> BuildCartResponseAsync(long cartId)
        {
            var items = await _cartRepository.GetItemsWithPartsAsync(cartId);
            var responseItems = items
                .Select(pair => new CartSessionItemResponse(pair.Item.Id, pair.Item.PartId, pair.Item.Qty, pair.Part.Name, pair.Part.Sku))
                .ToList();

            return new CartSessionResponse(cartId, responseItems);
        }
    }
}
