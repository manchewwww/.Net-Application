using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class ExchangeRateConverter
    {
        public static ExchangeRateResponse ToDto(this ExchangeRateEntity entity)
        {
            return new ExchangeRateResponse(
                Id: entity.Id,
                BaseCurrencyId: entity.BaseCurrencyId,
                QuoteCurrencyId: entity.QuoteCurrencyId,
                Rate: entity.Rate,
                AsOf: entity.AsOf
            );
        }

        public static ExchangeRateEntity ToEntity(this ExchangeRateCreateRequest dto)
        {
            return new ExchangeRateEntity
            {
                BaseCurrencyId = dto.BaseCurrencyId,
                QuoteCurrencyId = dto.QuoteCurrencyId,
                Rate = dto.Rate,
                AsOf = dto.AsOf
            };
        }

        public static ExchangeRateEntity ToEntity(this ExchangeRateUpdateRequest dto)
        {
            return new ExchangeRateEntity
            {
                BaseCurrencyId = dto.BaseCurrencyId,
                QuoteCurrencyId = dto.QuoteCurrencyId,
                Rate = dto.Rate,
                AsOf = dto.AsOf
            };
        }
    }
}
