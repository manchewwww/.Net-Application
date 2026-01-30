namespace AutoPartsShop.Entities
{
    public class ReturnItemEntity(int id, int returnId, int orderItemId, int quantity, string? condition, decimal refundAmount, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int ReturnId { get; set; } = returnId;
        public int OrderItemId { get; set; } = orderItemId;
        public int Quantity { get; set; } = quantity;
        public string? Condition { get; set; } = condition;
        public decimal RefundAmount { get; set; } = refundAmount;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    }
}