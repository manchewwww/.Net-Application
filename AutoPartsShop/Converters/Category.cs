using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class CategoryConverter
    {
        public static CategoryResponse ToDto(this CategoryEntity entity)
        {
            return new CategoryResponse(
                Id: entity.Id,
                ParentCategoryId: entity.ParentCategoryId,
                Name: entity.Name,
                Slug: entity.Slug
            );
        }

        public static CategoryEntity ToEntity(this CategoryCreateRequest dto)
        {
            return new CategoryEntity
            {
                ParentCategoryId = dto.ParentCategoryId,
                Name = dto.Name,
                Slug = dto.Slug
            };
        }

        public static CategoryEntity ToEntity(this CategoryUpdateRequest dto)
        {
            return new CategoryEntity
            {
                ParentCategoryId = dto.ParentCategoryId,
                Name = dto.Name,
                Slug = dto.Slug
            };
        }
    }
}
