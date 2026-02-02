using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PaymentConverter
    {
        public static PaymentResponse ToDto(this PaymentEntity entity)
        {
            return new PaymentResponse(
                Id: entity.Id,
                OrderId: entity.OrderId,
                Provider: entity.Provider,
                ProviderRef: entity.ProviderRef,
                Status: entity.Status,
                Amount: entity.Amount
            );
        }

        public static PaymentEntity ToEntity(this PaymentCreateRequest dto)
        {
            return new PaymentEntity
            {
                OrderId = dto.OrderId,
                Provider = dto.Provider,
                ProviderRef = dto.ProviderRef,
                Status = dto.Status,
                Amount = dto.Amount
            };
        }

        public static PaymentEntity ToEntity(this PaymentUpdateRequest dto)
        {
            return new PaymentEntity
            {
                OrderId = dto.OrderId,
                Provider = dto.Provider,
                ProviderRef = dto.ProviderRef,
                Status = dto.Status,
                Amount = dto.Amount
            };
        }
    }
}
