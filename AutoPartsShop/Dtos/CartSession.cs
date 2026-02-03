namespace AutoPartsShop.Dtos
{
    public record CartItemUpsertRequest(long PartId, int Qty);

    public record CartSessionItemResponse(long Id, long PartId, int Qty, string PartName, string Sku);

    public record CartSessionResponse(long CartId, IEnumerable<CartSessionItemResponse> Items);
}
