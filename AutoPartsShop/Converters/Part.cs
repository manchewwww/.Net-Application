using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartConverter
    {
        public static PartResponse ToDto(this PartEntity entity)
        {
            return new PartResponse(
                Id: entity.Id,
                Sku: entity.Sku,
                BrandId: entity.BrandId,
                CategoryId: entity.CategoryId,
                Name: entity.Name,
                Description: entity.Description,
                IsActive: entity.IsActive,
                WeightKg: entity.WeightKg
            );
        }

        public static PartEntity ToEntity(this PartCreateRequest dto)
        {
            return new PartEntity
            {
                Sku = dto.Sku,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                WeightKg = dto.WeightKg
            };
        }

        public static PartEntity ToEntity(this PartUpdateRequest dto)
        {
            return new PartEntity
            {
                Sku = dto.Sku,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
                WeightKg = dto.WeightKg
            };
        }
    }
}
