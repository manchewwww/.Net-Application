using AutoPartsShop.Repositories;

namespace AutoPartsShop.Services
{

    public interface IBrandService
    {
        public Task<Entities.BrandEntity> AddBrandAsync(Entities.BrandEntity brand);
        public Task<IEnumerable<Entities.BrandEntity>> GetAllBrandsAsync();
        public Task<Entities.BrandEntity?> GetBrandByIdAsync(int id);
        public Task UpdateBrandAsync(Entities.BrandEntity brand);
        public Task DeleteBrandAsync(Entities.BrandEntity brand);
    }

    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Entities.BrandEntity> AddBrandAsync(Entities.BrandEntity brand)
        {
            return await _brandRepository.AddBrandAsync(brand);
        }

        public async Task<IEnumerable<Entities.BrandEntity>> GetAllBrandsAsync()
        {
            return await _brandRepository.GetAllBrandsAsync();
        }

        public async Task<Entities.BrandEntity?> GetBrandByIdAsync(int id)
        {
            return await _brandRepository.GetBrandByIdAsync(id);
        }

        public async Task UpdateBrandAsync(Entities.BrandEntity brand)
        {
            await _brandRepository.UpdateBrandAsync(brand);
        }

        public async Task DeleteBrandAsync(Entities.BrandEntity brand)
        {
            await _brandRepository.DeleteBrandAsync(brand);
        }
    }
}