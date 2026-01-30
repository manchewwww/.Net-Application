using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class StockMovementEntity
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public long WarehouseId { get; set; }
        public StockMovementType Type { get; set; }
        public int QtyChange { get; set; }
        public string? ReferenceType { get; set; }
        public long? ReferenceId { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
