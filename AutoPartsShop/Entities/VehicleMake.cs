namespace AutoPartsShop.Entities
{
    public class VehicleMakeEntity(int id, string name, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}