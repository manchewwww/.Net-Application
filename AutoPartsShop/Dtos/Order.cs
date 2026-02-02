using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record OrderCreateRequest(string OrderNumber, long? CustomerId, OrderStatus Status, long CurrencyId, decimal Subtotal, decimal ShippingCost, decimal DiscountTotal, decimal TaxTotal, decimal GrandTotal, string ShippingProvider, DeliveryType DeliveryType, string ShippingName, string ShippingPhone, long ShippingCountryId, string ShippingCity, string ShippingAddress1, string? ShippingAddress2, string? ShippingPostalCode, string? ProviderLocationId, string? ProviderLocationName, string? BillingAddressSnapshot);

    public record OrderUpdateRequest(string OrderNumber, long? CustomerId, OrderStatus Status, long CurrencyId, decimal Subtotal, decimal ShippingCost, decimal DiscountTotal, decimal TaxTotal, decimal GrandTotal, string ShippingProvider, DeliveryType DeliveryType, string ShippingName, string ShippingPhone, long ShippingCountryId, string ShippingCity, string ShippingAddress1, string? ShippingAddress2, string? ShippingPostalCode, string? ProviderLocationId, string? ProviderLocationName, string? BillingAddressSnapshot);

    public record OrderResponse(long Id, string OrderNumber, long? CustomerId, OrderStatus Status, long CurrencyId, decimal Subtotal, decimal ShippingCost, decimal DiscountTotal, decimal TaxTotal, decimal GrandTotal, string ShippingProvider, DeliveryType DeliveryType, string ShippingName, string ShippingPhone, long ShippingCountryId, string ShippingCity, string ShippingAddress1, string? ShippingAddress2, string? ShippingPostalCode, string? ProviderLocationId, string? ProviderLocationName, string? BillingAddressSnapshot);
}
