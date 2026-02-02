namespace AutoPartsShop.Dtos
{
    public record CustomerCreateRequest(string Email, string? Phone, string? PasswordHash);

    public record CustomerUpdateRequest(string Email, string? Phone, string? PasswordHash);

    public record CustomerResponse(long Id, string Email, string? Phone, string? PasswordHash);
}
