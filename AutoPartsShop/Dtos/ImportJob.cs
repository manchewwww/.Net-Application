namespace AutoPartsShop.Dtos
{
    public record ImportJobCreateRequest(long SupplierId, string Status, DateTime StartedAt, DateTime? FinishedAt, string? StatsJson, string? ErrorMessage);

    public record ImportJobUpdateRequest(long SupplierId, string Status, DateTime StartedAt, DateTime? FinishedAt, string? StatsJson, string? ErrorMessage);

    public record ImportJobResponse(long Id, long SupplierId, string Status, DateTime StartedAt, DateTime? FinishedAt, string? StatsJson, string? ErrorMessage);
}
