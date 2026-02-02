namespace AutoPartsShop.Entities
{
    public class CountryEntity
    {
        public long Id { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
