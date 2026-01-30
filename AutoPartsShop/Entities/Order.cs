using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class OrderEntity
    {
        public long Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public long? CustomerId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.NEW;
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal GrandTotal { get; set; }
        public string ShippingProvider { get; set; } = string.Empty;
        public DeliveryType DeliveryType { get; set; }
        public string ShippingName { get; set; } = string.Empty;
        public string ShippingPhone { get; set; } = string.Empty;
        public string ShippingCountryCode { get; set; } = string.Empty;
        public string ShippingCity { get; set; } = string.Empty;
        public string ShippingAddress1 { get; set; } = string.Empty;
        public string? ShippingAddress2 { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? ProviderLocationId { get; set; }
        public string? ProviderLocationName { get; set; }
        public string? BillingAddressSnapshot { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
