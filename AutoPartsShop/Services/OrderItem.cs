using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IOrderItemService
    {
        public Task<OrderItemResponse> AddOrderItemAsync(OrderItemCreateRequest request);
        public Task<IEnumerable<OrderItemResponse>> GetAllOrderItemsAsync();
        public Task<OrderItemResponse?> GetOrderItemByIdAsync(long id);
        public Task<OrderItemResponse> UpdateOrderItemAsync(long id, OrderItemUpdateRequest request);
        public Task<OrderItemResponse> DeleteOrderItemAsync(long id);
    }

    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _repository;

        public OrderItemService(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderItemResponse> AddOrderItemAsync(OrderItemCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddOrderItemAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<OrderItemResponse>> GetAllOrderItemsAsync()
        {
            var entities = await _repository.GetAllOrderItemsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<OrderItemResponse?> GetOrderItemByIdAsync(long id)
        {
            var entity = await _repository.GetOrderItemByIdAsync(id) ?? throw new NotFoundException("OrderItem with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<OrderItemResponse> UpdateOrderItemAsync(long id, OrderItemUpdateRequest request)
        {
            var existing = await _repository.GetOrderItemByIdAsync(id) ?? throw new NotFoundException("OrderItem with ID " + id + " not found.");
            existing.OrderId = request.OrderId;
            existing.PartId = request.PartId;
            existing.SkuSnapshot = request.SkuSnapshot;
            existing.NameSnapshot = request.NameSnapshot;
            existing.UnitPrice = request.UnitPrice;
            existing.Qty = request.Qty;
            existing.LineTotal = request.LineTotal;

            await _repository.UpdateOrderItemAsync(existing);
            return existing.ToDto();
        }

        public async Task<OrderItemResponse> DeleteOrderItemAsync(long id)
        {
            var entity = await _repository.GetOrderItemByIdAsync(id) ?? throw new NotFoundException("OrderItem with ID " + id + " not found.");
            await _repository.DeleteOrderItemAsync(entity);
            return entity.ToDto();
        }
    }
}
