using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public required string Currency { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}