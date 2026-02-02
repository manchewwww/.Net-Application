namespace AutoPartsShop.Dtos
{
    public record CartItemCreateRequest(long CartId, long PartId, int Qty);

    public record CartItemUpdateRequest(long CartId, long PartId, int Qty);

    public record CartItemResponse(long Id, long CartId, long PartId, int Qty);
}
