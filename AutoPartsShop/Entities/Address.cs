using AutoPartsShop.Enums;

namespace AutoPartsShop.Entities
{
    public class AddressEntity(int id, int customerId, AddressType type, string name,
     int number, string street, string city, string state, string postalCode, string country, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int CustomerId { get; set; } = customerId;
        public AddressType Type { get; set; } = type;
        public string Name { get; set; } = name;
        public int Number { get; set; } = number;
        public string Street { get; set; } = street;
        public string City { get; set; } = city;
        public string State { get; set; } = state;
        public string PostalCode { get; set; } = postalCode;
        public string Country { get; set; } = country;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}