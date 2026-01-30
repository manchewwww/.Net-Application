using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AddressType Type { get; set; }
        public required string Name { get; set; }
        public int Number { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}