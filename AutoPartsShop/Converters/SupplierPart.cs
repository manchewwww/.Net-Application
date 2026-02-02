using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class SupplierPartConverter
    {
        public static SupplierPartResponse ToDto(this SupplierPartEntity entity)
        {
            return new SupplierPartResponse(
                Id: entity.Id,
                SupplierId: entity.SupplierId,
                SupplierSku: entity.SupplierSku,
                Name: entity.Name,
                BrandName: entity.BrandName,
                Cost: entity.Cost,
                CurrencyId: entity.CurrencyId,
                LeadTimeDays: entity.LeadTimeDays,
                LastImportedAt: entity.LastImportedAt
            );
        }

        public static SupplierPartEntity ToEntity(this SupplierPartCreateRequest dto)
        {
            return new SupplierPartEntity
            {
                SupplierId = dto.SupplierId,
                SupplierSku = dto.SupplierSku,
                Name = dto.Name,
                BrandName = dto.BrandName,
                Cost = dto.Cost,
                CurrencyId = dto.CurrencyId,
                LeadTimeDays = dto.LeadTimeDays,
                LastImportedAt = dto.LastImportedAt
            };
        }

        public static SupplierPartEntity ToEntity(this SupplierPartUpdateRequest dto)
        {
            return new SupplierPartEntity
            {
                SupplierId = dto.SupplierId,
                SupplierSku = dto.SupplierSku,
                Name = dto.Name,
                BrandName = dto.BrandName,
                Cost = dto.Cost,
                CurrencyId = dto.CurrencyId,
                LeadTimeDays = dto.LeadTimeDays,
                LastImportedAt = dto.LastImportedAt
            };
        }
    }
}
