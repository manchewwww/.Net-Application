using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPartPriceService
    {
        public Task<PartPriceResponse> AddPartPriceAsync(PartPriceCreateRequest request);
        public Task<IEnumerable<PartPriceResponse>> GetAllPartPricesAsync();
        public Task<PartPriceResponse?> GetPartPriceByIdAsync(long id);
        public Task<PartPriceResponse> UpdatePartPriceAsync(long id, PartPriceUpdateRequest request);
        public Task<PartPriceResponse> DeletePartPriceAsync(long id);
    }

    public class PartPriceService : IPartPriceService
    {
        private readonly IPartPriceRepository _repository;

        public PartPriceService(IPartPriceRepository repository)
        {
            _repository = repository;
        }

        public async Task<PartPriceResponse> AddPartPriceAsync(PartPriceCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPartPriceAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PartPriceResponse>> GetAllPartPricesAsync()
        {
            var entities = await _repository.GetAllPartPricesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PartPriceResponse?> GetPartPriceByIdAsync(long id)
        {
            var entity = await _repository.GetPartPriceByIdAsync(id) ?? throw new NotFoundException("PartPrice with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PartPriceResponse> UpdatePartPriceAsync(long id, PartPriceUpdateRequest request)
        {
            var existing = await _repository.GetPartPriceByIdAsync(id) ?? throw new NotFoundException("PartPrice with ID " + id + " not found.");
            existing.PartId = request.PartId;
            existing.PriceListId = request.PriceListId;
            existing.ListPrice = request.ListPrice;
            existing.SalePrice = request.SalePrice;
            existing.ValidFrom = request.ValidFrom;
            existing.ValidTo = request.ValidTo;

            await _repository.UpdatePartPriceAsync(existing);
            return existing.ToDto();
        }

        public async Task<PartPriceResponse> DeletePartPriceAsync(long id)
        {
            var entity = await _repository.GetPartPriceByIdAsync(id) ?? throw new NotFoundException("PartPrice with ID " + id + " not found.");
            await _repository.DeletePartPriceAsync(entity);
            return entity.ToDto();
        }
    }
}
