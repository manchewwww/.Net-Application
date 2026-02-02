using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IPriceListService
    {
        public Task<PriceListResponse> AddPriceListAsync(PriceListCreateRequest request);
        public Task<IEnumerable<PriceListResponse>> GetAllPriceListsAsync();
        public Task<PriceListResponse?> GetPriceListByIdAsync(long id);
        public Task<PriceListResponse> UpdatePriceListAsync(long id, PriceListUpdateRequest request);
        public Task<PriceListResponse> DeletePriceListAsync(long id);
    }

    public class PriceListService : IPriceListService
    {
        private readonly IPriceListRepository _repository;

        public PriceListService(IPriceListRepository repository)
        {
            _repository = repository;
        }

        public async Task<PriceListResponse> AddPriceListAsync(PriceListCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddPriceListAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<PriceListResponse>> GetAllPriceListsAsync()
        {
            var entities = await _repository.GetAllPriceListsAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<PriceListResponse?> GetPriceListByIdAsync(long id)
        {
            var entity = await _repository.GetPriceListByIdAsync(id) ?? throw new NotFoundException("PriceList with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<PriceListResponse> UpdatePriceListAsync(long id, PriceListUpdateRequest request)
        {
            var existing = await _repository.GetPriceListByIdAsync(id) ?? throw new NotFoundException("PriceList with ID " + id + " not found.");
            existing.Name = request.Name;
            existing.CurrencyId = request.CurrencyId;
            existing.CountryId = request.CountryId;
            existing.IsActive = request.IsActive;

            await _repository.UpdatePriceListAsync(existing);
            return existing.ToDto();
        }

        public async Task<PriceListResponse> DeletePriceListAsync(long id)
        {
            var entity = await _repository.GetPriceListByIdAsync(id) ?? throw new NotFoundException("PriceList with ID " + id + " not found.");
            await _repository.DeletePriceListAsync(entity);
            return entity.ToDto();
        }
    }
}
