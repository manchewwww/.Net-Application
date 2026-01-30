namespace AutoPartsShop.Entities
{
    public class OrderItemEntity
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long PartId { get; set; }
        public string SkuSnapshot { get; set; } = string.Empty;
        public string NameSnapshot { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
