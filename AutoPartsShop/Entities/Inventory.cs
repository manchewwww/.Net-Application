namespace AutoPartsShop.Entities
{
    public class InventoryEntity
    {
        public long PartId { get; set; }
        public long WarehouseId { get; set; }
        public int QtyOnHand { get; set; }
        public int QtyReserved { get; set; }
        public int? ReorderPoint { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
