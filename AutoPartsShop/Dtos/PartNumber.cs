using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record PartNumberCreateRequest(long PartId, PartNumberType Type, string Value);

    public record PartNumberUpdateRequest(long PartId, PartNumberType Type, string Value);

    public record PartNumberResponse(long Id, long PartId, PartNumberType Type, string Value);
}
