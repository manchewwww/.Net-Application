using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class AddressEntity
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public AddressType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Line1 { get; set; } = string.Empty;
        public string? Line2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
