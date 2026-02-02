using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IInventoryService
    {
        public Task<InventoryResponse> AddInventoryAsync(InventoryCreateRequest request);
        public Task<IEnumerable<InventoryResponse>> GetAllInventoriesAsync();
        public Task<InventoryResponse?> GetInventoryByIdAsync(long id);
        public Task<InventoryResponse> UpdateInventoryAsync(long id, InventoryUpdateRequest request);
        public Task<InventoryResponse> DeleteInventoryAsync(long id);
    }

    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;

        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<InventoryResponse> AddInventoryAsync(InventoryCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddInventoryAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<InventoryResponse>> GetAllInventoriesAsync()
        {
            var entities = await _repository.GetAllInventoriesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<InventoryResponse?> GetInventoryByIdAsync(long id)
        {
            var entity = await _repository.GetInventoryByIdAsync(id) ?? throw new NotFoundException("Inventory with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<InventoryResponse> UpdateInventoryAsync(long id, InventoryUpdateRequest request)
        {
            var existing = await _repository.GetInventoryByIdAsync(id) ?? throw new NotFoundException("Inventory with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.WarehouseId = request.WarehouseId;
            existing.QtyOnHand = request.QtyOnHand;
            existing.QtyReserved = request.QtyReserved;
            existing.ReorderPoint = request.ReorderPoint;

            await _repository.UpdateInventoryAsync(existing);
            return existing.ToDto();
        }

        public async Task<InventoryResponse> DeleteInventoryAsync(long id)
        {
            var entity = await _repository.GetInventoryByIdAsync(id) ?? throw new NotFoundException("Inventory with ID " + id + " not found.");
            await _repository.DeleteInventoryAsync(entity);
            return entity.ToDto();
        }
    }
}
