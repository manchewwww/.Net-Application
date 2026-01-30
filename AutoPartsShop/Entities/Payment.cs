using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
        public int TransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}