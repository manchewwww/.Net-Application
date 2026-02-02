using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record SupplierPartNumberCreateRequest(long SupplierPartId, PartNumberType Type, string Value);

    public record SupplierPartNumberUpdateRequest(long SupplierPartId, PartNumberType Type, string Value);

    public record SupplierPartNumberResponse(long Id, long SupplierPartId, PartNumberType Type, string Value);
}
