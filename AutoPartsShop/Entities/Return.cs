using AutoPartsShop.Enums;


namespace AutoPartsShop.Entities
{
    public class ReturnEntity(int id, int orderId, ReturnStatus status, int shipmentId, string reason, DateTime createdAt, DateTime processedAt)
    {
        public int Id { get; set; } = id;
        public int OrderId { get; set; } = orderId;
        public ReturnStatus Status { get; set; } = status;
        public int ShipmentId { get; set; } = shipmentId;
        public string Reason { get; set; } = reason;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime ProcessedAt { get; set; } = processedAt;
    }
}