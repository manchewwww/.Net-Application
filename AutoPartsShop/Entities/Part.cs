namespace AutoPartsShop.Entities
{
    public class PartEntity
    {
        public int Id { get; set; }
        public required string Sku { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
        public decimal Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}