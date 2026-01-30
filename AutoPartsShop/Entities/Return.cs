using AutoPartsShop.Enums;


namespace AutoPartsShop.Entities
{
    public class ReturnEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public ReturnStatus Status { get; set; }
        public int ShipmentId { get; set; }
        public string Reason { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime ProcessedAt { get; set; }
    }
}