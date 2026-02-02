using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IWarehouseService
    {
        public Task<WarehouseResponse> AddWarehouseAsync(WarehouseCreateRequest request);
        public Task<IEnumerable<WarehouseResponse>> GetAllWarehousesAsync();
        public Task<WarehouseResponse?> GetWarehouseByIdAsync(long id);
        public Task<WarehouseResponse> UpdateWarehouseAsync(long id, WarehouseUpdateRequest request);
        public Task<WarehouseResponse> DeleteWarehouseAsync(long id);
    }

    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseService(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public async Task<WarehouseResponse> AddWarehouseAsync(WarehouseCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddWarehouseAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<WarehouseResponse>> GetAllWarehousesAsync()
        {
            var entities = await _repository.GetAllWarehousesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<WarehouseResponse?> GetWarehouseByIdAsync(long id)
        {
            var entity = await _repository.GetWarehouseByIdAsync(id) ?? throw new NotFoundException("Warehouse with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<WarehouseResponse> UpdateWarehouseAsync(long id, WarehouseUpdateRequest request)
        {
            var existing = await _repository.GetWarehouseByIdAsync(id) ?? throw new NotFoundException("Warehouse with ID " + id + " not found.");
            existing.Name = request.Name;
            existing.CountryId = request.CountryId;
            existing.City = request.City;
            existing.Address1 = request.Address1;
            existing.Address2 = request.Address2;
            existing.Postcode = request.Postcode;

            await _repository.UpdateWarehouseAsync(existing);
            return existing.ToDto();
        }

        public async Task<WarehouseResponse> DeleteWarehouseAsync(long id)
        {
            var entity = await _repository.GetWarehouseByIdAsync(id) ?? throw new NotFoundException("Warehouse with ID " + id + " not found.");
            await _repository.DeleteWarehouseAsync(entity);
            return entity.ToDto();
        }
    }
}
