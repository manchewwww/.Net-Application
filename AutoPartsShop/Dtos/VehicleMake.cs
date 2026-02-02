namespace AutoPartsShop.Dtos
{
    public record VehicleMakeCreateRequest(string Name);

    public record VehicleMakeUpdateRequest(string Name);

    public record VehicleMakeResponse(long Id, string Name);
}
