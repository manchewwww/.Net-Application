namespace AutoPartsShop.Entities
{
    public class VehicleModelEntity
    {
        public long Id { get; set; }
        public long MakeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
