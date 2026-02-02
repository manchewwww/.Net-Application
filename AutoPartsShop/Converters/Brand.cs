using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class BrandConverter
    {
        public static BrandResponse ToDto(this BrandEntity entity)
        {
            return new BrandResponse(
                Id: (int)entity.Id,
                Name: entity.Name,
                CountryCode: entity.CountryCode ?? string.Empty
            );
        }

        public static BrandEntity ToEntity(this BrandCreateRequest dto)
        {
            return new BrandEntity
            {
                Name = dto.Name,
                CountryCode = dto.CountryCode
            };
        }

        public static BrandEntity ToEntity(this BrandUpdateRequest dto)
        {
            return new BrandEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                CountryCode = dto.CountryCode
            };
        }
    }
}