namespace AutoPartsShop.Entities
{
    public class ExchangeRateEntity
    {
        public long Id { get; set; }
        public long BaseCurrencyId { get; set; }
        public string QuoteCurrencyCode { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public DateTime AsOf { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
