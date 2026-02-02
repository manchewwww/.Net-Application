namespace AutoPartsShop.Entities
{
    public class SupplierPartEntity
    {
        public long Id { get; set; }
        public long SupplierId { get; set; }
        public string SupplierSku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? BrandName { get; set; }
        public decimal? Cost { get; set; }
        public long? CurrencyId { get; set; }
        public int? LeadTimeDays { get; set; }
        public DateTime? LastImportedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
