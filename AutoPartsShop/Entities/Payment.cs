using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class PaymentEntity(int id, int orderId, PaymentProvider paymentProvider, int transactionId, PaymentStatus status, decimal amount,
        DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int OrderId { get; set; } = orderId;
        public PaymentProvider PaymentProvider { get; set; } = paymentProvider;
        public int TransactionId { get; set; } = transactionId;
        public PaymentStatus Status { get; set; } = status;
        public decimal Amount { get; set; } = amount;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    }
}