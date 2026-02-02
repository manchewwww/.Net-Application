using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class ReturnItemConverter
    {
        public static ReturnItemResponse ToDto(this ReturnItemEntity entity)
        {
            return new ReturnItemResponse(
                Id: entity.Id,
                ReturnId: entity.ReturnId,
                OrderItemId: entity.OrderItemId,
                Qty: entity.Qty,
                Condition: entity.Condition,
                RefundAmount: entity.RefundAmount
            );
        }

        public static ReturnItemEntity ToEntity(this ReturnItemCreateRequest dto)
        {
            return new ReturnItemEntity
            {
                ReturnId = dto.ReturnId,
                OrderItemId = dto.OrderItemId,
                Qty = dto.Qty,
                Condition = dto.Condition,
                RefundAmount = dto.RefundAmount
            };
        }

        public static ReturnItemEntity ToEntity(this ReturnItemUpdateRequest dto)
        {
            return new ReturnItemEntity
            {
                ReturnId = dto.ReturnId,
                OrderItemId = dto.OrderItemId,
                Qty = dto.Qty,
                Condition = dto.Condition,
                RefundAmount = dto.RefundAmount
            };
        }
    }
}
