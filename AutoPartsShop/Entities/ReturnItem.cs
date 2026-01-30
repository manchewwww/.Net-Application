namespace AutoPartsShop.Entities
{
    public class ReturnItemEntity
    {
        public long Id { get; set; }
        public long ReturnId { get; set; }
        public long OrderItemId { get; set; }
        public int Qty { get; set; }
        public string? Condition { get; set; }
        public decimal? RefundAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
