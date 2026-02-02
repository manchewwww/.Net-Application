namespace AutoPartsShop.Dtos
{
    public record SupplierCreateRequest(string Name, long? CountryId, string? Email, string? Phone, bool IsActive);

    public record SupplierUpdateRequest(string Name, long? CountryId, string? Email, string? Phone, bool IsActive);

    public record SupplierResponse(long Id, string Name, long? CountryId, string? Email, string? Phone, bool IsActive);
}
