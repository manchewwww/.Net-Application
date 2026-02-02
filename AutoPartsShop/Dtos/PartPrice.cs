namespace AutoPartsShop.Dtos
{
    public record PartPriceCreateRequest(long PartId, long PriceListId, decimal ListPrice, decimal? SalePrice, DateTime ValidFrom, DateTime? ValidTo);

    public record PartPriceUpdateRequest(long PartId, long PriceListId, decimal ListPrice, decimal? SalePrice, DateTime ValidFrom, DateTime? ValidTo);

    public record PartPriceResponse(long Id, long PartId, long PriceListId, decimal ListPrice, decimal? SalePrice, DateTime ValidFrom, DateTime? ValidTo);
}
