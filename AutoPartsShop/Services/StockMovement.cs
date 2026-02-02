using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IStockMovementService
    {
        public Task<StockMovementResponse> AddStockMovementAsync(StockMovementCreateRequest request);
        public Task<IEnumerable<StockMovementResponse>> GetAllStockMovementsAsync();
        public Task<StockMovementResponse?> GetStockMovementByIdAsync(long id);
        public Task<StockMovementResponse> UpdateStockMovementAsync(long id, StockMovementUpdateRequest request);
        public Task<StockMovementResponse> DeleteStockMovementAsync(long id);
    }

    public class StockMovementService : IStockMovementService
    {
        private readonly IStockMovementRepository _repository;

        public StockMovementService(IStockMovementRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockMovementResponse> AddStockMovementAsync(StockMovementCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddStockMovementAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<StockMovementResponse>> GetAllStockMovementsAsync()
        {
            var entities = await _repository.GetAllStockMovementsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<StockMovementResponse?> GetStockMovementByIdAsync(long id)
        {
            var entity = await _repository.GetStockMovementByIdAsync(id) ?? throw new NotFoundException("StockMovement with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<StockMovementResponse> UpdateStockMovementAsync(long id, StockMovementUpdateRequest request)
        {
            var existing = await _repository.GetStockMovementByIdAsync(id) ?? throw new NotFoundException("StockMovement with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.WarehouseId = request.WarehouseId;
            existing.Type = request.Type;
            existing.QtyChange = request.QtyChange;
            existing.ReferenceType = request.ReferenceType;
            existing.ReferenceId = request.ReferenceId;
            existing.Note = request.Note;

            await _repository.UpdateStockMovementAsync(existing);
            return existing.ToDto();
        }

        public async Task<StockMovementResponse> DeleteStockMovementAsync(long id)
        {
            var entity = await _repository.GetStockMovementByIdAsync(id) ?? throw new NotFoundException("StockMovement with ID " + id + " not found.");
            await _repository.DeleteStockMovementAsync(entity);
            return entity.ToDto();
        }
    }
}
