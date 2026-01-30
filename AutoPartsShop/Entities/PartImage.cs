namespace AutoPartsShop.Entities
{
    public class PartImageEntity(int id, int partId, string imageUrl, int sortOrder, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int PartId { get; set; } = partId;
        public string ImageUrl { get; set; } = imageUrl;
        public int SortOrder { get; set; } = sortOrder;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}