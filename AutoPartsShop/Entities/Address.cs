using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public AddressType Type { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}