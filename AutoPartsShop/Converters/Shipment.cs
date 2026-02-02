using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class ShipmentConverter
    {
        public static ShipmentResponse ToDto(this ShipmentEntity entity)
        {
            return new ShipmentResponse(
                Id: entity.Id,
                OrderId: entity.OrderId,
                Carrier: entity.Carrier,
                TrackingNumber: entity.TrackingNumber,
                Status: entity.Status,
                ShippedAt: entity.ShippedAt,
                DeliveredAt: entity.DeliveredAt
            );
        }

        public static ShipmentEntity ToEntity(this ShipmentCreateRequest dto)
        {
            return new ShipmentEntity
            {
                OrderId = dto.OrderId,
                Carrier = dto.Carrier,
                TrackingNumber = dto.TrackingNumber,
                Status = dto.Status,
                ShippedAt = dto.ShippedAt,
                DeliveredAt = dto.DeliveredAt
            };
        }

        public static ShipmentEntity ToEntity(this ShipmentUpdateRequest dto)
        {
            return new ShipmentEntity
            {
                OrderId = dto.OrderId,
                Carrier = dto.Carrier,
                TrackingNumber = dto.TrackingNumber,
                Status = dto.Status,
                ShippedAt = dto.ShippedAt,
                DeliveredAt = dto.DeliveredAt
            };
        }
    }
}
