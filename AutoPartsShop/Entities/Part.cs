namespace AutoPartsShop.Entities
{
    public class PartEntity(int id, string sku, int brandId, int categoryId, string name, string description, bool isActive, decimal weight, decimal price,
        DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public string Sku { get; set; } = sku;
        public int BrandId { get; set; } = brandId;
        public int CategoryId { get; set; } = categoryId;
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public bool IsActive { get; set; } = isActive;
        public decimal Weight { get; set; } = weight;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}