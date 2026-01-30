namespace AutoPartsShop.Entities
{
    public class ReturnItemEntity
    {
        public int Id { get; set; }
        public int ReturnId { get; set; }
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public string? Condition { get; set; }
        public decimal RefundAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}