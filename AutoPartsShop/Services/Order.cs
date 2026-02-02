using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IOrderService
    {
        public Task<OrderResponse> AddOrderAsync(OrderCreateRequest request);
        public Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();
        public Task<OrderResponse?> GetOrderByIdAsync(long id);
        public Task<OrderResponse> UpdateOrderAsync(long id, OrderUpdateRequest request);
        public Task<OrderResponse> DeleteOrderAsync(long id);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderResponse> AddOrderAsync(OrderCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddOrderAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var entities = await _repository.GetAllOrdersAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(long id)
        {
            var entity = await _repository.GetOrderByIdAsync(id) ?? throw new NotFoundException("Order with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<OrderResponse> UpdateOrderAsync(long id, OrderUpdateRequest request)
        {
            var existing = await _repository.GetOrderByIdAsync(id) ?? throw new NotFoundException("Order with ID " + id + " not found.");
            existing.OrderNumber = request.OrderNumber;
            existing.CustomerId = request.CustomerId;
            existing.Status = request.Status;
            existing.CurrencyId = request.CurrencyId;
            existing.Subtotal = request.Subtotal;
            existing.ShippingCost = request.ShippingCost;
            existing.DiscountTotal = request.DiscountTotal;
            existing.TaxTotal = request.TaxTotal;
            existing.GrandTotal = request.GrandTotal;
            existing.ShippingProvider = request.ShippingProvider;
            existing.DeliveryType = request.DeliveryType;
            existing.ShippingName = request.ShippingName;
            existing.ShippingPhone = request.ShippingPhone;
            existing.ShippingCountryId = request.ShippingCountryId;
            existing.ShippingCity = request.ShippingCity;
            existing.ShippingAddress1 = request.ShippingAddress1;
            existing.ShippingAddress2 = request.ShippingAddress2;
            existing.ShippingPostalCode = request.ShippingPostalCode;
            existing.ProviderLocationId = request.ProviderLocationId;
            existing.ProviderLocationName = request.ProviderLocationName;
            existing.BillingAddressSnapshot = request.BillingAddressSnapshot;

            await _repository.UpdateOrderAsync(existing);
            return existing.ToDto();
        }

        public async Task<OrderResponse> DeleteOrderAsync(long id)
        {
            var entity = await _repository.GetOrderByIdAsync(id) ?? throw new NotFoundException("Order with ID " + id + " not found.");
            await _repository.DeleteOrderAsync(entity);
            return entity.ToDto();
        }
    }
}
