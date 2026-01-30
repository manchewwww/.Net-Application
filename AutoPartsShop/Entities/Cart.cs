namespace AutoPartsShop.Entities
{
    public class CartEntity
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
