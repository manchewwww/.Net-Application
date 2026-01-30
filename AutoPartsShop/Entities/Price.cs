namespace AutoPartsShop.Entities
{
    public class PriceEntity(int id, int partId, decimal price, string currency, decimal salePrice,
    DateTime? validFrom, DateTime? validTo, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int PartId { get; set; } = partId;
        public decimal Price { get; set; } = price;
        public string Currency { get; set; } = currency;
        public decimal SalePrice { get; set; } = salePrice;
        public DateTime? ValidFrom { get; set; } = validFrom;
        public DateTime? ValidTo { get; set; } = validTo;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}