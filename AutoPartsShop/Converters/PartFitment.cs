using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class PartFitmentConverter
    {
        public static PartFitmentResponse ToDto(this PartFitmentEntity entity)
        {
            return new PartFitmentResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                VariantId: entity.VariantId,
                Fitment: entity.Fitment,
                Notes: entity.Notes
            );
        }

        public static PartFitmentEntity ToEntity(this PartFitmentCreateRequest dto)
        {
            return new PartFitmentEntity
            {
                PartId = dto.PartId,
                VariantId = dto.VariantId,
                Fitment = dto.Fitment,
                Notes = dto.Notes
            };
        }

        public static PartFitmentEntity ToEntity(this PartFitmentUpdateRequest dto)
        {
            return new PartFitmentEntity
            {
                PartId = dto.PartId,
                VariantId = dto.VariantId,
                Fitment = dto.Fitment,
                Notes = dto.Notes
            };
        }
    }
}
