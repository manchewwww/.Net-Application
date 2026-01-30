namespace AutoPartsShop.Entities
{
    public class PriceListEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public string? CountryCode { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
