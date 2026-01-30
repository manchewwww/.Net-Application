namespace AutoPartsShop.Entities.Catalog
{
    public class PartAttributeEntity(int id, int partId, string name, string value, DateTime createdAt, DateTime updatedAt)
    {
        public int Id { get; set; } = id;
        public int PartId { get; set; } = partId;
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
        public DateTime CreatedAt { get; set; } = createdAt;
        public DateTime UpdatedAt { get; set; } = updatedAt;
    };
}