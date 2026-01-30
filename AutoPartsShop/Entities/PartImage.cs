namespace AutoPartsShop.Entities
{
    public class PartImageEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public required string ImageUrl { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}