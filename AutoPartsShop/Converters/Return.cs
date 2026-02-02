using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class ReturnConverter
    {
        public static ReturnResponse ToDto(this ReturnEntity entity)
        {
            return new ReturnResponse(
                Id: entity.Id,
                OrderId: entity.OrderId,
                Status: entity.Status,
                Reason: entity.Reason
            );
        }

        public static ReturnEntity ToEntity(this ReturnCreateRequest dto)
        {
            return new ReturnEntity
            {
                OrderId = dto.OrderId,
                Status = dto.Status,
                Reason = dto.Reason
            };
        }

        public static ReturnEntity ToEntity(this ReturnUpdateRequest dto)
        {
            return new ReturnEntity
            {
                OrderId = dto.OrderId,
                Status = dto.Status,
                Reason = dto.Reason
            };
        }
    }
}
