namespace AutoPartsShop.Dtos
{
    public record VehicleModelCreateRequest(long MakeId, string Name);

    public record VehicleModelUpdateRequest(long MakeId, string Name);

    public record VehicleModelResponse(long Id, long MakeId, string Name);
}
