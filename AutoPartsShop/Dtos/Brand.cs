namespace AutoPartsShop.Dtos
{
    public record BrandCreateRequest(string Name, string Country);

    public record BrandUpdateRequest(int Id, string Name, string Country);

    public record BrandResponse(int Id, string Name, string Country);
}