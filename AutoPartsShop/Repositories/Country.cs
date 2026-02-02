using AutoPartsShop.Entities;
using Microsoft.EntityFrameworkCore;
using AutoPartsShop.Data;

namespace AutoPartsShop.Repositories
{
    public interface ICountryRepository
    {
        Task<CountryEntity?> GetCountryByIdAsync(long id);
        Task<List<CountryEntity>> GetAllCountriesAsync();
        Task<CountryEntity> CreateCountryAsync(CountryEntity country);
        Task<CountryEntity> UpdateCountryAsync(CountryEntity country);
        Task DeleteCountryAsync(CountryEntity country);
    }

    public class CountryRepository : Repository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CountryEntity> CreateCountryAsync(CountryEntity country)
        {
            await base.AddAsync(country);
            return country;
        }

        public async Task<CountryEntity?> GetCountryByIdAsync(long id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<List<CountryEntity>> GetAllCountriesAsync()
        {
            return (await base.GetAllAsync()).ToList();
        }

        public async Task<CountryEntity> UpdateCountryAsync(CountryEntity country)
        {
            await base.UpdateAsync(country);
            return country;
        }

        public async Task DeleteCountryAsync(CountryEntity country)
        {
            await base.DeleteAsync(country);
        }
    }
}