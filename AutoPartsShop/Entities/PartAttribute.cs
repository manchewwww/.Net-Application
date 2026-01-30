namespace AutoPartsShop.Entities
{
    public class PartAttributeEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public required string Name { get; set; }
        public required string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}