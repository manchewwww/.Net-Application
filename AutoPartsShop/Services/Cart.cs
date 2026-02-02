using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ICartService
    {
        public Task<CartResponse> AddCartAsync(CartCreateRequest request);
        public Task<IEnumerable<CartResponse>> GetAllCartsAsync();
        public Task<CartResponse?> GetCartByIdAsync(long id);
        public Task<CartResponse> UpdateCartAsync(long id, CartUpdateRequest request);
        public Task<CartResponse> DeleteCartAsync(long id);
    }

    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<CartResponse> AddCartAsync(CartCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddCartAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<CartResponse>> GetAllCartsAsync()
        {
            var entities = await _repository.GetAllCartsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<CartResponse?> GetCartByIdAsync(long id)
        {
            var entity = await _repository.GetCartByIdAsync(id) ?? throw new NotFoundException("Cart with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<CartResponse> UpdateCartAsync(long id, CartUpdateRequest request)
        {
            var existing = await _repository.GetCartByIdAsync(id) ?? throw new NotFoundException("Cart with ID " + id + " not found.");
            existing.CustomerId = request.CustomerId;

            await _repository.UpdateCartAsync(existing);
            return existing.ToDto();
        }

        public async Task<CartResponse> DeleteCartAsync(long id)
        {
            var entity = await _repository.GetCartByIdAsync(id) ?? throw new NotFoundException("Cart with ID " + id + " not found.");
            await _repository.DeleteCartAsync(entity);
            return entity.ToDto();
        }
    }
}
