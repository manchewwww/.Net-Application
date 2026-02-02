namespace AutoPartsShop.Dtos
{
    public record CartCreateRequest(long? CustomerId);

    public record CartUpdateRequest(long? CustomerId);

    public record CartResponse(long Id, long? CustomerId);
}
