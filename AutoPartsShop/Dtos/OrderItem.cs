namespace AutoPartsShop.Dtos
{
    public record OrderItemCreateRequest(long OrderId, long PartId, string SkuSnapshot, string NameSnapshot, decimal UnitPrice, int Qty, decimal LineTotal);

    public record OrderItemUpdateRequest(long OrderId, long PartId, string SkuSnapshot, string NameSnapshot, decimal UnitPrice, int Qty, decimal LineTotal);

    public record OrderItemResponse(long Id, long OrderId, long PartId, string SkuSnapshot, string NameSnapshot, decimal UnitPrice, int Qty, decimal LineTotal);
}
