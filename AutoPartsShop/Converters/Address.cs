using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class AddressConverter
    {
        public static AddressResponse ToDto(this AddressEntity entity)
        {
            return new AddressResponse(
                Id: entity.Id,
                CustomerId: entity.CustomerId,
                Type: entity.Type,
                Name: entity.Name,
                Line1: entity.Line1,
                Line2: entity.Line2,
                City: entity.City,
                Region: entity.Region,
                PostalCode: entity.PostalCode,
                CountryId: entity.CountryId,
                IsDefault: entity.IsDefault
            );
        }

        public static AddressEntity ToEntity(this AddressCreateRequest dto)
        {
            return new AddressEntity
            {
                CustomerId = dto.CustomerId,
                Type = dto.Type,
                Name = dto.Name,
                Line1 = dto.Line1,
                Line2 = dto.Line2,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                CountryId = dto.CountryId,
                IsDefault = dto.IsDefault
            };
        }

        public static AddressEntity ToEntity(this AddressUpdateRequest dto)
        {
            return new AddressEntity
            {
                CustomerId = dto.CustomerId,
                Type = dto.Type,
                Name = dto.Name,
                Line1 = dto.Line1,
                Line2 = dto.Line2,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                CountryId = dto.CountryId,
                IsDefault = dto.IsDefault
            };
        }
    }
}
