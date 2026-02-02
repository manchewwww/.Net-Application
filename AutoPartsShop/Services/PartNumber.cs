using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartNumberService
    {
        public Task<PartNumberResponse> AddPartNumberAsync(PartNumberCreateRequest request);
        public Task<IEnumerable<PartNumberResponse>> GetAllPartNumbersAsync();
        public Task<PartNumberResponse?> GetPartNumberByIdAsync(long id);
        public Task<PartNumberResponse> UpdatePartNumberAsync(long id, PartNumberUpdateRequest request);
        public Task<PartNumberResponse> DeletePartNumberAsync(long id);
    }

    public class PartNumberService : IPartNumberService
    {
        private readonly IPartNumberRepository _repository;

        public PartNumberService(IPartNumberRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartNumberResponse> AddPartNumberAsync(PartNumberCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartNumberAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartNumberResponse>> GetAllPartNumbersAsync()
        {
            var entities = await _repository.GetAllPartNumbersAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartNumberResponse?> GetPartNumberByIdAsync(long id)
        {
            var entity = await _repository.GetPartNumberByIdAsync(id) ?? throw new NotFoundException("PartNumber with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartNumberResponse> UpdatePartNumberAsync(long id, PartNumberUpdateRequest request)
        {
            var existing = await _repository.GetPartNumberByIdAsync(id) ?? throw new NotFoundException("PartNumber with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.Type = request.Type;
            existing.Value = request.Value;

            await _repository.UpdatePartNumberAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartNumberResponse> DeletePartNumberAsync(long id)
        {
            var entity = await _repository.GetPartNumberByIdAsync(id) ?? throw new NotFoundException("PartNumber with ID " + id + " not found.");
            await _repository.DeletePartNumberAsync(entity);
            return entity.ToDto();
        }
    }
}
