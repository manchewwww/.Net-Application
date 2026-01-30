namespace AutoPartsShop.Entities
{
    public class Cart(int id, int customerId, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int CustomerId { get; set; } = customerId;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}