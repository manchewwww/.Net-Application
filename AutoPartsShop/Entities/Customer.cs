namespace AutoPartsShop.Entities
{
    public class CustomerEntity(int id, string firstName, string lastName, string email, string phoneNumber,
     string passwordHash, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public string PhoneNumber { get; set; } = phoneNumber;
        public string PasswordHash { get; set; } = passwordHash;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}