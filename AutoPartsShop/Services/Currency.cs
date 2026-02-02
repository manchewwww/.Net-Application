using AutoPartsShop.Converters;
using AutoPartsShop.Dtos;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{
    public interface ICurrencyService
    {
        public Task<CurrencyResponse> AddCurrencyAsync(CurrencyCreateRequest request);
        public Task<IEnumerable<CurrencyResponse>> GetAllCurrenciesAsync();
        public Task<CurrencyResponse?> GetCurrencyByIdAsync(long id);
        public Task<CurrencyResponse> UpdateCurrencyAsync(long id, CurrencyUpdateRequest request);
        public Task<CurrencyResponse> DeleteCurrencyAsync(long id);
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public async Task<CurrencyResponse> AddCurrencyAsync(CurrencyCreateRequest request)
        {
            var currencyEntity = request.ToEntity();
            var createdCurrency = await _currencyRepository.AddCurrencyAsync(currencyEntity);
            return createdCurrency.ToDto();
        }

        public async Task<IEnumerable<CurrencyResponse>> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyRepository.GetAllCurrencyAsync();
            return currencies.Select(c => c.ToDto());
        }

        public async Task<CurrencyResponse?> GetCurrencyByIdAsync(long id)
        {
            var currency = await _currencyRepository.GetCurrencyByIdAsync(id) ?? throw new NotFoundException($"Currency with ID {id} not found.");
            return currency?.ToDto();
        }

        public async Task<CurrencyResponse> UpdateCurrencyAsync(long id, CurrencyUpdateRequest request)
        {
            var existing = await _currencyRepository.GetCurrencyByIdAsync(id) ?? throw new NotFoundException($"Currency with ID {id} not found.");
            existing.Code = request.Code;
            existing.Name = request.Name;
            existing.Symbol = request.Symbol;

            await _currencyRepository.UpdateCurrencyAsync(existing);
            return existing.ToDto();
        }

        public async Task<CurrencyResponse> DeleteCurrencyAsync(long id)
        {
            var currency = await _currencyRepository.GetCurrencyByIdAsync(id) ?? throw new NotFoundException($"Currency with ID {id} not found.");
            await _currencyRepository.DeleteCurrencyAsync(currency);
            return currency.ToDto();
        }
    }

}