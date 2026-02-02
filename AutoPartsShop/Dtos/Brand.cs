namespace AutoPartsShop.Dtos
{
    public record BrandCreateRequest(string Name, long CountryId);

    public record BrandUpdateRequest(string Name, long CountryId);

    public record BrandResponse(int Id, string Name, long CountryId);
}