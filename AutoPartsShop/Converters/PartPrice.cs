using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartPriceConverter
    {
        public static PartPriceResponse ToDto(this PartPriceEntity entity)
        {
            return new PartPriceResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                PriceListId: entity.PriceListId,
                ListPrice: entity.ListPrice,
                SalePrice: entity.SalePrice,
                ValidFrom: entity.ValidFrom,
                ValidTo: entity.ValidTo
            );
        }

        public static PartPriceEntity ToEntity(this PartPriceCreateRequest dto)
        {
            return new PartPriceEntity
            {
                PartId = dto.PartId,
                PriceListId = dto.PriceListId,
                ListPrice = dto.ListPrice,
                SalePrice = dto.SalePrice,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo
            };
        }

        public static PartPriceEntity ToEntity(this PartPriceUpdateRequest dto)
        {
            return new PartPriceEntity
            {
                PartId = dto.PartId,
                PriceListId = dto.PriceListId,
                ListPrice = dto.ListPrice,
                SalePrice = dto.SalePrice,
                ValidFrom = dto.ValidFrom,
                ValidTo = dto.ValidTo
            };
        }
    }
}
