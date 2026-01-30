namespace AutoPartsShop.Entities
{
    public class VehicleModelEntity(int id, int makeId, string name, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int MakeId { get; set; } = makeId;
        public string Name { get; set; } = name;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}