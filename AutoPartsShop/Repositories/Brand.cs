using AutoPartsShop.Data;
using AutoPartsShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Repositories
{
    public interface IBrand
    {
        public Task<BrandEntity> AddBrandAsync(BrandEntity brand);
        public Task<IEnumerable<BrandEntity>> GetAllBrandsAsync();
        public Task<BrandEntity?> GetBrandByIdAsync(int id);
        public Task UpdateBrandAsync(BrandEntity brand);
        public Task DeleteBrandAsync(BrandEntity brand);
    }

    public class Brand : Repository<BrandEntity>, IBrand
    {

        public Brand(AutoPartsShopDbContext context) : base(context)
        {
        }

        public async Task<BrandEntity> AddBrandAsync(BrandEntity brand)
        {
            await AddAsync(brand);
            return brand;
        }

        public async Task<BrandEntity?> GetBrandByIdAsync(int id)
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
}