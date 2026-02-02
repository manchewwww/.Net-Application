using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class WarehouseConverter
    {
        public static WarehouseResponse ToDto(this WarehouseEntity entity)
        {
            return new WarehouseResponse(
                Id: entity.Id,
                Name: entity.Name,
                CountryId: entity.CountryId,
                City: entity.City,
                Address1: entity.Address1,
                Address2: entity.Address2,
                Postcode: entity.Postcode
            );
        }

        public static WarehouseEntity ToEntity(this WarehouseCreateRequest dto)
        {
            return new WarehouseEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId,
                City = dto.City,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Postcode = dto.Postcode
            };
        }

        public static WarehouseEntity ToEntity(this WarehouseUpdateRequest dto)
        {
            return new WarehouseEntity
            {
                Name = dto.Name,
                CountryId = dto.CountryId,
                City = dto.City,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                Postcode = dto.Postcode
            };
        }
    }
}
