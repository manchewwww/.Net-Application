using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class ShipmentEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Carrier { get; set; } = null!;
        public string TrackingNumber { get; set; } = null!;
        public ShipmentStatus ShipmentStatus { get; set; }
        public DateTime ShippedAt { get; set; }
        public DateTime DeliveredAt { get; set; }
    };
}