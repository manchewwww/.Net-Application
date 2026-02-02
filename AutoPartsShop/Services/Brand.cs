using AutoPartsShop.Repositories;
using AutoPartsShop.Dtos;
using AutoPartsShop.Converters;
using AutoPartsShop.Exceptions;

namespace AutoPartsShop.Services
{

    public interface IBrandService
    {
        public Task<BrandResponse> AddBrandAsync(BrandCreateRequest brand);
        public Task<IEnumerable<BrandResponse>> GetAllBrandsAsync();
        public Task<BrandResponse?> GetBrandByIdAsync(long id);
        public Task<BrandResponse> UpdateBrandAsync(long id, BrandUpdateRequest brand);
        public Task<BrandResponse> DeleteBrandAsync(long id);
    }

    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandResponse> AddBrandAsync(BrandCreateRequest request)
        {
            var brand = request.ToEntity();
            var createdBrand = await _brandRepository.AddBrandAsync(brand);
            return createdBrand.ToDto();
        }

        public async Task<IEnumerable<BrandResponse>> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllBrandsAsync();
            return brands.Select(b => b.ToDto());
        }

        public async Task<BrandResponse?> GetBrandByIdAsync(long id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id) ?? throw new NotFoundException($"Brand with ID {id} not found.");
            return brand?.ToDto();
        }

        public async Task<BrandResponse> UpdateBrandAsync(long id, BrandUpdateRequest request)
        {
            var existing = await _brandRepository.GetBrandByIdAsync(id) ?? throw new NotFoundException($"Brand with ID {id} not found.");
            existing.Name = request.Name;
            existing.CountryId = request.CountryId;

            await _brandRepository.UpdateBrandAsync(existing);

            return existing.ToDto();
        }

        public async Task<BrandResponse> DeleteBrandAsync(long id)
        {
            var brand = await _brandRepository.GetBrandByIdAsync(id) ?? throw new NotFoundException($"Brand with ID {id} not found.");
            await _brandRepository.DeleteBrandAsync(brand);
            return brand.ToDto();
        }
    }
}