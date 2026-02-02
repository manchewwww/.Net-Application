namespace AutoPartsShop.Dtos
{
    public record ExchangeRateCreateRequest(long BaseCurrencyId, long QuoteCurrencyId, decimal Rate, DateTime AsOf);

    public record ExchangeRateUpdateRequest(long BaseCurrencyId, long QuoteCurrencyId, decimal Rate, DateTime AsOf);

    public record ExchangeRateResponse(long Id, long BaseCurrencyId, long QuoteCurrencyId, decimal Rate, DateTime AsOf);
}
