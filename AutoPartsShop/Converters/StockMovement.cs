using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class StockMovementConverter
    {
        public static StockMovementResponse ToDto(this StockMovementEntity entity)
        {
            return new StockMovementResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                WarehouseId: entity.WarehouseId,
                Type: entity.Type,
                QtyChange: entity.QtyChange,
                ReferenceType: entity.ReferenceType,
                ReferenceId: entity.ReferenceId,
                Note: entity.Note
            );
        }

        public static StockMovementEntity ToEntity(this StockMovementCreateRequest dto)
        {
            return new StockMovementEntity
            {
                PartId = dto.PartId,
                WarehouseId = dto.WarehouseId,
                Type = dto.Type,
                QtyChange = dto.QtyChange,
                ReferenceType = dto.ReferenceType,
                ReferenceId = dto.ReferenceId,
                Note = dto.Note
            };
        }

        public static StockMovementEntity ToEntity(this StockMovementUpdateRequest dto)
        {
            return new StockMovementEntity
            {
                PartId = dto.PartId,
                WarehouseId = dto.WarehouseId,
                Type = dto.Type,
                QtyChange = dto.QtyChange,
                ReferenceType = dto.ReferenceType,
                ReferenceId = dto.ReferenceId,
                Note = dto.Note
            };
        }
    }
}
