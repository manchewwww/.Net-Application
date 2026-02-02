namespace AutoPartsShop.Dtos
{
    public record PartSupplierLinkCreateRequest(long PartId, long SupplierPartId, int Priority, bool IsPrimary);

    public record PartSupplierLinkUpdateRequest(long PartId, long SupplierPartId, int Priority, bool IsPrimary);

    public record PartSupplierLinkResponse(long Id, long PartId, long SupplierPartId, int Priority, bool IsPrimary);
}
