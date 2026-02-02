using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ISupplierPartService
    {
        public Task<SupplierPartResponse> AddSupplierPartAsync(SupplierPartCreateRequest request);
        public Task<IEnumerable<SupplierPartResponse>> GetAllSupplierPartsAsync();
        public Task<SupplierPartResponse?> GetSupplierPartByIdAsync(long id);
        public Task<SupplierPartResponse> UpdateSupplierPartAsync(long id, SupplierPartUpdateRequest request);
        public Task<SupplierPartResponse> DeleteSupplierPartAsync(long id);
    }

    public class SupplierPartService : ISupplierPartService
    {
        private readonly ISupplierPartRepository _repository;

        public SupplierPartService(ISupplierPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<SupplierPartResponse> AddSupplierPartAsync(SupplierPartCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddSupplierPartAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<SupplierPartResponse>> GetAllSupplierPartsAsync()
        {
            var entities = await _repository.GetAllSupplierPartsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<SupplierPartResponse?> GetSupplierPartByIdAsync(long id)
        {
            var entity = await _repository.GetSupplierPartByIdAsync(id) ?? throw new NotFoundException("SupplierPart with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<SupplierPartResponse> UpdateSupplierPartAsync(long id, SupplierPartUpdateRequest request)
        {
            var existing = await _repository.GetSupplierPartByIdAsync(id) ?? throw new NotFoundException("SupplierPart with ID " + id + " not found.");
            existing.SupplierId = request.SupplierId;
            existing.SupplierSku = request.SupplierSku;
            existing.Name = request.Name;
            existing.BrandName = request.BrandName;
            existing.Cost = request.Cost;
            existing.CurrencyId = request.CurrencyId;
            existing.LeadTimeDays = request.LeadTimeDays;
            existing.LastImportedAt = request.LastImportedAt;

            await _repository.UpdateSupplierPartAsync(existing);
            return existing.ToDto();
        }

        public async Task<SupplierPartResponse> DeleteSupplierPartAsync(long id)
        {
            var entity = await _repository.GetSupplierPartByIdAsync(id) ?? throw new NotFoundException("SupplierPart with ID " + id + " not found.");
            await _repository.DeleteSupplierPartAsync(entity);
            return entity.ToDto();
        }
    }
}
