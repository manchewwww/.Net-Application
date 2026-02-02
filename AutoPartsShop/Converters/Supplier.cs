using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class SupplierConverter
    {
        public static SupplierResponse ToDto(this SupplierEntity entity)
        {
            return new SupplierResponse(
                Id: entity.Id,
                Name: entity.Name,
                CountryId: entity.CountryId,
                Email: entity.Email,
                Phone: entity.Phone,
                IsActive: entity.IsActive
            );
        }

        public static SupplierEntity ToEntity(this SupplierCreateRequest dto)
        {
            return new SupplierEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = dto.IsActive
            };
        }

        public static SupplierEntity ToEntity(this SupplierUpdateRequest dto)
        {
            return new SupplierEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId,
                Email = dto.Email,
                Phone = dto.Phone,
                IsActive = dto.IsActive
            };
        }
    }
}
