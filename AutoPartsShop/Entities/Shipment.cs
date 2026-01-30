using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class ShipmentEntity(int id, int orderId, string carrier, string trackingNumber, ShipmentStatus shipmentStatus, DateTime shippedAt, DateTime deliveredAt)
    {
        public int Id { get; set; } = id;
        public int OrderId { get; set; } = orderId;
        public string Carrier { get; set; } = carrier;
        public string TrackingNumber { get; set; } = trackingNumber;
        public ShipmentStatus ShipmentStatus { get; set; } = shipmentStatus;
        public DateTime ShippedAt { get; set; } = shippedAt;
        public DateTime DeliveredAt { get; set; } = deliveredAt;
    };
}