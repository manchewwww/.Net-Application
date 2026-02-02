using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IShipmentService
    {
        public Task<ShipmentResponse> AddShipmentAsync(ShipmentCreateRequest request);
        public Task<IEnumerable<ShipmentResponse>> GetAllShipmentsAsync();
        public Task<ShipmentResponse?> GetShipmentByIdAsync(long id);
        public Task<ShipmentResponse> UpdateShipmentAsync(long id, ShipmentUpdateRequest request);
        public Task<ShipmentResponse> DeleteShipmentAsync(long id);
    }

    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _repository;

        public ShipmentService(IShipmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShipmentResponse> AddShipmentAsync(ShipmentCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddShipmentAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<ShipmentResponse>> GetAllShipmentsAsync()
        {
            var entities = await _repository.GetAllShipmentsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<ShipmentResponse?> GetShipmentByIdAsync(long id)
        {
            var entity = await _repository.GetShipmentByIdAsync(id) ?? throw new NotFoundException("Shipment with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<ShipmentResponse> UpdateShipmentAsync(long id, ShipmentUpdateRequest request)
        {
            var existing = await _repository.GetShipmentByIdAsync(id) ?? throw new NotFoundException("Shipment with ID " + id + " not found.");
            existing.OrderId = request.OrderId;
            existing.Carrier = request.Carrier;
            existing.TrackingNumber = request.TrackingNumber;
            existing.Status = request.Status;
            existing.ShippedAt = request.ShippedAt;
            existing.DeliveredAt = request.DeliveredAt;

            await _repository.UpdateShipmentAsync(existing);
            return existing.ToDto();
        }

        public async Task<ShipmentResponse> DeleteShipmentAsync(long id)
        {
            var entity = await _repository.GetShipmentByIdAsync(id) ?? throw new NotFoundException("Shipment with ID " + id + " not found.");
            await _repository.DeleteShipmentAsync(entity);
            return entity.ToDto();
        }
    }
}
