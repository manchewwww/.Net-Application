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

        public async Task DeleteCurrencyAsync(CurrencyEntity currency)
        {
            await base.DeleteAsync(currency);
        }
    }

    public class CurrencyRepo : ICurrencyRepository
    {
        private readonly AutoPartsShopDbContext context;
        private readonly DbSet<CurrencyEntity> dbSet;

        public CurrencyRepo(AutoPartsShopDbContext context)
        {
            this.context = context;
            dbSet = context.Set<CurrencyEntity>();
        }

        public async Task<CurrencyEntity> AddCurrencyAsync(CurrencyEntity currency)
        {
            await dbSet.AddAsync(currency);
            await context.SaveChangesAsync();
            return currency;
        }

        public async Task<CurrencyEntity?> GetCurrencyByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<CurrencyEntity>> GetAllCurrencyAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<CurrencyEntity> UpdateCurrencyAsync(CurrencyEntity currency)
        {
            dbSet.Update(currency);
            await context.SaveChangesAsync();
            return currency;
        }

        public async Task DeleteCurrencyAsync(CurrencyEntity currency)
        {
            dbSet.Remove(currency);
            await context.SaveChangesAsync();
        }
    }
}