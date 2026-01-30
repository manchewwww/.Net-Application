namespace AutoPartsShop.Entities
{
    public class InventoryEntity(int id, int warehouseId, int quantityOnHand, int quantityReserved, int? reorderPoint, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int WarehouseId { get; set; } = warehouseId;
        public int QuantityOnHand { get; set; } = quantityOnHand;
        public int QuantityReserved { get; set; } = quantityReserved;
        public int? ReorderPoint { get; set; } = reorderPoint;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}