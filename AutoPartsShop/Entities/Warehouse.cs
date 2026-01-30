namespace AutoPartsShop.Entities
{
    public class WarehouseEntity(int id, string name, string address, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}