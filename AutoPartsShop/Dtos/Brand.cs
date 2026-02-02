namespace AutoPartsShop.Dtos
{
    public record BrandCreateRequest(string Name, string CountryCode);

    public record BrandUpdateRequest(string Name, string CountryCode);

    public record BrandResponse(int Id, string Name, string CountryCode);
}