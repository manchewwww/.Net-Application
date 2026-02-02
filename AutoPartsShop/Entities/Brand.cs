namespace AutoPartsShop.Entities
{
    public class BrandEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long CountryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
