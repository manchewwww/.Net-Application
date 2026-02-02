using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class VehicleVariantConverter
    {
        public static VehicleVariantResponse ToDto(this VehicleVariantEntity entity)
        {
            return new VehicleVariantResponse(
                Id: entity.Id,
                ModelId: entity.ModelId,
                YearFrom: entity.YearFrom,
                YearTo: entity.YearTo,
                EngineCode: entity.EngineCode,
                Notes: entity.Notes
            );
        }

        public static VehicleVariantEntity ToEntity(this VehicleVariantCreateRequest dto)
        {
            return new VehicleVariantEntity
            {
                ModelId = dto.ModelId,
                YearFrom = dto.YearFrom,
                YearTo = dto.YearTo,
                EngineCode = dto.EngineCode,
                Notes = dto.Notes
            };
        }

        public static VehicleVariantEntity ToEntity(this VehicleVariantUpdateRequest dto)
        {
            return new VehicleVariantEntity
            {
                ModelId = dto.ModelId,
                YearFrom = dto.YearFrom,
                YearTo = dto.YearTo,
                EngineCode = dto.EngineCode,
                Notes = dto.Notes
            };
        }
    }
}
