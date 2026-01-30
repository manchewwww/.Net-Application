namespace AutoPartsShop.Entities
{
    public class PartEntity
    {
        public int Id { get; set; }
        public string Sku { get; set; } = null!;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public decimal Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}