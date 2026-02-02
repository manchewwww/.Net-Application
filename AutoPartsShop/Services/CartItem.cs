using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ICartItemService
    {
        public Task<CartItemResponse> AddCartItemAsync(CartItemCreateRequest request);
        public Task<IEnumerable<CartItemResponse>> GetAllCartItemsAsync();
        public Task<CartItemResponse?> GetCartItemByIdAsync(long id);
        public Task<CartItemResponse> UpdateCartItemAsync(long id, CartItemUpdateRequest request);
        public Task<CartItemResponse> DeleteCartItemAsync(long id);
    }

    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<CartItemResponse> AddCartItemAsync(CartItemCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddCartItemAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<CartItemResponse>> GetAllCartItemsAsync()
        {
            var entities = await _repository.GetAllCartItemsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<CartItemResponse?> GetCartItemByIdAsync(long id)
        {
            var entity = await _repository.GetCartItemByIdAsync(id) ?? throw new NotFoundException("CartItem with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<CartItemResponse> UpdateCartItemAsync(long id, CartItemUpdateRequest request)
        {
            var existing = await _repository.GetCartItemByIdAsync(id) ?? throw new NotFoundException("CartItem with ID " + id + " not found.");
            existing.CartId = request.CartId;
            existing.PartId = request.PartId;
            existing.Qty = request.Qty;

            await _repository.UpdateCartItemAsync(existing);
            return existing.ToDto();
        }

        public async Task<CartItemResponse> DeleteCartItemAsync(long id)
        {
            var entity = await _repository.GetCartItemByIdAsync(id) ?? throw new NotFoundException("CartItem with ID " + id + " not found.");
            await _repository.DeleteCartItemAsync(entity);
            return entity.ToDto();
        }
    }
}
