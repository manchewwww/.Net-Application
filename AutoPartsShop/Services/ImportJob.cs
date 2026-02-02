using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IImportJobService
    {
        public Task<ImportJobResponse> AddImportJobAsync(ImportJobCreateRequest request);
        public Task<IEnumerable<ImportJobResponse>> GetAllImportJobsAsync();
        public Task<ImportJobResponse?> GetImportJobByIdAsync(long id);
        public Task<ImportJobResponse> UpdateImportJobAsync(long id, ImportJobUpdateRequest request);
        public Task<ImportJobResponse> DeleteImportJobAsync(long id);
    }

    public class ImportJobService : IImportJobService
    {
        private readonly IImportJobRepository _repository;

        public ImportJobService(IImportJobRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImportJobResponse> AddImportJobAsync(ImportJobCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddImportJobAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<ImportJobResponse>> GetAllImportJobsAsync()
        {
            var entities = await _repository.GetAllImportJobsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<ImportJobResponse?> GetImportJobByIdAsync(long id)
        {
            var entity = await _repository.GetImportJobByIdAsync(id) ?? throw new NotFoundException("ImportJob with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<ImportJobResponse> UpdateImportJobAsync(long id, ImportJobUpdateRequest request)
        {
            var existing = await _repository.GetImportJobByIdAsync(id) ?? throw new NotFoundException("ImportJob with ID " + id + " not found.");
            existing.SupplierId = request.SupplierId;
            existing.Status = request.Status;
            existing.StartedAt = request.StartedAt;
            existing.FinishedAt = request.FinishedAt;
            existing.StatsJson = request.StatsJson;
            existing.ErrorMessage = request.ErrorMessage;

            await _repository.UpdateImportJobAsync(existing);
            return existing.ToDto();
        }

        public async Task<ImportJobResponse> DeleteImportJobAsync(long id)
        {
            var entity = await _repository.GetImportJobByIdAsync(id) ?? throw new NotFoundException("ImportJob with ID " + id + " not found.");
            await _repository.DeleteImportJobAsync(entity);
            return entity.ToDto();
        }
    }
}
