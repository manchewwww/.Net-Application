namespace AutoPartsShop.Dtos
{
    public record RegisterRequest(string Email, string Password, string? Phone, bool IsAdmin);

    public record LoginRequest(string Email, string Password);

    public record AuthResponse(long Id, string Email, bool IsAdmin, string Token);
}
