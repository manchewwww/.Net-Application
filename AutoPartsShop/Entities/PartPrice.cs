namespace AutoPartsShop.Entities
{
    public class PartPriceEntity
    {
        public long Id { get; set; }
        public long PartId { get; set; }
        public long PriceListId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
