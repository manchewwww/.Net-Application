using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartAttributeConverter
    {
        public static PartAttributeResponse ToDto(this PartAttributeEntity entity)
        {
            return new PartAttributeResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                Name: entity.Name,
                Value: entity.Value
            );
        }

        public static PartAttributeEntity ToEntity(this PartAttributeCreateRequest dto)
        {
            return new PartAttributeEntity
            {
                PartId = dto.PartId,
                Name = dto.Name,
                Value = dto.Value
            };
        }

        public static PartAttributeEntity ToEntity(this PartAttributeUpdateRequest dto)
        {
            return new PartAttributeEntity
            {
                PartId = dto.PartId,
                Name = dto.Name,
                Value = dto.Value
            };
        }
    }
}
