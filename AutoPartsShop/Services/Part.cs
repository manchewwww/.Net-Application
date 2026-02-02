using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartService
    {
        public Task<PartResponse> AddPartAsync(PartCreateRequest request);
        public Task<IEnumerable<PartResponse>> GetAllPartsAsync();
        public Task<PartResponse?> GetPartByIdAsync(long id);
        public Task<PartResponse> UpdatePartAsync(long id, PartUpdateRequest request);
        public Task<PartResponse> DeletePartAsync(long id);
    }

    public class PartService : IPartService
    {
        private readonly IPartRepository _repository;

        public PartService(IPartRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartResponse> AddPartAsync(PartCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartResponse>> GetAllPartsAsync()
        {
            var entities = await _repository.GetAllPartsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartResponse?> GetPartByIdAsync(long id)
        {
            var entity = await _repository.GetPartByIdAsync(id) ?? throw new NotFoundException("Part with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartResponse> UpdatePartAsync(long id, PartUpdateRequest request)
        {
            var existing = await _repository.GetPartByIdAsync(id) ?? throw new NotFoundException("Part with ID " + id + " not found.");
            existing.Sku = request.Sku;
            existing.BrandId = request.BrandId;
            existing.CategoryId = request.CategoryId;
            existing.Name = request.Name;
            existing.Description = request.Description;
            existing.IsActive = request.IsActive;
            existing.WeightKg = request.WeightKg;

            await _repository.UpdatePartAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartResponse> DeletePartAsync(long id)
        {
            var entity = await _repository.GetPartByIdAsync(id) ?? throw new NotFoundException("Part with ID " + id + " not found.");
            await _repository.DeletePartAsync(entity);
            return entity.ToDto();
        }
    }
}
