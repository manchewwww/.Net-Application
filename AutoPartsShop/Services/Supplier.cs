using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ISupplierService
    {
        public Task<SupplierResponse> AddSupplierAsync(SupplierCreateRequest request);
        public Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync();
        public Task<SupplierResponse?> GetSupplierByIdAsync(long id);
        public Task<SupplierResponse> UpdateSupplierAsync(long id, SupplierUpdateRequest request);
        public Task<SupplierResponse> DeleteSupplierAsync(long id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupplierResponse> AddSupplierAsync(SupplierCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddSupplierAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync()
        {
            var entities = await _repository.GetAllSuppliersAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<SupplierResponse?> GetSupplierByIdAsync(long id)
        {
            var entity = await _repository.GetSupplierByIdAsync(id) ?? throw new NotFoundException("Supplier with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<SupplierResponse> UpdateSupplierAsync(long id, SupplierUpdateRequest request)
        {
            var existing = await _repository.GetSupplierByIdAsync(id) ?? throw new NotFoundException("Supplier with ID " + id + " not found.");
            existing.Name = request.Name;
            existing.CountryId = request.CountryId;
            existing.Email = request.Email;
            existing.Phone = request.Phone;
            existing.IsActive = request.IsActive;

            await _repository.UpdateSupplierAsync(existing);
            return existing.ToDto();
        }

        public async Task<SupplierResponse> DeleteSupplierAsync(long id)
        {
            var entity = await _repository.GetSupplierByIdAsync(id) ?? throw new NotFoundException("Supplier with ID " + id + " not found.");
            await _repository.DeleteSupplierAsync(entity);
            return entity.ToDto();
        }
    }
}
