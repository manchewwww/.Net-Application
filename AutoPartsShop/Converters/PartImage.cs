using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartImageConverter
    {
        public static PartImageResponse ToDto(this PartImageEntity entity)
        {
            return new PartImageResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                Url: entity.Url,
                SortOrder: entity.SortOrder
            );
        }

        public static PartImageEntity ToEntity(this PartImageCreateRequest dto)
        {
            return new PartImageEntity
            {
                PartId = dto.PartId,
                Url = dto.Url,
                SortOrder = dto.SortOrder
            };
        }

        public static PartImageEntity ToEntity(this PartImageUpdateRequest dto)
        {
            return new PartImageEntity
            {
                PartId = dto.PartId,
                Url = dto.Url,
                SortOrder = dto.SortOrder
            };
        }
    }
}
