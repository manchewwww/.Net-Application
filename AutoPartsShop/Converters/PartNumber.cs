using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartNumberConverter
    {
        public static PartNumberResponse ToDto(this PartNumberEntity entity)
        {
            return new PartNumberResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                Type: entity.Type,
                Value: entity.Value
            );
        }

        public static PartNumberEntity ToEntity(this PartNumberCreateRequest dto)
        {
            return new PartNumberEntity
            {
                PartId = dto.PartId,
                Type = dto.Type,
                Value = dto.Value
            };
        }

        public static PartNumberEntity ToEntity(this PartNumberUpdateRequest dto)
        {
            return new PartNumberEntity
            {
                PartId = dto.PartId,
                Type = dto.Type,
                Value = dto.Value
            };
        }
    }
}
