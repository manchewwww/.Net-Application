namespace AutoPartsShop.Entities
{
    public class PartImageEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}