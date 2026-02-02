using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class VehicleMakeConverter
    {
        public static VehicleMakeResponse ToDto(this VehicleMakeEntity entity)
        {
            return new VehicleMakeResponse(
                Id: entity.Id,
                Name: entity.Name
            );
        }

        public static VehicleMakeEntity ToEntity(this VehicleMakeCreateRequest dto)
        {
            return new VehicleMakeEntity
            {
                Name = dto.Name
            };
        }

        public static VehicleMakeEntity ToEntity(this VehicleMakeUpdateRequest dto)
        {
            return new VehicleMakeEntity
            {
                Name = dto.Name
            };
        }
    }
}
