using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class VehicleModelConverter
    {
        public static VehicleModelResponse ToDto(this VehicleModelEntity entity)
        {
            return new VehicleModelResponse(
                Id: entity.Id,
                MakeId: entity.MakeId,
                Name: entity.Name
            );
        }

        public static VehicleModelEntity ToEntity(this VehicleModelCreateRequest dto)
        {
            return new VehicleModelEntity
            {
                MakeId = dto.MakeId,
                Name = dto.Name
            };
        }

        public static VehicleModelEntity ToEntity(this VehicleModelUpdateRequest dto)
        {
            return new VehicleModelEntity
            {
                MakeId = dto.MakeId,
                Name = dto.Name
            };
        }
    }
}
