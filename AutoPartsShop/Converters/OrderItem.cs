using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class OrderItemConverter
    {
        public static OrderItemResponse ToDto(this OrderItemEntity entity)
        {
            return new OrderItemResponse(
                Id: entity.Id,
                OrderId: entity.OrderId,
                PartId: entity.PartId,
                SkuSnapshot: entity.SkuSnapshot,
                NameSnapshot: entity.NameSnapshot,
                UnitPrice: entity.UnitPrice,
                Qty: entity.Qty,
                LineTotal: entity.LineTotal
            );
        }

        public static OrderItemEntity ToEntity(this OrderItemCreateRequest dto)
        {
            return new OrderItemEntity
            {
                OrderId = dto.OrderId,
                PartId = dto.PartId,
                SkuSnapshot = dto.SkuSnapshot,
                NameSnapshot = dto.NameSnapshot,
                UnitPrice = dto.UnitPrice,
                Qty = dto.Qty,
                LineTotal = dto.LineTotal
            };
        }

        public static OrderItemEntity ToEntity(this OrderItemUpdateRequest dto)
        {
            return new OrderItemEntity
            {
                OrderId = dto.OrderId,
                PartId = dto.PartId,
                SkuSnapshot = dto.SkuSnapshot,
                NameSnapshot = dto.NameSnapshot,
                UnitPrice = dto.UnitPrice,
                Qty = dto.Qty,
                LineTotal = dto.LineTotal
            };
        }
    }
}
