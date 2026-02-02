using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record ReturnCreateRequest(long OrderId, ReturnStatus Status, string? Reason);

    public record ReturnUpdateRequest(long OrderId, ReturnStatus Status, string? Reason);

    public record ReturnResponse(long Id, long OrderId, ReturnStatus Status, string? Reason);
}
