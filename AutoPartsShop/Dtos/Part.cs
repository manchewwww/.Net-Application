namespace AutoPartsShop.Dtos
{
    public record PartCreateRequest(string Sku, long BrandId, long CategoryId, string Name, string? Description, bool IsActive, decimal? WeightKg);

    public record PartUpdateRequest(string Sku, long BrandId, long CategoryId, string Name, string? Description, bool IsActive, decimal? WeightKg);

    public record PartResponse(long Id, string Sku, long BrandId, long CategoryId, string Name, string? Description, bool IsActive, decimal? WeightKg);
}
