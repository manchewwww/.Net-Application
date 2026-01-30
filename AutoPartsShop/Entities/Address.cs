using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AddressType Type { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }
        public string Street { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}