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
                CountryId: entity.CountryId
            );
        }

        public static BrandEntity ToEntity(this BrandCreateRequest dto)
        {
            return new BrandEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId
            };
        }

        public static BrandEntity ToEntity(this BrandUpdateRequest dto)
        {
            return new BrandEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId
            };
        }
    }
}