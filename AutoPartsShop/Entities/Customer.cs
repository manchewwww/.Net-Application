namespace AutoPartsShop.Entities
{
    public class CustomerEntity
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
