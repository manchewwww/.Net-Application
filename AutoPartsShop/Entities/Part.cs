namespace AutoPartsShop.Entities
{
    public class PartEntity
    {
        public long Id { get; set; }
        public string Sku { get; set; } = string.Empty;
        public long BrandId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public decimal? WeightKg { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
