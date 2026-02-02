namespace AutoPartsShop.Dtos
{
    public record InventoryCreateRequest(long PartId, long WarehouseId, int QtyOnHand, int QtyReserved, int? ReorderPoint);

    public record InventoryUpdateRequest(long PartId, long WarehouseId, int QtyOnHand, int QtyReserved, int? ReorderPoint);

    public record InventoryResponse(long Id, long PartId, long WarehouseId, int QtyOnHand, int QtyReserved, int? ReorderPoint);
}
