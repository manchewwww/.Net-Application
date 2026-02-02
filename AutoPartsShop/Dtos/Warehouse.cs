namespace AutoPartsShop.Dtos
{
    public record WarehouseCreateRequest(string Name, long CountryId, string City, string Address1, string? Address2, string? Postcode);

    public record WarehouseUpdateRequest(string Name, long CountryId, string City, string Address1, string? Address2, string? Postcode);

    public record WarehouseResponse(long Id, string Name, long CountryId, string City, string Address1, string? Address2, string? Postcode);
}
