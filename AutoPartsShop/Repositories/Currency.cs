using AutoPartsShop.Entities;
using AutoPartsShop.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Repositories
{
    public interface ICurrencyRepository
    {
        Task<CurrencyEntity> AddCurrencyAsync(CurrencyEntity currency);
        Task<CurrencyEntity?> GetCurrencyByIdAsync(long id);
        Task<IEnumerable<CurrencyEntity>> GetAllCurrencyAsync();
        Task<CurrencyEntity> UpdateCurrencyAsync(CurrencyEntity currency);
        Task DeleteCurrencyAsync(CurrencyEntity currency);
    }

    public class CurrencyRepository : Repository<CurrencyEntity>, ICurrencyRepository
    {
        public CurrencyRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<CurrencyEntity> AddCurrencyAsync(CurrencyEntity currency)
        {
            await AddAsync(currency);
            return currency;
        }

        public async Task<CurrencyEntity?> GetCurrencyByIdAsync(long id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CurrencyEntity>> GetAllCurrencyAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task<CurrencyEntity> UpdateCurrencyAsync(CurrencyEntity currency)
        {
            await base.UpdateAsync(currency);
            return currency;
        }

        public async Task DeleteCurrencyAsync(long id)
        {
            var currency = await GetCurrencyByIdAsync(id);
            if (currency != null)
            {
                await base.DeleteAsync(currency);
            }
        }
    }
}