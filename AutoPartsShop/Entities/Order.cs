using AutoPartsShop.Enums;

namespace AutoPartShop.Entities
{
    public class Order(int id, int orderNumber, int customerId, OrderStatus status, string currency, decimal shippingCost,
        decimal discountTotal, decimal subtotal, decimal taxTotal, decimal total, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int OrderNumber { get; set; } = orderNumber;
        public int CustomerId { get; set; } = customerId;
        public OrderStatus Status { get; set; } = status;
        public string Currency { get; set; } = currency;
        public decimal Subtotal { get; set; } = subtotal;
        public decimal ShippingCost { get; set; } = shippingCost;
        public decimal DiscountTotal { get; set; } = discountTotal;
        public decimal TaxTotal { get; set; } = taxTotal;
        public decimal Total { get; set; } = total;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    }
}