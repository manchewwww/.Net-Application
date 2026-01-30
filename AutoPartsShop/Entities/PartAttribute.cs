namespace AutoPartsShop.Entities
{
    public class PartAttributeEntity
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}