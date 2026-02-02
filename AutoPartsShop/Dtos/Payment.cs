using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record PaymentCreateRequest(long OrderId, string Provider, string? ProviderRef, PaymentStatus Status, decimal Amount);

    public record PaymentUpdateRequest(long OrderId, string Provider, string? ProviderRef, PaymentStatus Status, decimal Amount);

    public record PaymentResponse(long Id, long OrderId, string Provider, string? ProviderRef, PaymentStatus Status, decimal Amount);
}
