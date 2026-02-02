using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record PartFitmentCreateRequest(long PartId, long VariantId, FitmentType Fitment, string? Notes);

    public record PartFitmentUpdateRequest(long PartId, long VariantId, FitmentType Fitment, string? Notes);

    public record PartFitmentResponse(long Id, long PartId, long VariantId, FitmentType Fitment, string? Notes);
}
