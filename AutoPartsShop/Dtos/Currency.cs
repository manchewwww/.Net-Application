namespace AutoPartsShop.Dtos
{
    public record CurrencyCreateRequest(string CurrencyCode, string Name, string? Symbol);

    public record CurrencyUpdateRequest(string CurrencyCode, string Name, string? Symbol);

    public record CurrencyResponse(long Id, string CurrencyCode, string Name, string? Symbol);
}