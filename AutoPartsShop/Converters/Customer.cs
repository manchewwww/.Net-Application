using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class CustomerConverter
    {
        public static CustomerResponse ToDto(this CustomerEntity entity)
        {
            return new CustomerResponse(
                Id: entity.Id,
                Email: entity.Email,
                Phone: entity.Phone,
                IsAdmin: entity.IsAdmin
            );
        }

        public static CustomerEntity ToEntity(this CustomerCreateRequest dto)
        {
            return new CustomerEntity
            {
                Email = dto.Email,
                Phone = dto.Phone,
                IsAdmin = dto.IsAdmin
            };
        }

        public static CustomerEntity ToEntity(this CustomerUpdateRequest dto)
        {
            return new CustomerEntity
            {
                Email = dto.Email,
                Phone = dto.Phone,
                IsAdmin = dto.IsAdmin
            };
        }
    }
}
