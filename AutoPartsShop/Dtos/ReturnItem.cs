namespace AutoPartsShop.Dtos
{
    public record ReturnItemCreateRequest(long ReturnId, long OrderItemId, int Qty, string? Condition, decimal? RefundAmount);

    public record ReturnItemUpdateRequest(long ReturnId, long OrderItemId, int Qty, string? Condition, decimal? RefundAmount);

    public record ReturnItemResponse(long Id, long ReturnId, long OrderItemId, int Qty, string? Condition, decimal? RefundAmount);
}
