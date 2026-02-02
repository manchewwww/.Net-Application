using AutoPartsShop.Enums;

namespace AutoPartsShop.Dtos
{
    public record AddressCreateRequest(long CustomerId, AddressType Type, string Name, string Line1, string? Line2, string City, string? Region, string? PostalCode, long CountryId, bool IsDefault);

    public record AddressUpdateRequest(long CustomerId, AddressType Type, string Name, string Line1, string? Line2, string City, string? Region, string? PostalCode, long CountryId, bool IsDefault);

    public record AddressResponse(long Id, long CustomerId, AddressType Type, string Name, string Line1, string? Line2, string City, string? Region, string? PostalCode, long CountryId, bool IsDefault);
}
