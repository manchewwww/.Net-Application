using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record StockMovementCreateRequest(long PartId, long WarehouseId, StockMovementType Type, int QtyChange, string? ReferenceType, long? ReferenceId, string? Note);

    public record StockMovementUpdateRequest(long PartId, long WarehouseId, StockMovementType Type, int QtyChange, string? ReferenceType, long? ReferenceId, string? Note);

    public record StockMovementResponse(long Id, long PartId, long WarehouseId, StockMovementType Type, int QtyChange, string? ReferenceType, long? ReferenceId, string? Note);
}
