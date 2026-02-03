namespace AutoPartsShop.Dtos
{
    public record CustomerCreateRequest(string Email, string? Phone, bool IsAdmin, string? Password);

    public record CustomerUpdateRequest(string Email, string? Phone, bool IsAdmin, string? Password);

    public record CustomerResponse(long Id, string Email, string? Phone, bool IsAdmin);
}
