namespace AutoPartsShop.Dtos
{
    public record SupplierPartCreateRequest(long SupplierId, string SupplierSku, string Name, string? BrandName, decimal? Cost, long? CurrencyId, int? LeadTimeDays, DateTime? LastImportedAt);

    public record SupplierPartUpdateRequest(long SupplierId, string SupplierSku, string Name, string? BrandName, decimal? Cost, long? CurrencyId, int? LeadTimeDays, DateTime? LastImportedAt);

    public record SupplierPartResponse(long Id, long SupplierId, string SupplierSku, string Name, string? BrandName, decimal? Cost, long? CurrencyId, int? LeadTimeDays, DateTime? LastImportedAt);
}
