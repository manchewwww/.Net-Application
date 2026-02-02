using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IReturnItemService
    {
        public Task<ReturnItemResponse> AddReturnItemAsync(ReturnItemCreateRequest request);
        public Task<IEnumerable<ReturnItemResponse>> GetAllReturnItemsAsync();
        public Task<ReturnItemResponse?> GetReturnItemByIdAsync(long id);
        public Task<ReturnItemResponse> UpdateReturnItemAsync(long id, ReturnItemUpdateRequest request);
        public Task<ReturnItemResponse> DeleteReturnItemAsync(long id);
    }

    public class ReturnItemService : IReturnItemService
    {
        private readonly IReturnItemRepository _repository;

        public ReturnItemService(IReturnItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReturnItemResponse> AddReturnItemAsync(ReturnItemCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddReturnItemAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<ReturnItemResponse>> GetAllReturnItemsAsync()
        {
            var entities = await _repository.GetAllReturnItemsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<ReturnItemResponse?> GetReturnItemByIdAsync(long id)
        {
            var entity = await _repository.GetReturnItemByIdAsync(id) ?? throw new NotFoundException("ReturnItem with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<ReturnItemResponse> UpdateReturnItemAsync(long id, ReturnItemUpdateRequest request)
        {
            var existing = await _repository.GetReturnItemByIdAsync(id) ?? throw new NotFoundException("ReturnItem with ID " + id + " not found.");
            existing.ReturnId = request.ReturnId;
            existing.OrderItemId = request.OrderItemId;
            existing.Qty = request.Qty;
            existing.Condition = request.Condition;
            existing.RefundAmount = request.RefundAmount;

            await _repository.UpdateReturnItemAsync(existing);
            return existing.ToDto();
        }

        public async Task<ReturnItemResponse> DeleteReturnItemAsync(long id)
        {
            var entity = await _repository.GetReturnItemByIdAsync(id) ?? throw new NotFoundException("ReturnItem with ID " + id + " not found.");
            await _repository.DeleteReturnItemAsync(entity);
            return entity.ToDto();
        }
    }
}
