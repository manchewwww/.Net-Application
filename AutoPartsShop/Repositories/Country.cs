using AutoPartsShop.Entities;
using Microsoft.EntityFrameworkCore;
using AutoPartsShop.Data;

namespace AutoPartsShop.Repositories
{
    public interface ICountryRepository
    {
        Task<CountryEntity?> GetCountryByIdAsync(long id);
        Task<List<CountryEntity>> GetAllCountriesAsync();
        Task<CountryEntity> AddCountryAsync(CountryEntity country);
        Task<CountryEntity> UpdateCountryAsync(CountryEntity country);
        Task DeleteCountryAsync(CountryEntity country);
    }

    public class CountryRepository : Repository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CountryEntity> AddCountryAsync(CountryEntity country)
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


    public class CountryRepo : ICountryRepository
    {
        private readonly AutoPartsShopDbContext context;
        private readonly DbSet<CountryEntity> dbSet;

        public CountryRepo(AutoPartsShopDbContext context)
        {
            this.context = context;
            dbSet = context.Set<CountryEntity>();
        }

        public async Task<CountryEntity?> GetCountryByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }


        public async Task<List<CountryEntity>> GetAllCountriesAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<CountryEntity> AddCountryAsync(CountryEntity country)
        {
            await dbSet.AddAsync(country);
            await context.SaveChangesAsync();
            return country;
        }

        public async Task<CountryEntity> UpdateCountryAsync(CountryEntity country)
        {
            dbSet.Update(country);
            await context.SaveChangesAsync();
            return country;
        }

        public async Task DeleteCountryAsync(CountryEntity country)
        {
            dbSet.Remove(country);
            await context.SaveChangesAsync();
        }
    }
}