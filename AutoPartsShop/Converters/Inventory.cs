using AutoPartsShop.Entities;
using AutoPartsShop.Dtos;

namespace AutoPartsShop.Converters
{
    public static class InventoryConverter
    {
        public static InventoryResponse ToDto(this InventoryEntity entity)
        {
            return new InventoryResponse(
                Id: entity.Id,
                PartId: entity.PartId,
                WarehouseId: entity.WarehouseId,
                QtyOnHand: entity.QtyOnHand,
                QtyReserved: entity.QtyReserved,
                ReorderPoint: entity.ReorderPoint
            );
        }

        public static InventoryEntity ToEntity(this InventoryCreateRequest dto)
        {
            return new InventoryEntity
            {
                PartId = dto.PartId,
                WarehouseId = dto.WarehouseId,
                QtyOnHand = dto.QtyOnHand,
                QtyReserved = dto.QtyReserved,
                ReorderPoint = dto.ReorderPoint
            };
        }

        public static InventoryEntity ToEntity(this InventoryUpdateRequest dto)
        {
            return new InventoryEntity
            {
                PartId = dto.PartId,
                WarehouseId = dto.WarehouseId,
                QtyOnHand = dto.QtyOnHand,
                QtyReserved = dto.QtyReserved,
                ReorderPoint = dto.ReorderPoint
            };
        }
    }
}
