namespace AutoPartsShop.Dtos
{
    public record PartImageCreateRequest(long PartId, string Url, int SortOrder);

    public record PartImageUpdateRequest(long PartId, string Url, int SortOrder);

    public record PartImageResponse(long Id, long PartId, string Url, int SortOrder);
}
