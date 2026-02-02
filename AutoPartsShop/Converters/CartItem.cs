using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class CartItemConverter
    {
        public static CartItemResponse ToDto(this CartItemEntity entity)
        {
            return new CartItemResponse(
                Id: entity.Id,
                CartId: entity.CartId,
                PartId: entity.PartId,
                Qty: entity.Qty
            );
        }

        public static CartItemEntity ToEntity(this CartItemCreateRequest dto)
        {
            return new CartItemEntity
            {
                CartId = dto.CartId,
                PartId = dto.PartId,
                Qty = dto.Qty
            };
        }

        public static CartItemEntity ToEntity(this CartItemUpdateRequest dto)
        {
            return new CartItemEntity
            {
                CartId = dto.CartId,
                PartId = dto.PartId,
                Qty = dto.Qty
            };
        }
    }
}
