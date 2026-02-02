using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IReturnService
    {
        public Task<ReturnResponse> AddReturnAsync(ReturnCreateRequest request);
        public Task<IEnumerable<ReturnResponse>> GetAllReturnsAsync();
        public Task<ReturnResponse?> GetReturnByIdAsync(long id);
        public Task<ReturnResponse> UpdateReturnAsync(long id, ReturnUpdateRequest request);
        public Task<ReturnResponse> DeleteReturnAsync(long id);
    }

    public class ReturnService : IReturnService
    {
        private readonly IReturnRepository _repository;

        public ReturnService(IReturnRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReturnResponse> AddReturnAsync(ReturnCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddReturnAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<ReturnResponse>> GetAllReturnsAsync()
        {
            var entities = await _repository.GetAllReturnsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<ReturnResponse?> GetReturnByIdAsync(long id)
        {
            var entity = await _repository.GetReturnByIdAsync(id) ?? throw new NotFoundException("Return with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<ReturnResponse> UpdateReturnAsync(long id, ReturnUpdateRequest request)
        {
            var existing = await _repository.GetReturnByIdAsync(id) ?? throw new NotFoundException("Return with ID " + id + " not found.");
            existing.OrderId = request.OrderId;
            existing.Status = request.Status;
            existing.Reason = request.Reason;

            await _repository.UpdateReturnAsync(existing);
            return existing.ToDto();
        }

        public async Task<ReturnResponse> DeleteReturnAsync(long id)
        {
            var entity = await _repository.GetReturnByIdAsync(id) ?? throw new NotFoundException("Return with ID " + id + " not found.");
            await _repository.DeleteReturnAsync(entity);
            return entity.ToDto();
        }
    }
}
