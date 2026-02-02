using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class SupplierPartNumberConverter
    {
        public static SupplierPartNumberResponse ToDto(this SupplierPartNumberEntity entity)
        {
            return new SupplierPartNumberResponse(
                Id: entity.Id,
                SupplierPartId: entity.SupplierPartId,
                Type: entity.Type,
                Value: entity.Value
            );
        }

        public static SupplierPartNumberEntity ToEntity(this SupplierPartNumberCreateRequest dto)
        {
            return new SupplierPartNumberEntity
            {
                SupplierPartId = dto.SupplierPartId,
                Type = dto.Type,
                Value = dto.Value
            };
        }

        public static SupplierPartNumberEntity ToEntity(this SupplierPartNumberUpdateRequest dto)
        {
            return new SupplierPartNumberEntity
            {
                SupplierPartId = dto.SupplierPartId,
                Type = dto.Type,
                Value = dto.Value
            };
        }
    }
}
