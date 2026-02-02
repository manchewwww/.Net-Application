using AutoPartsShop.Dtos;
using AutoPartsShop.Entities;

namespace AutoPartsShop.Converters
{
    public static class CurrencyConverter
    {
        public static CurrencyResponse ToDto(this CurrencyEntity entity)
        {
            return new CurrencyResponse(
                Id: entity.Id,
                CurrencyCode: entity.CurrencyCode,
                Name: entity.Name,
                Symbol: entity.Symbol
            );
        }

        public static CurrencyEntity ToEntity(this CurrencyCreateRequest dto)
        {
            return new CurrencyEntity
            {
                CurrencyCode = dto.CurrencyCode,
                Name = dto.Name,
                Symbol = dto.Symbol
            };
        }

        public static CurrencyEntity ToEntity(this CurrencyUpdateRequest dto)
        {
            return new CurrencyEntity
            {
                CurrencyCode = dto.CurrencyCode,
                Name = dto.Name,
                Symbol = dto.Symbol
            };
        }
    }
}