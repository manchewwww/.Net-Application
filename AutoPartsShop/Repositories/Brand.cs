using AutoPartsShop.Data;
using AutoPartsShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Repositories
{
    public interface IBrandRepository
    {
        public Task<BrandEntity> AddBrandAsync(BrandEntity brand);
        public Task<IEnumerable<BrandEntity>> GetAllBrandsAsync();
        public Task<BrandEntity?> GetBrandByIdAsync(long id);
        public Task UpdateBrandAsync(BrandEntity brand);
        public Task DeleteBrandAsync(BrandEntity brand);
    }

    public class BrandRepository : Repository<BrandEntity>, IBrandRepository
    {

        public BrandRepository(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<BrandEntity> AddBrandAsync(BrandEntity brand)
        {
            await AddAsync(brand);
            return brand;
        }

        public async Task<BrandEntity?> GetBrandByIdAsync(long id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BrandEntity>> GetAllBrandsAsync()
        {
            return await base.GetAllAsync();
        }

        public async Task UpdateBrandAsync(BrandEntity brand)
        {
            await base.UpdateAsync(brand);
        }

        public async Task DeleteBrandAsync(BrandEntity brand)
        {
            await base.DeleteAsync(brand);
        }
    }

    public class BrandRepo : IBrandRepository
    {
        private readonly AutoPartsShopDbContext context;
        private readonly DbSet<BrandEntity> dbSet;

        public BrandRepo(AutoPartsShopDbContext context)
        {
            this.context = context;
            dbSet = context.Set<BrandEntity>();
        }

        public async Task<BrandEntity> AddBrandAsync(BrandEntity brand)
        {
            await dbSet.AddAsync(brand);
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task<BrandEntity?> GetBrandByIdAsync(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<BrandEntity>> GetAllBrandsAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task UpdateBrandAsync(BrandEntity brand)
        {
            dbSet.Update(brand);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBrandAsync(BrandEntity brand)
        {
            dbSet.Remove(brand);
            await context.SaveChangesAsync();
        }
    }
}