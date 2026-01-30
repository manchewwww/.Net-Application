namespace AutoPartsShop.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}