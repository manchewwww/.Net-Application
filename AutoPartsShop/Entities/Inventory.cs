namespace AutoPartsShop.Entities
{
    public class InventoryEntity
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int? ReorderPoint { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}