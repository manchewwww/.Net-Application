using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class CartConverter
    {
        public static CartResponse ToDto(this CartEntity entity)
        {
            return new CartResponse(
                Id: entity.Id,
                CustomerId: entity.CustomerId
            );
        }

        public static CartEntity ToEntity(this CartCreateRequest dto)
        {
            return new CartEntity
            {
                CustomerId = dto.CustomerId
            };
        }

        public static CartEntity ToEntity(this CartUpdateRequest dto)
        {
            return new CartEntity
            {
                CustomerId = dto.CustomerId
            };
        }
    }
}
