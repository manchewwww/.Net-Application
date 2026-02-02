namespace AutoPartsShop.Dtos
{
    public record PriceListCreateRequest(string Name, long CurrencyId, long? CountryId, bool IsActive);

    public record PriceListUpdateRequest(string Name, long CurrencyId, long? CountryId, bool IsActive);

    public record PriceListResponse(long Id, string Name, long CurrencyId, long? CountryId, bool IsActive);
}
