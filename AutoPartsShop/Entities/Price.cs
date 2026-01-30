namespace AutoPartsShop.Entities
{
    public class PriceEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = null!;
        public decimal SalePrice { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}