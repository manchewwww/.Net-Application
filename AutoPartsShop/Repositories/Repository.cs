using AutoPartsShop.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Repositories
{
    public abstract class Repository<T> where T : class
    {
        protected readonly AutoPartsShopDbContext Context;
        protected readonly DbSet<T> DbSet;

        protected Repository(AutoPartsShopDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(long id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
