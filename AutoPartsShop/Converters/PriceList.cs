using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PriceListConverter
    {
        public static PriceListResponse ToDto(this PriceListEntity entity)
        {
            return new PriceListResponse(
                Id: entity.Id,
                Name: entity.Name,
                CurrencyId: entity.CurrencyId,
                CountryId: entity.CountryId,
                IsActive: entity.IsActive
            );
        }

        public static PriceListEntity ToEntity(this PriceListCreateRequest dto)
        {
            return new PriceListEntity
            {
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
                CountryId = dto.CountryId,
                IsActive = dto.IsActive
            };
        }

        public static PriceListEntity ToEntity(this PriceListUpdateRequest dto)
        {
            return new PriceListEntity
            {
                Name = dto.Name,
                CurrencyId = dto.CurrencyId,
                CountryId = dto.CountryId,
                IsActive = dto.IsActive
            };
        }
    }
}
