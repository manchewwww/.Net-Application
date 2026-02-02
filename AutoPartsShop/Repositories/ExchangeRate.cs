using AutoPartsShop.Data;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Repositories
{
    public interface IExchangeRateRepository
    {
        public Task<ExchangeRateEntity> AddExchangeRateAsync(ExchangeRateEntity entity);
        public Task<IEnumerable<ExchangeRateEntity>> GetAllExchangeRatesAsync();
        public Task<ExchangeRateEntity?> GetExchangeRateByIdAsync(long id);
        public Task UpdateExchangeRateAsync(ExchangeRateEntity entity);
        public Task DeleteExchangeRateAsync(ExchangeRateEntity entity);
    }

    public class ExchangeRateRepository : Repository<ExchangeRateEntity>, IExchangeRateRepository
    {
        public ExchangeRateRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<ExchangeRateEntity> AddExchangeRateAsync(ExchangeRateEntity entity)
        {
            await AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<ExchangeRateEntity>> GetAllExchangeRatesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<ExchangeRateEntity?> GetExchangeRateByIdAsync(long id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateExchangeRateAsync(ExchangeRateEntity entity)
        {
            await UpdateAsync(entity);
        }

        public async Task DeleteExchangeRateAsync(ExchangeRateEntity entity)
        {
            await DeleteAsync(entity);
        }
    }
}
