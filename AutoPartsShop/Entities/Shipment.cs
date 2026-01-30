using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class ShipmentEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Carrier { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public ShipmentStatus Status { get; set; } = ShipmentStatus.CREATED;
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
