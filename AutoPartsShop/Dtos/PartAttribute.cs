namespace AutoPartsShop.Dtos
{
    public record PartAttributeCreateRequest(long PartId, string Name, string Value);

    public record PartAttributeUpdateRequest(long PartId, string Name, string Value);

    public record PartAttributeResponse(long Id, long PartId, string Name, string Value);
}
