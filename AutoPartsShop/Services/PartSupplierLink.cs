using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartSupplierLinkService
    {
        public Task<PartSupplierLinkResponse> AddPartSupplierLinkAsync(PartSupplierLinkCreateRequest request);
        public Task<IEnumerable<PartSupplierLinkResponse>> GetAllPartSupplierLinksAsync();
        public Task<PartSupplierLinkResponse?> GetPartSupplierLinkByIdAsync(long id);
        public Task<PartSupplierLinkResponse> UpdatePartSupplierLinkAsync(long id, PartSupplierLinkUpdateRequest request);
        public Task<PartSupplierLinkResponse> DeletePartSupplierLinkAsync(long id);
    }

    public class PartSupplierLinkService : IPartSupplierLinkService
    {
        private readonly IPartSupplierLinkRepository _repository;

        public PartSupplierLinkService(IPartSupplierLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartSupplierLinkResponse> AddPartSupplierLinkAsync(PartSupplierLinkCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartSupplierLinkAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartSupplierLinkResponse>> GetAllPartSupplierLinksAsync()
        {
            var entities = await _repository.GetAllPartSupplierLinksAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartSupplierLinkResponse?> GetPartSupplierLinkByIdAsync(long id)
        {
            var entity = await _repository.GetPartSupplierLinkByIdAsync(id) ?? throw new NotFoundException("PartSupplierLink with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartSupplierLinkResponse> UpdatePartSupplierLinkAsync(long id, PartSupplierLinkUpdateRequest request)
        {
            var existing = await _repository.GetPartSupplierLinkByIdAsync(id) ?? throw new NotFoundException("PartSupplierLink with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.SupplierPartId = request.SupplierPartId;
            existing.Priority = request.Priority;
            existing.IsPrimary = request.IsPrimary;

            await _repository.UpdatePartSupplierLinkAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartSupplierLinkResponse> DeletePartSupplierLinkAsync(long id)
        {
            var entity = await _repository.GetPartSupplierLinkByIdAsync(id) ?? throw new NotFoundException("PartSupplierLink with ID " + id + " not found.");
            await _repository.DeletePartSupplierLinkAsync(entity);
            return entity.ToDto();
        }
    }
}
