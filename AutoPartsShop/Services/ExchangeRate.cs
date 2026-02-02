using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface IExchangeRateService
    {
        public Task<ExchangeRateResponse> AddExchangeRateAsync(ExchangeRateCreateRequest request);
        public Task<IEnumerable<ExchangeRateResponse>> GetAllExchangeRatesAsync();
        public Task<ExchangeRateResponse?> GetExchangeRateByIdAsync(long id);
        public Task<ExchangeRateResponse> UpdateExchangeRateAsync(long id, ExchangeRateUpdateRequest request);
        public Task<ExchangeRateResponse> DeleteExchangeRateAsync(long id);
    }

    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateRepository _repository;

        public ExchangeRateService(IExchangeRateRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExchangeRateResponse> AddExchangeRateAsync(ExchangeRateCreateRequest request)
        {
            var entity = request.ToEntity();
            var created = await _repository.AddExchangeRateAsync(entity);
            return created.ToDto();
        }

        public async Task<IEnumerable<ExchangeRateResponse>> GetAllExchangeRatesAsync()
        {
            var entities = await _repository.GetAllExchangeRatesAsync();
            return entities.Select(e => e.ToDto());
        }

        public async Task<ExchangeRateResponse?> GetExchangeRateByIdAsync(long id)
        {
            var entity = await _repository.GetExchangeRateByIdAsync(id) ?? throw new NotFoundException("ExchangeRate with ID " + id + " not found.");
            return entity?.ToDto();
        }

        public async Task<ExchangeRateResponse> UpdateExchangeRateAsync(long id, ExchangeRateUpdateRequest request)
        {
            var existing = await _repository.GetExchangeRateByIdAsync(id) ?? throw new NotFoundException("ExchangeRate with ID " + id + " not found.");
            existing.BaseCurrencyId = request.BaseCurrencyId;
            existing.QuoteCurrencyId = request.QuoteCurrencyId;
            existing.Rate = request.Rate;
            existing.AsOf = request.AsOf;

            await _repository.UpdateExchangeRateAsync(existing);
            return existing.ToDto();
        }

        public async Task<ExchangeRateResponse> DeleteExchangeRateAsync(long id)
        {
            var entity = await _repository.GetExchangeRateByIdAsync(id) ?? throw new NotFoundException("ExchangeRate with ID " + id + " not found.");
            await _repository.DeleteExchangeRateAsync(entity);
            return entity.ToDto();
        }
    }
}
