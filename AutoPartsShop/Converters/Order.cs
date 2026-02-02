using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class OrderConverter
    {
        public static OrderResponse ToDto(this OrderEntity entity)
        {
            return new OrderResponse(
                Id: entity.Id,
                OrderNumber: entity.OrderNumber,
                CustomerId: entity.CustomerId,
                Status: entity.Status,
                CurrencyId: entity.CurrencyId,
                Subtotal: entity.Subtotal,
                ShippingCost: entity.ShippingCost,
                DiscountTotal: entity.DiscountTotal,
                TaxTotal: entity.TaxTotal,
                GrandTotal: entity.GrandTotal,
                ShippingProvider: entity.ShippingProvider,
                DeliveryType: entity.DeliveryType,
                ShippingName: entity.ShippingName,
                ShippingPhone: entity.ShippingPhone,
                ShippingCountryId: entity.ShippingCountryId,
                ShippingCity: entity.ShippingCity,
                ShippingAddress1: entity.ShippingAddress1,
                ShippingAddress2: entity.ShippingAddress2,
                ShippingPostalCode: entity.ShippingPostalCode,
                ProviderLocationId: entity.ProviderLocationId,
                ProviderLocationName: entity.ProviderLocationName,
                BillingAddressSnapshot: entity.BillingAddressSnapshot
            );
        }

        public static OrderEntity ToEntity(this OrderCreateRequest dto)
        {
            return new OrderEntity
            {
                OrderNumber = dto.OrderNumber,
                CustomerId = dto.CustomerId,
                Status = dto.Status,
                CurrencyId = dto.CurrencyId,
                Subtotal = dto.Subtotal,
                ShippingCost = dto.ShippingCost,
                DiscountTotal = dto.DiscountTotal,
                TaxTotal = dto.TaxTotal,
                GrandTotal = dto.GrandTotal,
                ShippingProvider = dto.ShippingProvider,
                DeliveryType = dto.DeliveryType,
                ShippingName = dto.ShippingName,
                ShippingPhone = dto.ShippingPhone,
                ShippingCountryId = dto.ShippingCountryId,
                ShippingCity = dto.ShippingCity,
                ShippingAddress1 = dto.ShippingAddress1,
                ShippingAddress2 = dto.ShippingAddress2,
                ShippingPostalCode = dto.ShippingPostalCode,
                ProviderLocationId = dto.ProviderLocationId,
                ProviderLocationName = dto.ProviderLocationName,
                BillingAddressSnapshot = dto.BillingAddressSnapshot
            };
        }

        public static OrderEntity ToEntity(this OrderUpdateRequest dto)
        {
            return new OrderEntity
            {
                OrderNumber = dto.OrderNumber,
                CustomerId = dto.CustomerId,
                Status = dto.Status,
                CurrencyId = dto.CurrencyId,
                Subtotal = dto.Subtotal,
                ShippingCost = dto.ShippingCost,
                DiscountTotal = dto.DiscountTotal,
                TaxTotal = dto.TaxTotal,
                GrandTotal = dto.GrandTotal,
                ShippingProvider = dto.ShippingProvider,
                DeliveryType = dto.DeliveryType,
                ShippingName = dto.ShippingName,
                ShippingPhone = dto.ShippingPhone,
                ShippingCountryId = dto.ShippingCountryId,
                ShippingCity = dto.ShippingCity,
                ShippingAddress1 = dto.ShippingAddress1,
                ShippingAddress2 = dto.ShippingAddress2,
                ShippingPostalCode = dto.ShippingPostalCode,
                ProviderLocationId = dto.ProviderLocationId,
                ProviderLocationName = dto.ProviderLocationName,
                BillingAddressSnapshot = dto.BillingAddressSnapshot
            };
        }
    }
}
