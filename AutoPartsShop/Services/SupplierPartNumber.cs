using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ISupplierPartNumberService
    {
        public Task<SupplierPartNumberResponse> AddSupplierPartNumberAsync(SupplierPartNumberCreateRequest request);
        public Task<IEnumerable<SupplierPartNumberResponse>> GetAllSupplierPartNumbersAsync();
        public Task<SupplierPartNumberResponse?> GetSupplierPartNumberByIdAsync(long id);
        public Task<SupplierPartNumberResponse> UpdateSupplierPartNumberAsync(long id, SupplierPartNumberUpdateRequest request);
        public Task<SupplierPartNumberResponse> DeleteSupplierPartNumberAsync(long id);
    }

    public class SupplierPartNumberService : ISupplierPartNumberService
    {
        private readonly ISupplierPartNumberRepository _repository;

        public SupplierPartNumberService(ISupplierPartNumberRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupplierPartNumberResponse> AddSupplierPartNumberAsync(SupplierPartNumberCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddSupplierPartNumberAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<SupplierPartNumberResponse>> GetAllSupplierPartNumbersAsync()
        {
            var entities = await _repository.GetAllSupplierPartNumbersAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<SupplierPartNumberResponse?> GetSupplierPartNumberByIdAsync(long id)
        {
            var entity = await _repository.GetSupplierPartNumberByIdAsync(id) ?? throw new NotFoundException("SupplierPartNumber with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<SupplierPartNumberResponse> UpdateSupplierPartNumberAsync(long id, SupplierPartNumberUpdateRequest request)
        {
            var existing = await _repository.GetSupplierPartNumberByIdAsync(id) ?? throw new NotFoundException("SupplierPartNumber with ID " + id + " not found.");
            existing.SupplierPartId = request.SupplierPartId;
            existing.Type = request.Type;
            existing.Value = request.Value;

            await _repository.UpdateSupplierPartNumberAsync(existing);
            return existing.ToDto();
        }

        public async Task<SupplierPartNumberResponse> DeleteSupplierPartNumberAsync(long id)
        {
            var entity = await _repository.GetSupplierPartNumberByIdAsync(id) ?? throw new NotFoundException("SupplierPartNumber with ID " + id + " not found.");
            await _repository.DeleteSupplierPartNumberAsync(entity);
            return entity.ToDto();
        }
    }
}
