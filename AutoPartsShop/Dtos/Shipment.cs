using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record ShipmentCreateRequest(long OrderId, string Carrier, string? TrackingNumber, ShipmentStatus Status, DateTime? ShippedAt, DateTime? DeliveredAt);

    public record ShipmentUpdateRequest(long OrderId, string Carrier, string? TrackingNumber, ShipmentStatus Status, DateTime? ShippedAt, DateTime? DeliveredAt);

    public record ShipmentResponse(long Id, long OrderId, string Carrier, string? TrackingNumber, ShipmentStatus Status, DateTime? ShippedAt, DateTime? DeliveredAt);
}
