namespace AutoPartsShop.Dtos
{
    public record CurrencyCreateRequest(string Code, string Name, string? Symbol);

    public record CurrencyUpdateRequest(string Code, string Name, string? Symbol);

    public record CurrencyResponse(long Id, string Code, string Name, string? Symbol);
}