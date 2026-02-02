namespace AutoPartsShop.Dtos
{
    public record VehicleVariantCreateRequest(long ModelId, int YearFrom, int YearTo, string? EngineCode, string? Notes);

    public record VehicleVariantUpdateRequest(long ModelId, int YearFrom, int YearTo, string? EngineCode, string? Notes);

    public record VehicleVariantResponse(long Id, long ModelId, int YearFrom, int YearTo, string? EngineCode, string? Notes);
}
