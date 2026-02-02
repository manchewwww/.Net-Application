using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartSupplierLinkConverter
    {
        public static PartSupplierLinkResponse ToDto(this PartSupplierLinkEntity entity)
        {
            return new PartSupplierLinkResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                SupplierPartId: entity.SupplierPartId,
                Priority: entity.Priority,
                IsPrimary: entity.IsPrimary
            );
        }

        public static PartSupplierLinkEntity ToEntity(this PartSupplierLinkCreateRequest dto)
        {
            return new PartSupplierLinkEntity
            {
                PartId = dto.PartId,
                SupplierPartId = dto.SupplierPartId,
                Priority = dto.Priority,
                IsPrimary = dto.IsPrimary
            };
        }

        public static PartSupplierLinkEntity ToEntity(this PartSupplierLinkUpdateRequest dto)
        {
            return new PartSupplierLinkEntity
            {
                PartId = dto.PartId,
                SupplierPartId = dto.SupplierPartId,
                Priority = dto.Priority,
                IsPrimary = dto.IsPrimary
            };
        }
    }
}
