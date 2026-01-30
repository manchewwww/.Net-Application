using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PaymentEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string? ProviderRef { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
