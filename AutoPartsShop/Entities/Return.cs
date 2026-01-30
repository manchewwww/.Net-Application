using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class ReturnEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public ReturnStatus Status { get; set; } = ReturnStatus.REQUESTED;
        public string? Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
