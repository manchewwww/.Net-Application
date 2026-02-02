using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class ImportJobConverter
    {
        public static ImportJobResponse ToDto(this ImportJobEntity entity)
        {
            return new ImportJobResponse(
                Id: entity.Id,
                SupplierId: entity.SupplierId,
                Status: entity.Status,
                StartedAt: entity.StartedAt,
                FinishedAt: entity.FinishedAt,
                StatsJson: entity.StatsJson,
                ErrorMessage: entity.ErrorMessage
            );
        }

        public static ImportJobEntity ToEntity(this ImportJobCreateRequest dto)
        {
            return new ImportJobEntity
            {
                SupplierId = dto.SupplierId,
                Status = dto.Status,
                StartedAt = dto.StartedAt,
                FinishedAt = dto.FinishedAt,
                StatsJson = dto.StatsJson,
                ErrorMessage = dto.ErrorMessage
            };
        }

        public static ImportJobEntity ToEntity(this ImportJobUpdateRequest dto)
        {
            return new ImportJobEntity
            {
                SupplierId = dto.SupplierId,
                Status = dto.Status,
                StartedAt = dto.StartedAt,
                FinishedAt = dto.FinishedAt,
                StatsJson = dto.StatsJson,
                ErrorMessage = dto.ErrorMessage
            };
        }
    }
}
