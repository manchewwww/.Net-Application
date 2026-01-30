namespace AutoPartsShop.Entities
{
    public class CategoryEntity
    {
        public long Id { get; set; }
        public long? ParentCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
