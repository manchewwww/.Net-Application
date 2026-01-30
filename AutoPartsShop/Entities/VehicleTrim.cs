namespace AutoPartsShop.Entities
{
    public class VehicleTrimEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public required string EngineCode { get; set; }
        public required string Displacement { get; set; }
        public required string? FuelType { get; set; }
        public required string? BodyType { get; set; }
        public required string[] Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}