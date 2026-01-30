namespace AutoPartsShop.Entities
{
    public class VehicleTrimEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public string EngineCode { get; set; } = null!;
        public string Displacement { get; set; } = null!;
        public string? FuelType { get; set; }
        public string? BodyType { get; set; }
        public string[] Notes { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    };
}