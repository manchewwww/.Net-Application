using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartAttributeService
    {
        public Task<PartAttributeResponse> AddPartAttributeAsync(PartAttributeCreateRequest request);
        public Task<IEnumerable<PartAttributeResponse>> GetAllPartAttributesAsync();
        public Task<PartAttributeResponse?> GetPartAttributeByIdAsync(long id);
        public Task<PartAttributeResponse> UpdatePartAttributeAsync(long id, PartAttributeUpdateRequest request);
        public Task<PartAttributeResponse> DeletePartAttributeAsync(long id);
    }

    public class PartAttributeService : IPartAttributeService
    {
        private readonly IPartAttributeRepository _repository;

        public PartAttributeService(IPartAttributeRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartAttributeResponse> AddPartAttributeAsync(PartAttributeCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartAttributeAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartAttributeResponse>> GetAllPartAttributesAsync()
        {
            var entities = await _repository.GetAllPartAttributesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartAttributeResponse?> GetPartAttributeByIdAsync(long id)
        {
            var entity = await _repository.GetPartAttributeByIdAsync(id) ?? throw new NotFoundException("PartAttribute with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartAttributeResponse> UpdatePartAttributeAsync(long id, PartAttributeUpdateRequest request)
        {
            var existing = await _repository.GetPartAttributeByIdAsync(id) ?? throw new NotFoundException("PartAttribute with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.Name = request.Name;
            existing.Value = request.Value;

            await _repository.UpdatePartAttributeAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartAttributeResponse> DeletePartAttributeAsync(long id)
        {
            var entity = await _repository.GetPartAttributeByIdAsync(id) ?? throw new NotFoundException("PartAttribute with ID " + id + " not found.");
            await _repository.DeletePartAttributeAsync(entity);
            return entity.ToDto();
        }
    }
}
