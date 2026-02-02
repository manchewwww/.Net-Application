using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartImageService
    {
        public Task<PartImageResponse> AddPartImageAsync(PartImageCreateRequest request);
        public Task<IEnumerable<PartImageResponse>> GetAllPartImagesAsync();
        public Task<PartImageResponse?> GetPartImageByIdAsync(long id);
        public Task<PartImageResponse> UpdatePartImageAsync(long id, PartImageUpdateRequest request);
        public Task<PartImageResponse> DeletePartImageAsync(long id);
    }

    public class PartImageService : IPartImageService
    {
        private readonly IPartImageRepository _repository;

        public PartImageService(IPartImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartImageResponse> AddPartImageAsync(PartImageCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartImageAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartImageResponse>> GetAllPartImagesAsync()
        {
            var entities = await _repository.GetAllPartImagesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartImageResponse?> GetPartImageByIdAsync(long id)
        {
            var entity = await _repository.GetPartImageByIdAsync(id) ?? throw new NotFoundException("PartImage with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartImageResponse> UpdatePartImageAsync(long id, PartImageUpdateRequest request)
        {
            var existing = await _repository.GetPartImageByIdAsync(id) ?? throw new NotFoundException("PartImage with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.Url = request.Url;
            existing.SortOrder = request.SortOrder;

            await _repository.UpdatePartImageAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartImageResponse> DeletePartImageAsync(long id)
        {
            var entity = await _repository.GetPartImageByIdAsync(id) ?? throw new NotFoundException("PartImage with ID " + id + " not found.");
            await _repository.DeletePartImageAsync(entity);
            return entity.ToDto();
        }
    }
}
