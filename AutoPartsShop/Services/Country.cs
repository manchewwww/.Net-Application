using AutoPartsShop.Dtos;
using AutoPartsShop.Entities;
using AutoPartsShop.Repositories;
using AutoPartsShop.Exceptions;
using AutoPartsShop.Converters;

namespace AutoPartsShop.Services
{
    public interface ICountryService
    {
        public Task<CountryResponse> CreateCountryAsync(CountryCreateRequest country);
        public Task<IEnumerable<CountryResponse>> GetAllCountriesAsync();
        public Task<CountryResponse?> GetCountryByIdAsync(long id);
        public Task<CountryResponse> UpdateCountryAsync(long id, CountryUpdateRequest country);
        public Task<CountryResponse> DeleteCountryAsync(long id);
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<CountryResponse> CreateCountryAsync(CountryCreateRequest request)
        {
            var countryEntity = request.ToEntity();
            var createdCountry = await _countryRepository.AddCountryAsync(countryEntity);
            return createdCountry.ToDto();
        }

        public async Task<IEnumerable<CountryResponse>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return countries.Select(c => c.ToDto());
        }

        public async Task<CountryResponse?> GetCountryByIdAsync(long id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id) ?? throw new NotFoundException($"Country with ID {id} not found.");
            return country?.ToDto();
        }

        public async Task<CountryResponse> UpdateCountryAsync(long id, CountryUpdateRequest request)
        {
            var existing = await _countryRepository.GetCountryByIdAsync(id) ?? throw new NotFoundException($"Country with ID {id} not found.");
            existing.Name = request.Name;
            existing.Code = request.Code;
            var updatedCountry = await _countryRepository.UpdateCountryAsync(existing);
            return updatedCountry.ToDto();
        }

        public async Task<CountryResponse> DeleteCountryAsync(long id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id) ?? throw new NotFoundException($"Country with ID {id} not found.");
            await _countryRepository.DeleteCountryAsync(country);
            return country.ToDto();
        }
    }
}