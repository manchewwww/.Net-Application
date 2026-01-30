namespace AutoPartsShop.Entities
{
    public class PartImageEntity
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public string Url { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
