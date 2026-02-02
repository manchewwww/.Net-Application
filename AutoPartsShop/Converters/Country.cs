using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class CountryConverter
    {
        public static CountryResponse ToDto(this CountryEntity entity)
        {
            return new CountryResponse(
                Id: entity.Id,
                Name: entity.Name,
                Code: entity.Code
            );
        }

        public static CountryEntity ToEntity(this CountryCreateRequest dto)
        {
            return new CountryEntity
            {
                Name = dto.Name,
                Code = dto.Code
            };
        }

        public static CountryEntity ToEntity(this CountryUpdateRequest dto)
        {
            return new CountryEntity
            {
                Name = dto.Name,
                Code = dto.Code
            };
        }
    }
}